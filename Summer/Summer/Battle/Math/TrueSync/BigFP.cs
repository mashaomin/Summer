using System;
using System.IO;

#if USEBATTLEDLL
#else
namespace TrueSync
{
    public partial struct BigFP : IEquatable<BigFP>, IComparable<BigFP>
    {
        public long _longValue;
        public FP _decimalValue;
        public static readonly BigFP FPLargeValue = new BigFP(FP.MaxValue * FP.EN4);
        public static readonly BigFP FPSmallValue = new BigFP(FP.MinValue * FP.EN4);

        public static readonly long FPMaxLong = FP.MaxValue.AsLong() - 1;

        public static readonly BigFP Zero = new BigFP(FP.Zero);
        public BigFP(FP rawValue)
        {
            _longValue = (long)(rawValue);
            _decimalValue = rawValue - _longValue;
        }

        public BigFP(long rawValue)
        {
            _longValue = rawValue;
            _decimalValue = FP.Zero;
        }
        public override bool Equals(object obj)
        {
            return obj is BigFP && ((BigFP)obj)._longValue == _longValue && ((BigFP)obj)._decimalValue == _decimalValue;
        }

        public override int GetHashCode()
        {
            return _longValue.GetHashCode();
        }

        public bool Equals(BigFP other)
        {
            return _longValue == other._longValue && _decimalValue == other._decimalValue;
        }

        public int CompareTo(BigFP other)
        {
            int compare = _longValue.CompareTo(other._longValue);
            if (compare == 0)
            {
                return _decimalValue.CompareTo(other._decimalValue);
            }
            return compare;
        }

        public static implicit operator BigFP(long value)
        {
            BigFP fp;
            fp._longValue = (value);
            fp._decimalValue = FP.Zero;
            return fp;
        }

        public static implicit operator BigFP(FP value)
        {
            BigFP fp;
            fp._longValue = (long)(value);
            fp._decimalValue = value - fp._longValue;
            return fp;
        }

        public static explicit operator long(BigFP value)
        {
            return value._longValue;
        }

        public static explicit operator FP(BigFP value)
        {
            FP fp = value._longValue;
            fp._serializedValue +=  value._decimalValue._serializedValue;
            return fp;
        }

        public static implicit operator BigFP(float value)
        {
            BigFP fp;
            fp._longValue = (long)value;
            fp._decimalValue = (FP)(value - fp._longValue);
            return fp;
        }

        public static explicit operator float(BigFP value)
        {
            return value._longValue + (float)value._decimalValue;
        }

        public static implicit operator BigFP(double value)
        {
            BigFP fp;
            fp._longValue = (long)value;
            fp._decimalValue = (FP)(value - fp._longValue);
            return fp;
        }

        public static explicit operator double(BigFP value)
        {
            return value._longValue + (double)value._decimalValue;
        }

        public static explicit operator BigFP(decimal value)
        {
            BigFP fp;
            fp._longValue = (long)value;
            fp._decimalValue = (FP)(value - fp._longValue);
            return fp;
        }

        public static implicit operator BigFP(int value)
        {
            BigFP fp;
            fp._longValue = value;
            fp._decimalValue = FP.Zero;
            return fp;
            //return new FP(value * ONE);
        }

        public static explicit operator decimal(BigFP value)
        {
            return value._longValue + (decimal)value._decimalValue;
        }

        public FP AsFP()
        {
            return (FP)this;
        }

        public float AsFloat()
        {
            return (float)this;
        }

        public int AsInt()
        {
            return (int)this;
        }

        public long AsLong()
        {
            return (long)this;
        }

        public double AsDouble()
        {
            return (double)this;
        }

        public decimal AsDecimal()
        {
            return (decimal)this;
        }

        public static float ToFloat(BigFP value)
        {
            return (float)value;
        }

        public static int ToInt(BigFP value)
        {
            return (int)value;
        }

        public static BigFP FromFloat(float value)
        {
            return (BigFP)value;
        }

