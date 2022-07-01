using System;
using System.Collections.Generic;
using System.Reflection;
using TrueSync;

#if USEBATTLEDLL
#else
public class OPTSRandom
{
    private const int N = 624;
    private const int M = 397;
    private const uint MATRIX_A = 0x9908b0dfU;
    private const uint UPPER_MASK = 0x80000000U;
    private const uint LOWER_MASK = 0x7fffffffU;
    private const int MAX_RAND_INT = 0x7fffffff;
    private uint[] mag01 = { 0x0U, MATRIX_A };
    private uint[] mt = new uint[N];
    private int mti = N + 1;

    //public static OPTSRandom instance;

    public static OPTSRandom New(int seed)
    {
        OPTSRandom r = new OPTSRandom(seed);
        return r;
    }

    public static OPTSRandom New(uint seed)
    {
        OPTSRandom r = new OPTSRandom(seed);
        return r;
    }

    private OPTSRandom()
    {
        init_genrand((uint)DateTime.Now.Millisecond);
    }

    private OPTSRandom(int seed)
    {
        init_genrand((uint)seed);
    }

    private OPTSRandom(uint seed)
    {
        init_genrand(seed);
    }

    private OPTSRandom(int[] init)
    {
        uint[] initArray = new uint[init.Length];
        for (int i = 0; i < init.Length; ++i)
            initArray[i] = (uint)init[i];
        init_by_array(initArray, (uint)initArray.Length);
    }

    public static int MaxRandomInt { get { return 0x7fffffff; } }

    public int Next()
    {
        return genrand_int31();
    }

    public int CallNext()
    {
        return Next();
    }

    public int Next(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            int tmp = maxValue;
            maxValue = minValue;
            minValue = tmp;
        }

