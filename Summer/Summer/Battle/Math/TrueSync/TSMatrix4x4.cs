using System;
#if USEBATTLEDLL
#else
namespace TrueSync
{
    public struct TSMatrix4x4
    {
        public FP M11;

        public FP M21;

        public FP M31;

        public FP M41;

        public FP M12;

        public FP M22;

        public FP M32;

        public FP M42;

        public FP M13;

        public FP M23;

        public FP M33;

        public FP M43;

        public FP M14;

        public FP M24;

        public FP M34;

        public FP M44;

        public static readonly TSMatrix4x4 Identity;
        private static readonly TSMatrix4x4 Zero;

        static TSMatrix4x4()
        {
            Zero = new TSMatrix4x4();

            Identity = new TSMatrix4x4();
            Identity.M11 = FP.One;
            Identity.M22 = FP.One;
            Identity.M33 = FP.One;
            Identity.M44 = FP.One;
        }

        public TSMatrix4x4(FP m11, FP m12, FP m13, FP m14, FP m21, FP m22, FP m23, FP m24, FP m31, FP m32, FP m33, FP m34, FP m41, FP m42, FP m43, FP m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public void UpdateMatrix(ref TSMatrix4x4 value)
        {
            M11._serializedValue = value.M11._serializedValue;
            M12._serializedValue = value.M12._serializedValue;
            M13._serializedValue = value.M13._serializedValue;
            M14._serializedValue = value.M14._serializedValue;


            M21._serializedValue = value.M21._serializedValue;
            M22._serializedValue = value.M22._serializedValue;
            M23._serializedValue = value.M23._serializedValue;
            M24._serializedValue = value.M24._serializedValue;


            M31._serializedValue = value.M31._serializedValue;
            M32._serializedValue = value.M32._serializedValue;
            M33._serializedValue = value.M33._serializedValue;
            M34._serializedValue = value.M34._serializedValue;

            M41._serializedValue = value.M41._serializedValue;
            M42._serializedValue = value.M42._serializedValue;
            M43._serializedValue = value.M43._serializedValue;
            M44._serializedValue = value.M44._serializedValue;

        }
        public FP this[int row, int column]
        {
            get
            {
                int index = row + column * 4;
                switch (index)
                {
                    case 0:
                        return this.M11;
                    case 1:
                        return this.M21;
                    case 2:
                        return this.M31;
                    case 3:
                        return this.M41;
                    case 4:
                        return this.M12;
                    case 5:
                        return this.M22;
                    case 6:
                        return this.M32;
                    case 7:
                        return this.M42;
                    case 8:
                        return this.M13;
                    case 9:
                        return this.M23;
                    case 10:
                        return this.M33;
                    case 11:
                        return this.M43;
                    case 12:
                        return this.M14;
                    case 13:
                        return this.M24;
                    case 14:
                        return this.M34;
                    case 15:
                        return this.M44;
                    default:
                        throw new IndexOutOfRangeException("get Invalid matrix row:" + row+ ",column:"+ column);
                }
            }
            set
            {
                int index = row + column * 4;
                switch (index)
                {
                    case 0:
                        this.M11 = value;
                        break;
                    case 1:
                        this.M21 = value;
                        break;
                    case 2:
                        this.M31 = value;
                        break;
                    case 3:
                        this.M41 = value;
                        break;
                    case 4:
                        this.M12 = value;
                        break;
                    case 5:
                        this.M22 = value;
                        break;
                    case 6:
                        this.M32 = value;
                        break;
                    case 7:
                        this.M42 = value;
                        break;
                    case 8:
                        this.M13 = value;
                        break;
                    case 9:
                        this.M23 = value;
                        break;
                    case 10:
                        this.M33 = value;
                        break;
                    case 11:
                        this.M43 = value;
                        break;
                    case 12:
                        this.M14 = value;
                        break;
                    case 13:
                        this.M24 = value;
                        break;
                    case 14:
                        this.M34 = value;
                        break;
                    case 15:
                        this.M44 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("set Invalid matrix row:" + row + ",column:" + column);
                }
            }
        }

        public TSVector4 this[int index]
        {
            get
            {
                TSVector4 result;
                switch (index)
                {
                    case 0:
                        result.x = M11;
                        result.y = M12;
                        result.z = M13;
                        result.w = M14;

                        return result;
                    case 1:

                        result.x = M21;
                        result.y = M22;
                        result.z = M23;
                        result.w = M24;

                        return result;
                    case 2:
                        result.x = M31;
                        result.y = M32;
                        result.z = M33;
                        result.w = M34;

                        return result;
                    case 3:
                        result.x = M41;
                        result.y = M42;
                        result.z = M43;
                        result.w = M44;

                        return result;
                    default:
                        throw new IndexOutOfRangeException("get Invalid matrix index:" + index);
                }
            }
            set
            {
                if (index < 0 || index >= 4)
                    throw new IndexOutOfRangeException("set Invalid matrix index!");


                switch (index)
                {
                    case 0:
                        M11 = value.x;
                        M12 = value.y;
                        M13 = value.z;
                        M14 = value.w;
                        break;
                    case 1:
                        M21 = value.x;
                        M22 = value.y;
                        M23 = value.z;
                        M24 = value.w;
                        break;
                    case 2:
                        M31 = value.x;
                        M32 = value.y;
                        M33 = value.z;
                        M34 = value.w;
                        break;
                    case 3:
                        M41 = value.x;
                        M42 = value.y;
                        M43 = value.z;
                        M44 = value.w;
                        break;

                    default:
                        throw new IndexOutOfRangeException("set Invalid matrix index:"+index);
                }
            }
        }

        public TSVector4 GetColumn(int index)
        {
            //if (i < 0 || i >= 4)
            //{
            //    throw new IndexOutOfRangeException("Invalid matrix column:" + i);
            //}
            //return new TSVector4(this[0][i], this[1][i], this[2][i], this[3][i]);


            TSVector4 result;
            switch (index)
            {
                case 0:
                    result.x = M11;
                    result.y = M21;
                    result.z = M31;
                    result.w = M41;

                    return result;
                case 1:

                    result.x = M12;
                    result.y = M22;
                    result.z = M32;
                    result.w = M42;

                    return result;
                case 2:
                    result.x = M13;
                    result.y = M23;
                    result.z = M33;
                    result.w = M43;

                    return result;
                case 3:
                    result.x = M14;
                    result.y = M24;
                    result.z = M34;
                    result.w = M44;

                    return result;
                default:
                    throw new IndexOutOfRangeException("get Invalid matrix index:" + index);
            }
        }

        public TSVector4 GetRow(int index)
        {
            TSVector4 result;
            switch (index)
            {
                case 0:
                    result.x = M11;
                    result.y = M12;
                    result.z = M13;
                    result.w = M14;

                    return result;
                case 1:

                    result.x = M21;
                    result.y = M22;
                    result.z = M23;
                    result.w = M24;

                    return result;
                case 2:
                    result.x = M31;
                    result.y = M32;
                    result.z = M33;
                    result.w = M34;

                    return result;
                case 3:
                    result.x = M41;
                    result.y = M42;
                    result.z = M43;
                    result.w = M44;

                    return result;
                default:
                    throw new IndexOutOfRangeException("get Invalid matrix index:" + index);
            }

        }

        public TSMatrix4x4 inverse
        {
            get
            {
                return TSMatrix4x4.Inverse(ref this);
            }
        }

        public TSMatrix4x4 transpose
        {
            get
            {
                return TSMatrix4x4.Transpose(ref this);
            }
        }

        public bool isIdentity
        {
            get
            {
                return this == identity;
            }
        }

        public FP determinant
        {
            get
            {
                return TSMatrix4x4.Determinant(ref this);
            }
        }

        public static TSMatrix4x4 zero
        {
            get
            {
                return Zero;
            }
        }

        public static TSMatrix4x4 identity
        {
            get
            {
                return Identity;
            }
        }

        public override int GetHashCode()
        {
            return M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M14.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M24.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode() ^
                M34.GetHashCode() ^
                M41.GetHashCode() ^
                M42.GetHashCode() ^
                M43.GetHashCode() ^
                M44.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is TSMatrix4x4))
            {
                return false;
            }
            TSMatrix4x4 matrix4x = (TSMatrix4x4)other;