        /// <summary>
        /// Adds x and y. Performs saturating addition, i.e. in case of overflow,
        /// rounds to MinValue or MaxValue depending on sign of operands.
        /// </summary>
        public static BigFP operator +(BigFP x, BigFP y)
        {
            BigFP p;
            p._longValue = x._longValue + y._longValue;
            p._decimalValue = x._decimalValue + y._decimalValue;
            long dec = (long)p._decimalValue;
            p._longValue += dec;
            p._decimalValue -= dec;
            return p;
            //return new FP(x._serializedValue + y._serializedValue);
        }

        public static BigFP operator -(BigFP x, BigFP y)
        {
            BigFP p;
            p._longValue = x._longValue - y._longValue;
            p._decimalValue = x._decimalValue - y._decimalValue;
            long dec = (long)p._decimalValue;
            p._longValue += dec;
            p._decimalValue -= dec;
            return p;
            //return new FP(x._serializedValue - y._serializedValue);
        }

        public static BigFP operator *(BigFP x, BigFP y)
        {
            BigFP p;
            p._longValue = x._longValue * y._longValue;
            p._decimalValue = x._decimalValue * y._decimalValue;//x._longValue * y._decimalValue + y._longValue * x._decimalValue
            int bitPos = 0;
            bool isOverZero = x._longValue >= 0;
            long longValue = isOverZero ? x._longValue : -x._longValue;
            long dec = longValue;
            while (longValue >= FPMaxLong)
            {
                longValue >>= 4;
                bitPos += 4;
            }
            if (bitPos > 0)
            {
                FP multi =  y._decimalValue;
                multi._serializedValue <<= bitPos;
                long multLong = multi.AsLong();
                multi -= multLong;
                dec -= longValue << bitPos;
                FP rest1 = dec * y._decimalValue; 
                FP rest3 = multi * longValue;
                long rest2 = longValue * multLong;
                if (!isOverZero)
                {
                    p._decimalValue -= dec * y._decimalValue + multi * longValue;
                    p._longValue -= longValue * multLong;
                }else
                {
                    p._decimalValue += dec * y._decimalValue + multi * longValue;
                    p._longValue += longValue * multLong;
                }
            }else
            {
                p._decimalValue += x._longValue * y._decimalValue;
            }
            
            dec = (long)p._decimalValue;
            p._longValue += dec;
            p._decimalValue -= dec;

            bitPos = 0;
            isOverZero = y._longValue >= 0;
            longValue = isOverZero ? y._longValue : -y._longValue;
            dec = longValue;
            while (longValue >= FPMaxLong)
            {
                longValue >>= 4;
                bitPos += 4;
            }
            if (bitPos > 0)
            {
                FP multi = x._decimalValue;
                multi._serializedValue <<= bitPos;
                long multLong = multi.AsLong();
                multi -= multLong;
                dec -= longValue << bitPos;
                if (!isOverZero)
                {
                    p._decimalValue -= dec * x._decimalValue + multi * longValue;
                    p._longValue -= longValue * multLong;
                }
                else
                {
                    p._decimalValue += dec * x._decimalValue + multi * longValue;
                    p._longValue += longValue * multLong;
                }
            }
            else
            {
                p._decimalValue += y._longValue * x._decimalValue;
            }

            dec = (long)p._decimalValue;
            p._longValue += dec;
            p._decimalValue -= dec;
            return p;
        }
        /// <summary>
        /// 近似处理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static BigFP operator /(BigFP x, BigFP y)
        {
            if (y > FPLargeValue || y < FPSmallValue)
            {
                BigFP result = BigFP.Zero;
                result._longValue = x._longValue / y._longValue;
                long remainder = x._longValue % y._longValue;
                FP x1 = FP.Zero;
                x1._serializedValue = remainder;
                FP y1 = FP.Zero;
                y1._serializedValue = y._longValue;
                result._decimalValue = x1 / y1;
                return result;
            }
            FP inv = 1 / (y._longValue + y._decimalValue);
            return x * inv;
        }

        public static bool operator ==(BigFP x, BigFP y)
        {
            return x._longValue == y._longValue && x._decimalValue == y._decimalValue;
        }

        public static bool operator !=(BigFP x, BigFP y)
        {
            return x._longValue != y._longValue || x._decimalValue != y._decimalValue;
        }

        public static bool operator >(BigFP x, BigFP y)
        {
            if (x._longValue != y._longValue)
            {
                return x._longValue > y._longValue;
            }
            return x._decimalValue > y._decimalValue;
        }

