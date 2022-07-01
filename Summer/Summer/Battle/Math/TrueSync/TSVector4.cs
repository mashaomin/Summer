
using System;
#if USEBATTLEDLL
#else
namespace TrueSync
{
    public struct TSVector4
    {
        public static FP kEpsilon = FP.EN4;

        public FP x;

        public FP y;

        public FP z;

        public FP w;

        public FP this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                    case 3:
                        return this.w;
                    default:
                        throw new IndexOutOfRangeException("get Invalid Vector4 index:"+index);
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    case 2:
                        this.z = value;
                        break;
                    case 3:
                        this.w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("set Invalid Vector4 index:"+index);
                }
            }
        }

        public TSVector4 normalized
        {
            get
            {
                return TSVector4.Normalize(ref this);
            }
        }

        public FP magnitude
        {
            get
            {
                return FP.Sqrt(x * x + y * y + z * z + w * w);
            }
        }

        public FP sqrMagnitude
        {
            get
            {
                return x * x + y *y + z * z + w * w;
            }
        }

        public static TSVector4 zero = new TSVector4(FP.Zero, FP.Zero, FP.Zero, FP.Zero);
 
        public static TSVector4 one = new TSVector4(FP.One, FP.One, FP.One, FP.One);
  

        public TSVector4(FP x, FP y, FP z, FP w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public TSVector4(TSVector v, FP w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }
        public TSVector4(FP x, FP y, FP z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = FP.Zero;
        }

        public TSVector4(FP x, FP y)
        {
            this.x = x;
            this.y = y;
            this.z = FP.Zero;
            this.w = FP.Zero;
        }

        public void Set(FP new_x, FP new_y, FP new_z, FP new_w)
        {
            this.x = new_x;
            this.y = new_y;
            this.z = new_z;
            this.w = new_w;
        }

        public static TSVector4 Lerp(TSVector4 a, TSVector4 b, FP t)
        {
            t = FP.Clamp01(t);
            return new TSVector4(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t, a.w + (b.w - a.w) * t);
        }

        public static TSVector4 LerpUnclamped(TSVector4 a, TSVector4 b, FP t)
        {
            return new TSVector4(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t, a.w + (b.w - a.w) * t);
        }

        public static TSVector4 MoveTowards(TSVector4 current, TSVector4 target, FP maxDistanceDelta)
        {
            TSVector4 a = target - current;
            FP magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == FP.Zero)
            {
                return target;
            }
            return current + a / magnitude * maxDistanceDelta;
        }

        public static TSVector4 Scale(TSVector4 a, TSVector4 b)
        {
            return new TSVector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }

        public void Scale(TSVector4 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
            this.z *= scale.z;
            this.w *= scale.w;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.w.GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is TSVector4))
            {
                return false;
            }
            TSVector4 vector = (TSVector4)other;
            return this.x.Equals(vector.x) && this.y.Equals(vector.y) && this.z.Equals(vector.z) && this.w.Equals(vector.w);
        }

        public static TSVector4 Normalize(ref TSVector4 a)
        {
            FP num = TSVector4.Magnitude(ref a);
            if (num > FP.EN4)
            {
                return a / num;
            }
            return TSVector4.zero;
        }

        public void Normalize()
        {
            FP num = TSVector4.Magnitude(ref this);
            if (num > FP.EN4)
            {
                this /= num;
            }
            else
            {
                this = TSVector4.zero;
            }
        }

        public override string ToString()
        {
            return string.Format("({0:F1}, {1:F1}, {2:F1}, {3:F1})", new object[]
            {
                this.x,
                this.y,
                this.z,
                this.w
            });
        }

        public string ToString(string format)
        {
            return string.Format("({0}, {1}, {2}, {3})", new object[]
            {
                this.x.AsFloat().ToString(format),
                this.y.AsFloat().ToString(format),
                this.z.AsFloat().ToString(format),
                this.w.AsFloat().ToString(format)
            });
        }

        public static FP Dot(TSVector4 a, TSVector4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        public static TSVector4 Project(TSVector4 a, TSVector4 b)
        {
            return b * TSVector4.Dot(a, b) / TSVector4.Dot(b, b);
        }

        public static FP Distance(TSVector4 a, TSVector4 b)
        {
            return TSVector4.Magnitude(a - b);
        }

        public static FP Magnitude(ref TSVector4 a)
        {
            return FP.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z + a.w * a.w);
        }
        public static FP Magnitude(TSVector4 a)
        {
            return FP.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z + a.w * a.w);
        }

        public static FP SqrMagnitude(TSVector4 a)
        {
            return a.x * a.x + a.y * a.y + a.z * a.z + a.w * a.w; 
        }

        public FP SqrMagnitude()
        {
            return x * x + y * y + z * z + w * w;
        }

        public static TSVector4 Min(TSVector4 lhs, TSVector4 rhs)
        {
            return new TSVector4(TSMath.Min(lhs.x, rhs.x), TSMath.Min(lhs.y, rhs.y), TSMath.Min(lhs.z, rhs.z), TSMath.Min(lhs.w, rhs.w));
        }

        public static TSVector4 Max(TSVector4 lhs, TSVector4 rhs)
        {
            return new TSVector4(TSMath.Max(lhs.x, rhs.x), TSMath.Max(lhs.y, rhs.y), TSMath.Max(lhs.z, rhs.z), TSMath.Max(lhs.w, rhs.w));
        }

        public static TSVector4 operator +(TSVector4 a, TSVector4 b)
        {
            a.x._serializedValue = a.x._serializedValue + b.x._serializedValue;
            a.y._serializedValue = a.y._serializedValue + b.y._serializedValue;
            a.z._serializedValue = a.z._serializedValue + b.z._serializedValue;
            a.w._serializedValue = a.w._serializedValue + b.w._serializedValue;

            return a;
        }

        public static TSVector4 operator -(TSVector4 a, TSVector4 b)
        {
            a.x._serializedValue = a.x._serializedValue - b.x._serializedValue;
            a.y._serializedValue = a.y._serializedValue - b.y._serializedValue;
            a.z._serializedValue = a.z._serializedValue - b.z._serializedValue;
            a.w._serializedValue = a.w._serializedValue - b.w._serializedValue;
            return a;
        }

        public static TSVector4 operator -(TSVector4 a)
        {
            a.x._serializedValue = -a.x._serializedValue;
            a.y._serializedValue = -a.y._serializedValue;
            a.z._serializedValue = -a.z._serializedValue;
            a.w._serializedValue = -a.w._serializedValue;
            return a;
        }

        public static TSVector4 operator *(TSVector4 a, FP d)
        {
            return new TSVector4(a.x * d, a.y * d, a.z * d, a.w * d);
        }

        public static TSVector4 operator *(FP d, TSVector4 a)
        {
            return new TSVector4(a.x * d, a.y * d, a.z * d, a.w * d);
        }

        public static TSVector4 operator /(TSVector4 a, FP d)
        {
            return new TSVector4(a.x / d, a.y / d, a.z / d, a.w / d);
        }

        public static bool operator ==(TSVector4 lhs, TSVector4 rhs)
        {
            return TSVector4.SqrMagnitude(lhs - rhs) < FP.EN4;
        }

        public static bool operator !=(TSVector4 lhs, TSVector4 rhs)
        {
            return TSVector4.SqrMagnitude(lhs - rhs) >= FP.EN4;
        }

        public static implicit operator TSVector4(TSVector v)
        {
            return new TSVector4(v.x, v.y, v.z, FP.Zero);
        }

        public static implicit operator TSVector(TSVector4 v)
        {
            return new TSVector(v.x, v.y, v.z);
        }

        public static implicit operator TSVector4(TSVector2 v)
        {
            return new TSVector4(v.x, v.y, FP.Zero, FP.Zero);
        }

        public static implicit operator TSVector2(TSVector4 v)
        {
            return new TSVector2(v.x, v.y);
        }

        public TSVector4 Abs()
        {
            return new TSVector4(FP.FastAbs(x), FP.FastAbs(y), FP.FastAbs(z), FP.FastAbs(w));
        }

        public TSVector Absolute()
        {
            return new TSVector4(FP.FastAbs(x), FP.FastAbs(y), FP.FastAbs(z), FP.FastAbs(w));
        }
    }
}
#endif