            return M11 == matrix4x.M11 &&
                M12 == matrix4x.M12 &&
                M13 == matrix4x.M13 &&
                M14 == matrix4x.M14 &&
                M21 == matrix4x.M21 &&
                M22 == matrix4x.M22 &&
                M23 == matrix4x.M23 &&
                M24 == matrix4x.M24 &&
                M31 == matrix4x.M31 &&
                M32 == matrix4x.M32 &&
                M33 == matrix4x.M33 &&
                M34 == matrix4x.M34 &&
                M41 == matrix4x.M41 &&
                M42 == matrix4x.M42 &&
                M43 == matrix4x.M43 &&
                M44 == matrix4x.M44;
        }

        public static TSMatrix4x4 Inverse(ref TSMatrix4x4 m)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Inverse(ref m, out result);
            return result;
        }
        private static void Inverse(ref TSMatrix4x4 matrix, out TSMatrix4x4 result)
        {
            FP num1 = matrix.M11;
            FP num2 = matrix.M12;
            FP num3 = matrix.M13;
            FP num4 = matrix.M14;
            FP num5 = matrix.M21;
            FP num6 = matrix.M22;
            FP num7 = matrix.M23;
            FP num8 = matrix.M24;
            FP num9 = matrix.M31;
            FP num10 = matrix.M32;
            FP num11 = matrix.M33;
            FP num12 = matrix.M34;
            FP num13 = matrix.M41;
            FP num14 = matrix.M42;
            FP num15 = matrix.M43;
            FP num16 = matrix.M44;
            FP num17 = (num11 * num16 - num12 * num15);
            FP num18 = (num10 * num16 - num12 * num14);
            FP num19 = (num10 * num15 - num11 * num14);
            FP num20 = (num9 * num16 - num12 * num13);
            FP num21 = (num9 * num15 - num11 * num13);
            FP num22 = (num9 * num14 - num10 * num13);
            FP num23 = (num6 * num17 - num7 * num18 + num8 * num19);
            FP num24 = -(num5 * num17 - num7 * num20 + num8 * num21);
            FP num25 = (num5 * num18 - num6 * num20 + num8 * num22);
            FP num26 = -(num5 * num19 - num6 * num21 + num7 * num22);
            FP detValue = (num1 * num23 + num2 * num24 + num3 * num25 + num4 * num26);


            if (detValue == 0)
            {
                result.M11 = FP.PositiveInfinity;
                result.M12 = FP.PositiveInfinity;
                result.M13 = FP.PositiveInfinity;
                result.M14 = FP.PositiveInfinity;

                result.M21 = FP.PositiveInfinity;
                result.M22 = FP.PositiveInfinity;
                result.M23 = FP.PositiveInfinity;
                result.M24 = FP.PositiveInfinity;

                result.M31 = FP.PositiveInfinity;
                result.M32 = FP.PositiveInfinity;
                result.M33 = FP.PositiveInfinity;
                result.M34 = FP.PositiveInfinity;

                result.M41 = FP.PositiveInfinity;
                result.M42 = FP.PositiveInfinity;
                result.M43 = FP.PositiveInfinity;
                result.M44 = FP.PositiveInfinity;
            }
            else
            {

                result.M11 = num23 / detValue;
                result.M21 = num24 / detValue;
                result.M31 = num25 / detValue;
                result.M41 = num26 / detValue;
                result.M12 = -(num2 * num17 - num3 * num18 + num4 * num19) / detValue;
                result.M22 = (num1 * num17 - num3 * num20 + num4 * num21) / detValue;
                result.M32 = -(num1 * num18 - num2 * num20 + num4 * num22) / detValue;
                result.M42 = (num1 * num19 - num2 * num21 + num3 * num22) / detValue;
                FP num28 = (num7 * num16 - num8 * num15);
                FP num29 = (num6 * num16 - num8 * num14);
                FP num30 = (num6 * num15 - num7 * num14);
                FP num31 = (num5 * num16 - num8 * num13);
                FP num32 = (num5 * num15 - num7 * num13);
                FP num33 = (num5 * num14 - num6 * num13);
                result.M13 = (num2 * num28 - num3 * num29 + num4 * num30) / detValue;
                result.M23 = -(num1 * num28 - num3 * num31 + num4 * num32) / detValue;
                result.M33 = (num1 * num29 - num2 * num31 + num4 * num33) / detValue;
                result.M43 = -(num1 * num30 - num2 * num32 + num3 * num33) / detValue;
                FP num34 = (num7 * num12 - num8 * num11);
                FP num35 = (num6 * num12 - num8 * num10);
                FP num36 = (num6 * num11 - num7 * num10);
                FP num37 = (num5 * num12 - num8 * num9);
                FP num38 = (num5 * num11 - num7 * num9);
                FP num39 = (num5 * num10 - num6 * num9);
                result.M14 = -(num2 * num34 - num3 * num35 + num4 * num36) / detValue;
                result.M24 = (num1 * num34 - num3 * num37 + num4 * num38) / detValue;
                result.M34 = -(num1 * num35 - num2 * num37 + num4 * num39) / detValue;
                result.M44 = (num1 * num36 - num2 * num38 + num3 * num39) / detValue;
            }
        }

        public static TSMatrix4x4 Transpose(ref TSMatrix4x4 m)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Inverse(ref m, out result);
            return result;
        }

        public TSVector GetPosition()
        {
            return GetColumn(3);
        }
        public TSQuaternion GetRotation()
        {
            return TSQuaternion.LookRotation(GetColumn(2), GetColumn(1));
        }
        public TSVector GetScale()
        {
            return new TSVector(GetColumn(0).magnitude, GetColumn(1).magnitude, GetColumn(2).magnitude);
        }
        private static void Transpose(ref TSMatrix4x4 matrix, out TSMatrix4x4 result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;

            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;

            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;

            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }

        internal static void Invert(TSMatrix4x4 inMatrix, out TSMatrix4x4 result)
        {
            TSMatrix4x4.Inverse(ref inMatrix, out result);
        }

        public static FP Determinant(ref TSMatrix4x4 matrix)
        {
            return matrix.M11 * matrix.M22 * matrix.M33 * matrix.M44 + matrix.M11 * matrix.M23 * matrix.M34 * matrix.M42 + matrix.M11 * matrix.M24 * matrix.M32 * matrix.M43
                            + matrix.M12 * matrix.M21 * matrix.M34 * matrix.M43 + matrix.M12 * matrix.M23 * matrix.M31 * matrix.M44 + matrix.M12 * matrix.M24 * matrix.M33 * matrix.M41
                            + matrix.M13 * matrix.M21 * matrix.M32 * matrix.M44 + matrix.M13 * matrix.M22 * matrix.M34 * matrix.M41 + matrix.M13 * matrix.M24 * matrix.M31 * matrix.M42
                            + matrix.M14 * matrix.M21 * matrix.M33 * matrix.M42 + matrix.M14 * matrix.M22 * matrix.M31 * matrix.M43 + matrix.M14 * matrix.M23 * matrix.M32 * matrix.M41
                            - matrix.M11 * matrix.M22 * matrix.M34 * matrix.M43 - matrix.M11 * matrix.M23 * matrix.M32 * matrix.M44 - matrix.M11 * matrix.M24 * matrix.M33 * matrix.M42
                            - matrix.M12 * matrix.M21 * matrix.M33 * matrix.M44 - matrix.M12 * matrix.M23 * matrix.M34 * matrix.M41 - matrix.M12 * matrix.M24 * matrix.M31 * matrix.M43
                            - matrix.M13 * matrix.M21 * matrix.M34 * matrix.M42 - matrix.M13 * matrix.M22 * matrix.M31 * matrix.M44 - matrix.M13 * matrix.M24 * matrix.M32 * matrix.M41
                            - matrix.M14 * matrix.M21 * matrix.M32 * matrix.M43 - matrix.M14 * matrix.M22 * matrix.M33 * matrix.M41 - matrix.M14 * matrix.M23 * matrix.M31 * matrix.M42;

        }

        public void SetColumn(int i, TSVector4 v)
        {
            this[0, i] = v.x;
            this[1, i] = v.y;
            this[2, i] = v.z;
            this[3, i] = v.w;
        }

        public void SetRow(int i, TSVector4 v)
        {
            this[i, 0] = v.x;
            this[i, 1] = v.y;
            this[i, 2] = v.z;
            this[i, 3] = v.w;
        }
        //public void SetTRS(TSVector pos, TSQuaternion q, TSVector s)
        //{
        //    //this = TSMatrix4x4.TRS(pos, q, s);
        //}
        //public static Matrix4x4 TRS(TSVector pos, TSQuaternion q, TSVector s)
        //{
        //    Matrix4x4 result;
        //    //Matrix4x4.INTERNAL_CALL_TRS(ref pos, ref q, ref s, out result);
        //    return result;
        //}
        public TSVector MultiplyPoint(TSVector v)
        {
            TSVector result;
            result.x = this.M11 * v.x + this.M12 * v.y + this.M13 * v.z + this.M14;
            result.y = this.M21 * v.x + this.M22 * v.y + this.M23 * v.z + this.M24;
            result.z = this.M31 * v.x + this.M32 * v.y + this.M33 * v.z + this.M34;
            FP num = this.M41 * v.x + this.M42 * v.y + this.M43 * v.z + this.M44;
            //num = FP.One / num;
            result.x /= num;
            result.y /= num;
            result.z /= num;
            return result;
        }

        public TSVector MultiplyPoint3x4(TSVector v)
        {
            TSVector result;
            result.x = this.M11 * v.x + this.M12 * v.y + this.M13 * v.z + this.M14;
            result.y = this.M21 * v.x + this.M22 * v.y + this.M23 * v.z + this.M24;
            result.z = this.M31 * v.x + this.M32 * v.y + this.M33 * v.z + this.M34;
            return result;
        }

        public TSVector MultiplyPoint3x4(ref TSVector v)
        {
            TSVector result;
            result.x = this.M11 * v.x + this.M12 * v.y + this.M13 * v.z + this.M14;
            result.y = this.M21 * v.x + this.M22 * v.y + this.M23 * v.z + this.M24;
            result.z = this.M31 * v.x + this.M32 * v.y + this.M33 * v.z + this.M34;
            return result;
        }


        public TSVector MultiplyVector(TSVector v)
        {
            TSVector result;
            result.x = this.M11 * v.x + this.M12 * v.y + this.M13 * v.z;
            result.y = this.M21 * v.x + this.M22 * v.y + this.M23 * v.z;
            result.z = this.M31 * v.x + this.M32 * v.y + this.M33 * v.z;
            return result;
        }
        public TSVector MultiplyVector(ref TSVector v)
        {
            TSVector result;
            result.x = this.M11 * v.x + this.M12 * v.y + this.M13 * v.z;
            result.y = this.M21 * v.x + this.M22 * v.y + this.M23 * v.z;
            result.z = this.M31 * v.x + this.M32 * v.y + this.M33 * v.z;
            return result;
        }
        public static TSMatrix4x4 Scale(TSVector v)
        {
            return new TSMatrix4x4
            {
                M11 = v.x,
                M12 = FP.Zero,
                M13 = FP.Zero,
                M14 = FP.Zero,
                M21 = FP.Zero,
                M22 = v.y,
                M23 = FP.Zero,
                M24 = FP.Zero,
                M31 = FP.Zero,
                M32 = FP.Zero,
                M33 = v.z,
                M34 = FP.Zero,
                M41 = FP.Zero,
                M42 = FP.Zero,
                M43 = FP.Zero,
                M44 = FP.One
            };
        }

        public override string ToString()
        {
            return string.Format("{0:F5}\t{1:F5}\t{2:F5}\t{3:F5}\n{4:F5}\t{5:F5}\t{6:F5}\t{7:F5}\n{8:F5}\t{9:F5}\t{10:F5}\t{11:F5}\n{12:F5}\t{13:F5}\t{14:F5}\t{15:F5}\n", new object[]
            {
                this.M11,
                this.M12,
                this.M13,
                this.M14,
                this.M21,
                this.M22,
                this.M23,
                this.M24,
                this.M31,
                this.M32,
                this.M33,
                this.M34,
                this.M41,
                this.M42,
                this.M43,
                this.M44
            });
        }


        public static TSMatrix4x4 operator *(TSMatrix4x4 lhs, TSMatrix4x4 rhs)
        {
            TSMatrix4x4 result;
            result.M11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31 + lhs.M14 * rhs.M41;
            result.M12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32 + lhs.M14 * rhs.M42;
            result.M13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33 + lhs.M14 * rhs.M43;
            result.M14 = lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34 + lhs.M14 * rhs.M44;
            result.M21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31 + lhs.M24 * rhs.M41;
            result.M22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32 + lhs.M24 * rhs.M42;
            result.M23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33 + lhs.M24 * rhs.M43;
            result.M24 = lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34 + lhs.M24 * rhs.M44;
            result.M31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31 + lhs.M34 * rhs.M41;
            result.M32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32 + lhs.M34 * rhs.M42;
            result.M33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33 + lhs.M34 * rhs.M43;
            result.M34 = lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34 + lhs.M34 * rhs.M44;
            result.M41 = lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31 + lhs.M44 * rhs.M41;
            result.M42 = lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32 + lhs.M44 * rhs.M42;
            result.M43 = lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33 + lhs.M44 * rhs.M43;
            result.M44 = lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34 + lhs.M44 * rhs.M44;
            return result;
        }

        public static TSMatrix4x4 operator *(TSMatrix4x4 lhs, FP rhs)
        {
            //TSMatrix4x4 result = lhs;

            lhs.M11 *= rhs;
            lhs.M12 *= rhs;
            lhs.M13 *= rhs;
            lhs.M14 *= rhs;

            lhs.M21 *= rhs;
            lhs.M22 *= rhs;
            lhs.M23 *= rhs;
            lhs.M24 *= rhs;

            lhs.M31 *= rhs;
            lhs.M32 *= rhs;
            lhs.M33 *= rhs;
            lhs.M34 *= rhs;

            lhs.M41 *= rhs;
            lhs.M42 *= rhs;
            lhs.M43 *= rhs;
            lhs.M44 *= rhs;

            return lhs;
        }

        public static TSMatrix4x4 operator *(FP rhs,TSMatrix4x4 lhs)
        {
            lhs.M11 *= rhs;
            lhs.M12 *= rhs;
            lhs.M13 *= rhs;
            lhs.M14 *= rhs;

            lhs.M21 *= rhs;
            lhs.M22 *= rhs;
            lhs.M23 *= rhs;
            lhs.M24 *= rhs;

            lhs.M31 *= rhs;
            lhs.M32 *= rhs;
            lhs.M33 *= rhs;
            lhs.M34 *= rhs;

            lhs.M41 *= rhs;
            lhs.M42 *= rhs;
            lhs.M43 *= rhs;
            lhs.M44 *= rhs;

            return lhs;
        }

        //public static Vector4 operator *(Matrix4x4 lhs, Vector4 v)
        //{
        //    Vector4 result;
        //    result.x = lhs.m00 * v.x + lhs.m01 * v.y + lhs.m02 * v.z + lhs.m03 * v.w;
        //    result.y = lhs.m10 * v.x + lhs.m11 * v.y + lhs.m12 * v.z + lhs.m13 * v.w;
        //    result.z = lhs.m20 * v.x + lhs.m21 * v.y + lhs.m22 * v.z + lhs.m23 * v.w;
        //    result.w = lhs.m30 * v.x + lhs.m31 * v.y + lhs.m32 * v.z + lhs.m33 * v.w;
        //    return result;
        //}

        public static bool operator ==(TSMatrix4x4 lhs, TSMatrix4x4 matrix4x)
        {
            return lhs.M11 == matrix4x.M11 &&
                lhs.M12 == matrix4x.M12 &&
                lhs.M13 == matrix4x.M13 &&
                lhs.M14 == matrix4x.M14 &&
                lhs.M21 == matrix4x.M21 &&
                lhs.M22 == matrix4x.M22 &&
                lhs.M23 == matrix4x.M23 &&
                lhs.M24 == matrix4x.M24 &&
                lhs.M31 == matrix4x.M31 &&
                lhs.M32 == matrix4x.M32 &&
                lhs.M33 == matrix4x.M33 &&
                lhs.M34 == matrix4x.M34 &&
                lhs.M41 == matrix4x.M41 &&
                lhs.M42 == matrix4x.M42 &&
                lhs.M43 == matrix4x.M43 &&
                lhs.M44 == matrix4x.M44;
        }

        public static bool operator !=(TSMatrix4x4 lhs, TSMatrix4x4 rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// 构造转换矩阵
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="q"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static TSMatrix4x4 TRS(TSVector P, TSQuaternion Q, TSVector S)
        {
            TSMatrix4x4 result;

            FP xx = Q.x * Q.x;
            FP yy = Q.y * Q.y;
            FP zz = Q.z * Q.z;

            FP xy = Q.x * Q.y;
            FP wz = Q.z * Q.w;
            FP xz = Q.z * Q.x;
            FP wy = Q.y * Q.w;
            FP yz = Q.y * Q.z;
            FP wx = Q.x * Q.w;

            FP t = yy + zz;
            result.M11 = (FP.One - t - t) * S.x;
            t = xy - wz;
            result.M12 = (t + t) * S.y;
            t = xz + wy;
            result.M13 = (t + t) * S.z;
            result.M14 = P.x;

            t = xy + wz;
            result.M21 = (t + t) * S.x;
            t = zz + xx;
            result.M22 = (FP.One - t - t) * S.y;
            t = yz - wx;
            result.M23 = (t + t) * S.z;
            result.M24 = P.y;

            t = xz - wy;
            result.M31 = (t + t) * S.x;
            t = yz + wx;
            result.M32 = (t + t) * S.y;
            t = yy + xx;
            result.M33 = (FP.One - t - t) * S.z;
            result.M34 = P.z;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
            //return CreateTranslation(pos) * CreateFromQuaternion(q) * CreateScale(s);
        }

    
        /// <summary>
        /// Q11*Sx,Q12*Sy,Q13Sz,Px
        /// Q21*Sx,Q22*Sy,Q23Sz,Py
        /// Q31*Sx,Q32*Sy,Q33Sz,Pz
        /// 0     ,0     ,0    ,1
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public static TSMatrix4x4 TRS(ref TSVector P, ref TSQuaternion Q, ref TSVector S)
        {
            TSMatrix4x4 result;

            FP xx = Q.x * Q.x;
            FP yy = Q.y * Q.y;
            FP zz = Q.z * Q.z;

            FP xy = Q.x * Q.y;
            FP wz = Q.z * Q.w;
            FP xz = Q.z * Q.x;
            FP wy = Q.y * Q.w;
            FP yz = Q.y * Q.z;
            FP wx = Q.x * Q.w;

            result.M11 = (FP.One - 2 * (yy + zz))*S.x;
            result.M12 = (2 * (xy - wz))*S.y;
            result.M13 =( 2 * (xz + wy))*S.z;
            result.M14 = P.x;

            result.M21 = (2 * (xy + wz))*S.x;
            result.M22 = (FP.One - 2 * (zz + xx))*S.y;
            result.M23 = (2 * (yz - wx))*S.z;
            result.M24 = P.y;

            result.M31 =( 2 * (xz - wy))*S.x;
            result.M32 = (2 * (yz + wx))*S.y;
            result.M33 =( FP.One - 2 * (yy + xx))*S.z;
            result.M34 = P.z;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }


        public static void TRS(ref TSVector P, ref TSQuaternion Q, ref TSVector S ,out TSMatrix4x4 result)
        {
            FP xx = Q.x * Q.x;
            FP yy = Q.y * Q.y;
            FP zz = Q.z * Q.z;

            FP xy = Q.x * Q.y;
            FP wz = Q.z * Q.w;
            FP xz = Q.z * Q.x;
            FP wy = Q.y * Q.w;
            FP yz = Q.y * Q.z;
            FP wx = Q.x * Q.w;

            result.M11 = (FP.One - 2 * (yy + zz)) * S.x;
            result.M12 = (2 * (xy - wz)) * S.y;
            result.M13 = (2 * (xz + wy)) * S.z;
            result.M14 = P.x;

            result.M21 = (2 * (xy + wz)) * S.x;
            result.M22 = (FP.One - 2 * (zz + xx)) * S.y;
            result.M23 = (2 * (yz - wx)) * S.z;
            result.M24 = P.y;

            result.M31 = (2 * (xz - wy)) * S.x;
            result.M32 = (2 * (yz + wx)) * S.y;
            result.M33 = (FP.One - 2 * (yy + xx)) * S.z;
            result.M34 = P.z;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="q"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static TSMatrix4x4 RS(ref TSQuaternion Q, ref TSVector S)
        {
            TSMatrix4x4 result;

            FP xx = Q.x * Q.x;
            FP yy = Q.y * Q.y;
            FP zz = Q.z * Q.z;

            FP xy = Q.x * Q.y;
            FP wz = Q.z * Q.w;
            FP xz = Q.z * Q.x;
            FP wy = Q.y * Q.w;
            FP yz = Q.y * Q.z;
            FP wx = Q.x * Q.w;

            result.M11 = (FP.One - 2 * (yy + zz)) * S.x;
            result.M12 = (2 * (xy - wz)) * S.y;
            result.M13 = (2 * (xz + wy)) * S.z;
            result.M14 = FP.Zero;

            result.M21 = (2 * (xy + wz)) * S.x;
            result.M22 = (FP.One - 2 * (zz + xx)) * S.y;
            result.M23 = (2 * (yz - wx)) * S.z;
            result.M24 = FP.Zero;

            result.M31 = (2 * (xz - wy)) * S.x;
            result.M32 = (2 * (yz + wx)) * S.y;
            result.M33 = (FP.One - 2 * (yy + xx)) * S.z;
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
            //return CreateTranslation(pos) * CreateFromQuaternion(q) * CreateScale(s);
        }


        public static void RS(ref TSQuaternion Q, ref TSVector S, out TSMatrix4x4 result)
        {

            FP xx = Q.x * Q.x;
            FP yy = Q.y * Q.y;
            FP zz = Q.z * Q.z;

            FP xy = Q.x * Q.y;
            FP wz = Q.z * Q.w;
            FP xz = Q.z * Q.x;
            FP wy = Q.y * Q.w;
            FP yz = Q.y * Q.z;
            FP wx = Q.x * Q.w;

            result.M11 = (FP.One - 2 * (yy + zz)) * S.x;
            result.M12 = (2 * (xy - wz)) * S.y;
            result.M13 = (2 * (xz + wy)) * S.z;
            result.M14 = FP.Zero;

            result.M21 = (2 * (xy + wz)) * S.x;
            result.M22 = (FP.One - 2 * (zz + xx)) * S.y;
            result.M23 = (2 * (yz - wx)) * S.z;
            result.M24 = FP.Zero;

            result.M31 = (2 * (xz - wy)) * S.x;
            result.M32 = (2 * (yz + wx)) * S.y;
            result.M33 = (FP.One - 2 * (yy + xx)) * S.z;
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            //return CreateTranslation(pos) * CreateFromQuaternion(q) * CreateScale(s);
        }
        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="position">The amount to translate in each axis.</param>
        /// <returns>The translation matrix.</returns>
        public static TSMatrix4x4 CreateTranslation(TSVector position)
        {
            TSMatrix4x4 result;

            result.M11 = FP.One;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = position.x;

            result.M21 = FP.Zero;
            result.M22 = FP.One;
            result.M23 = FP.Zero;
            result.M24 = position.y;

            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = FP.One;
            result.M34 = position.z;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        public static void CreateTranslation(ref TSVector position, ref TSMatrix4x4 result)
        {
            result.M11 = FP.One;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = position.x;

            result.M21 = FP.Zero;
            result.M22 = FP.One;
            result.M23 = FP.Zero;
            result.M24 = position.y;

            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = FP.One;
            result.M34 = position.z;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }

        /// <summary>
        /// Creates a rotation matrix from the given Quaternion rotation value.
        /// </summary>
        /// <param name="quaternion">The source Quaternion.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateFromQuaternion(TSQuaternion quaternion)
        {
            TSMatrix4x4 result;

            FP xx = quaternion.x * quaternion.x;
            FP yy = quaternion.y * quaternion.y;
            FP zz = quaternion.z * quaternion.z;

            FP xy = quaternion.x * quaternion.y;
            FP wz = quaternion.z * quaternion.w;
            FP xz = quaternion.z * quaternion.x;
            FP wy = quaternion.y * quaternion.w;
            FP yz = quaternion.y * quaternion.z;
            FP wx = quaternion.x * quaternion.w;

            result.M11 = FP.One - 2 * (yy + zz);
            result.M12 = 2 * (xy - wz);
            result.M13 = 2 * (xz + wy);
            result.M14 = FP.Zero;

            result.M21 = 2 * (xy + wz);
            result.M22 = FP.One - 2 * (zz + xx);
            result.M23 = 2 * (yz - wx);
            result.M24 = FP.Zero;

            result.M31 = 2 * (xz - wy);
            result.M32 = 2 * (yz + wx);
            result.M33 = FP.One - 2 * (yy + xx);
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        public static void CreateFromQuaternion(ref TSQuaternion quaternion, ref TSMatrix4x4 result)
        {
            FP xx = quaternion.x * quaternion.x;
            FP yy = quaternion.y * quaternion.y;
            FP zz = quaternion.z * quaternion.z;

            FP xy = quaternion.x * quaternion.y;
            FP wz = quaternion.z * quaternion.w;
            FP xz = quaternion.z * quaternion.x;
            FP wy = quaternion.y * quaternion.w;
            FP yz = quaternion.y * quaternion.z;
            FP wx = quaternion.x * quaternion.w;

            result.M11 = FP.One - 2 * (yy + zz);
            result.M12 = 2 * (xy - wz);
            result.M13 = 2 * (xz + wy);
            result.M14 = FP.Zero;

            result.M21 = 2 * (xy + wz);
            result.M22 = FP.One - 2 * (zz + xx);
            result.M23 = 2 * (yz - wx);
            result.M24 = FP.Zero;

            result.M31 = 2 * (xz - wy);
            result.M32 = 2 * (yz + wx);
            result.M33 = FP.One - 2 * (yy + xx);
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }


        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        /// <param name="scales">The vector containing the amount to scale by on each axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(TSVector scales)
        {
            TSMatrix4x4 result;

            result.M11 = scales.x;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;

            result.M21 = FP.Zero;
            result.M22 = scales.y;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;

            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = scales.z;
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        public static void CreateScale(ref TSVector scales, ref TSMatrix4x4 result)
        {
            result.M11 = scales.x;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;

            result.M21 = FP.Zero;
            result.M22 = scales.y;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;

            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = scales.z;
            result.M34 = FP.Zero;

            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }

        /// <summary>
        /// Creates a matrix that uniformally scales along all three axis.
        /// </summary>
        /// <param name="scale">The uniform scale that is applied along all axis.</param>
        /// <returns>The created scaling matrix.</returns>
        public static TSMatrix4x4 Scaling(FP scale)
        {
            TSMatrix4x4 result;
            Scaling(scale, out result);
            return result;
        }
        /// <summary>
        /// Creates a matrix that uniformally scales along all three axis.
        /// </summary>
        /// <param name="scale">The uniform scale that is applied along all axis.</param>
        /// <param name="result">When the method completes, contains the created scaling matrix.</param>
        public static void Scaling(FP scale, out TSMatrix4x4 result)
        {
            result = TSMatrix4x4.Identity;
            result.M11 = result.M22 = result.M33 = scale;
        }
        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <param name="result">When the method completes, contains the created affine transformation matrix.</param>
        public static void AffineTransformation(FP scaling, ref TSQuaternion rotation, ref TSVector translation, out TSMatrix4x4 result)
        {
            result = Scaling(scaling) * RotationQuaternion(rotation) * Translation(translation);
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <returns>The created affine transformation matrix.</returns>
        public static TSMatrix4x4 AffineTransformation(FP scaling, TSQuaternion rotation, TSVector translation)
        {
            TSMatrix4x4 result;
            AffineTransformation(scaling, ref rotation, ref translation, out result);
            return result;
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <param name="result">When the method completes, contains the created affine transformation matrix.</param>
        public static void AffineTransformation(FP scaling, ref TSVector rotationCenter, ref TSQuaternion rotation, ref TSVector translation, out TSMatrix4x4 result)
        {
            result = Scaling(scaling) * Translation(-rotationCenter) * RotationQuaternion(rotation) *
                Translation(rotationCenter) * Translation(translation);
        }


        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="value">The offset for all three coordinate planes.</param>
        /// <returns>The created translation matrix.</returns>
        public static TSMatrix4x4 Translation(TSVector value)
        {
            TSMatrix4x4 result;
            Translation(ref value, out result);
            return result;
        }
        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="value">The offset for all three coordinate planes.</param>
        /// <param name="result">When the method completes, contains the created translation matrix.</param>
        public static void Translation(ref TSVector value, out TSMatrix4x4 result)
        {
            Translation(value.x, value.y, value.z, out result);
        }

        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="x">X-coordinate offset.</param>
        /// <param name="y">Y-coordinate offset.</param>
        /// <param name="z">Z-coordinate offset.</param>
        /// <param name="result">When the method completes, contains the created translation matrix.</param>
        public static void Translation(FP x, FP y, FP z, out TSMatrix4x4 result)
        {
            result = TSMatrix4x4.Identity;
            result.M14 = x;
            result.M24 = y;
            result.M34 = z;
        }
        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <returns>The created affine transformation matrix.</returns>
        public static TSMatrix4x4 AffineTransformation(FP scaling, TSVector rotationCenter, TSQuaternion rotation, TSVector translation)
        {
            TSMatrix4x4 result;
            AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="rotation">The quaternion to use to build the matrix.</param>
        /// <returns>The created rotation matrix.</returns>
        public static TSMatrix4x4 RotationQuaternion(TSQuaternion rotation)
        {
            TSMatrix4x4 result;
            RotationQuaternion(ref rotation, out result);
            return result;
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="rotation">The quaternion to use to build the matrix.</param>
        /// <param name="result">The created rotation matrix.</param>
        public static void RotationQuaternion(ref TSQuaternion rotation, out TSMatrix4x4 result)
        {
            FP xx = rotation.x * rotation.x;
            FP yy = rotation.y * rotation.y;
            FP zz = rotation.z * rotation.z;
            FP xy = rotation.x * rotation.y;
            FP zw = rotation.z * rotation.w;
            FP zx = rotation.z * rotation.x;
            FP yw = rotation.y * rotation.w;
            FP yz = rotation.y * rotation.z;
            FP xw = rotation.x * rotation.w;

            result = TSMatrix4x4.Identity;
            result.M11 = FP.One - (2 * (yy + zz));
            result.M12 = 2 * (xy + zw);
            result.M13 = 2 * (zx - yw);
            result.M21 = 2 * (xy - zw);
            result.M22 = FP.One - (2 * (zz + xx));
            result.M23 = 2 * (yz + xw);
            result.M31 = 2 * (zx + yw);
            result.M32 = 2 * (yz - xw);
            result.M33 = FP.One - (2 * (yy + xx));
        }
    }
}
#endif