        public static bool operator <(BigFP x, BigFP y)
        {
            if (x._longValue != y._longValue)
            {
                return x._longValue < y._longValue;
            }
            return x._decimalValue < y._decimalValue;
        }

        public static bool operator >=(BigFP x, BigFP y)
        {
            if (x._longValue != y._longValue)
            {
                return x._longValue >= y._longValue;
            }
            return x._decimalValue >= y._decimalValue;
        }

        public static bool operator <=(BigFP x, BigFP y)
        {
            if (x._longValue != y._longValue)
            {
                return x._longValue <= y._longValue;
            }
            return x._decimalValue <= y._decimalValue;
        }
        public override string ToString()
        {
            return ((float)this).ToString();
        }

#if UNITY_EDITOR
        public static string GetDoubleString(double f, bool add = false)
        {
            if (add && f < 0)
            {
                return "(" + f.ToString() + ")";
            }
            return f.ToString();
        }
        /// <summary>
        /// test math when change bit
        /// </summary>
        public static void TestMath()
        {
            using (var writer = new StreamWriter("../TestMath.txt"))
            {
 
                double a = 1.2f;
                BigFP b = a;

                for (double i = -10; i <= 1000; i += 0.412369f)
                {
                    double d = i * 1000000;
                    double c = a;
                    b = a;

                    a -= d;
                    b -= (BigFP)d;
                    writer.WriteLine(GetDoubleString(c, true) + "-" + GetDoubleString(d, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a));
                }

                for (double i = -10; i <= 2000; i += 0.13581f)
                {
                    double d = i * 1000000;

                    double c = a;
                    b = a;

                    a += d;
                    b += (BigFP)d;
                    writer.WriteLine(GetDoubleString(c, true) + "+" + GetDoubleString(d, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a));
                }


                for (double i = -1; i <= 1; i += 0.216813f)
                {
                    if (i == 0)
                        continue;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a));
                }

                a = 0.000015;
                for (double i = -10; i <= 120; i += 1.18735f)
                {
                    double d = 1.7 * i / 10;

                    if (i == 0)
                        continue;

                    double c = a;
                    b = a;
                    a /= d;
                    b /= d;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(d, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a));
                }

                a = 38.67f;
                for (double i = -28f; i <= 128f; i += 1.38421f)
                {
                    double d = 2.1 * i / 10;

                    double c = a;
                    b = a;
                    a *= d;
                    b *= d;
                    writer.WriteLine(GetDoubleString(c, true) + "*" + GetDoubleString(d, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a));
                }


                {
                    a = 9568556226447236.31;
                    double i = 10235465876883.67;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = -95685586226447236.31;
                    double i = 10235465876883.67;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = 95685586226447236.31;
                    double i = -10235465876883.67;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = 95685586226447236.31;
                    double i = -0.67;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = -95685586226447236.31;
                    double i = -0.67;
                    double c = a;
                    b = a;
                    a /= i;
                    b /= i;
                    writer.WriteLine(GetDoubleString(c, true) + "/" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = 322224443.67;
                    double i = 5721142.31;
                    double c = a;
                    b = a;
                    a *= i;
                    b *= i;
                    writer.WriteLine(GetDoubleString(c, true) + "*" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()));
                }
                {
                    a = -322224443.67;
                    double i = 5721142.31;
                    double c = a;
                    b = a;
                    a *= i;
                    b *= i;
                    writer.WriteLine(GetDoubleString(c, true) + "*" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
                {
                    a = 322224443.67;
                    double i = -5721142.31;
                    double c = a;
                    b = a;
                    a *= i;
                    b *= i;
                    writer.WriteLine(GetDoubleString(c, true) + "*" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()));
                }
                {
                    a = -322224443.67;
                    double i = -5721142.31;
                    double c = a;
                    b = a;
                    a *= i;
                    b *= i;
                    writer.WriteLine(GetDoubleString(c, true) + "*" + GetDoubleString(i, true) + ":\t" + GetDoubleString(b.AsDouble()) + "\t" + GetDoubleString(a) + ":\t" + GetDoubleString(a - b.AsDouble()) );
                }
            }
        }
#endif
    }
}
#endif