        int range = maxValue - minValue;
        if (range == 0)
        {
            return minValue;
        }
        return minValue + Next() % range;
    }

    //Add for Lua
    public int NextInt(int minValue, int maxValue)
    {
        return Next(minValue, maxValue);
    }

    public FP Next(FP minValue, FP maxValue)
    {
        FP temp1 = (minValue) * 1000;
        int minValueInt = temp1.AsInt();

        FP temp2 = (maxValue)  * 1000;
        int maxValueInt = temp2.AsInt();

        if (minValueInt > maxValueInt)
        {
            int tmp = maxValueInt;
            maxValueInt = minValueInt;
            minValueInt = tmp;
        }

        return (FP.Floor((maxValueInt - minValueInt + 1) * NextFP() +
          minValueInt)) / 1000;
    }

    /// <summary>
    /// 没随到返回-1
    /// </summary>
    /// <param name="minValue">最小值，左闭</param>
    /// <param name="maxValue">最大值，右开</param>
    /// <param name="lst">List中的值都被随机到会重新随机</param>
    /// <returns></returns>
    public int RangeWithoutLst(int minValue, int maxValue, List<int> lst)
    {
        if(lst == null)
        {
            return Next(minValue, maxValue);
        }

        int times = 0;
        int rand = -1;
        while (times < 1000)
        {
            times++;
            rand = Next(minValue, maxValue);
            if(lst.Contains(rand))
            {
                continue;
            }
            else
            {
                lst.Add(rand);
                break;
            }
        }
        return rand;
    }

    /// <summary>
    /// 左闭右开
    /// </summary>
    public int Range(int minValue, int maxValue)
    {
        return Next(minValue, maxValue);
    }
    public FP Range(FP minValue, FP maxValue)
    {
        return Next(minValue, maxValue);
    }
    public FP Range(float minValue, float maxValue)
    {
        return Next((FP)minValue, (FP)maxValue);
    }

    public FP NextFP()
    {
        return ((FP)Next()) / (MaxRandomInt);
    }

    public FP value
    {
        get
        {
            return NextFP();
        }
    }

    public TSVector onUnitSphere
    {
        get
        {
            //FP x = value;
            //FP z = value;
            //FP y = value;
            //FP yValue = FP.Sqrt(1 - x * x - y * y);
            //yValue = y > FP.Half ? yValue : -yValue;
            return new TSVector(value, value, value);
        }
    }
    public TSVector insideUnitSphere
    {
        get
        {
            return new TSVector(value, value, value);
        }
    }

    private float NextFloat()
    {
        return (float)genrand_real2();
    }

    private float NextFloat(bool includeOne)
    {
        if (includeOne)
        {
            return (float)genrand_real1();
        }
        return (float)genrand_real2();
    }

    private float NextFloatPositive()
    {
        return (float)genrand_real3();
    }

    private double NextDouble()
    {
        return genrand_real2();
    }

    private double NextDouble(bool includeOne)
    {
        if (includeOne)
        {
            return genrand_real1();
        }
        return genrand_real2();
    }

    private double NextDoublePositive()
    {
        return genrand_real3();
    }

    private double Next53BitRes()
    {
        return genrand_res53();
    }

    public void Initialize()
    {
        init_genrand((uint)DateTime.Now.Millisecond);
    }

    public void Initialize(int seed)
    {
        init_genrand((uint)seed);
    }

    public void Initialize(int[] init)
    {
        uint[] initArray = new uint[init.Length];
        for (int i = 0; i < init.Length; ++i)
            initArray[i] = (uint)init[i];
        init_by_array(initArray, (uint)initArray.Length);
    }

    private void init_genrand(uint s)
    {
        mt[0] = s & 0xffffffffU;
        for (mti = 1; mti < N; mti++)
        {
            mt[mti] = (uint)(1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
            mt[mti] &= 0xffffffffU;
        }
    }

    private void init_by_array(uint[] init_key, uint key_length)
    {
        int i, j, k;
        init_genrand(19650218U);
        i = 1;
        j = 0;
        k = (int)(N > key_length ? N : key_length);
        for (; k > 0; k--)
        {
            mt[i] = (uint)((uint)(mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525U)) + init_key[j] + j);
            mt[i] &= 0xffffffffU;
            i++;
            j++;
            if (i >= N)
            {
                mt[0] = mt[N - 1];
                i = 1;
            }
            if (j >= key_length)
                j = 0;
        }
        for (k = N - 1; k > 0; k--)
        {
            mt[i] = (uint)((uint)(mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) *
             1566083941U)) - i);
            mt[i] &= 0xffffffffU;
            i++;
            if (i >= N)
            {
                mt[0] = mt[N - 1];
                i = 1;
            }
        }
        mt[0] = 0x80000000U;
    }

    uint genrand_int32()
    {
        uint y;
        if (mti >= N)
        {
            int kk;
            if (mti == N + 1)
                init_genrand(5489U);
            for (kk = 0; kk < N - M; kk++)
            {
                y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
            }
            for (; kk < N - 1; kk++)
            {
                y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
            }
            y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
            mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];
            mti = 0;
        }
        y = mt[mti++];
        y ^= (y >> 11);
        y ^= (y << 7) & 0x9d2c5680U;
        y ^= (y << 15) & 0xefc60000U;
        y ^= (y >> 18);
        return y;
    }

    private int genrand_int31()
    {
        return (int)(genrand_int32() >> 1);
    }

    FP genrand_FP()
    {
        return (FP)genrand_int32()  / (FP)4294967295;
    }

    double genrand_real1()
    {
        return genrand_int32() * (1.0 / 4294967295.0);
    }
    double genrand_real2()
    {
        return genrand_int32() * (1.0 / 4294967296.0);
    }

    double genrand_real3()
    {
        return (((double)genrand_int32()) + 0.5) * (1.0 / 4294967296.0);
    }

    double genrand_res53()
    {
        uint a = genrand_int32() >> 5, b = genrand_int32() >> 6;
        return (a * 67108864.0 + b) * (1.0 / 9007199254740992.0);
    }
   
}
#endif