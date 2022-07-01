/* Copyright (C) <2009-2011> <Thorben Linneweber, Jitter Physics>
*
* 
*  This software is provided 'as-is', without any express or implied
*  warranty.  In no event will the authors be held liable for any damages
*  arising from the use of this software.
*
*  Permission is granted to anyone to use this software for any purpose,
*  including commercial applications, and to alter it and redistribute it
*  freely, subject to the following restrictions:
*
*  1. The origin of this software must not be misrepresented; you must not
*      claim that you wrote the original software. If you use this software
*      in a product, an acknowledgment in the product documentation would be
*      appreciated but is not required.
*  2. Altered source versions must be plainly marked as such, and must not be
*      misrepresented as being the original software.
*  3. This notice may not be removed or altered from any source distribution.
*  3. This notice may not be removed or altered from any source distribution. 
*/

using System;
#if USEBATTLEDLL
#else
namespace TrueSync
{
    /// <summary>
    /// A vector structure.
    /// </summary>
    [Serializable]
    public struct TSVector
    {

        private static FP ZeroEpsilonSq = FP.Epsilon;
        internal static TSVector InternalZero;
        internal static TSVector Arbitrary;

        /// <summary>The X component of the vector.</summary>
        public FP x;
        /// <summary>The Y component of the vector.</summary>
        public FP y;
        /// <summary>The Z component of the vector.</summary>
        public FP z;

        #region Static readonly variables
        public static readonly TSVector initPos;
        /// <summary>
        /// A vector with components (0,0,0);
        /// </summary>
        public static readonly TSVector zero;
        /// <summary>
        /// A vector with components (-1,0,0);
        /// </summary>
        public static readonly TSVector left;
        /// <summary>
        /// A vector with components (1,0,0);
        /// </summary>
        public static readonly TSVector right;
        /// <summary>
        /// A vector with components (0,1,0);
        /// </summary>
        public static readonly TSVector up;
        /// <summary>
        /// A vector with components (0,-1,0);
        /// </summary>
        public static readonly TSVector down;
        /// <summary>
        /// A vector with components (0,0,-1);
        /// </summary>
        public static readonly TSVector back;
        /// <summary>
        /// A vector with components (0,0,1);
        /// </summary>
        public static readonly TSVector forward;
        /// <summary>
        /// A vector with components (1,1,1);
        /// </summary>
        public static readonly TSVector one;
        /// <summary>
        /// A vector with components
        /// (FP.MinValue,FP.MinValue,FP.MinValue);
        /// </summary>
        public static readonly TSVector MinValue;
        /// <summary>
        /// A vector with components
        /// (FP.MaxValue,FP.MaxValue,FP.MaxValue);
        /// </summary>
        public static readonly TSVector MaxValue;
        #endregion

        #region Private static constructor
        static TSVector()
        {
            initPos = new TSVector(-1, -1, -1) * 1000;
            one = new TSVector(1, 1, 1);
            zero = new TSVector(0, 0, 0);
            left = new TSVector(-1, 0, 0);
            right = new TSVector(1, 0, 0);
            up = new TSVector(0, 1, 0);
            down = new TSVector(0, -1, 0);
            back = new TSVector(0, 0, -1);
            forward = new TSVector(0, 0, 1);
            MinValue = new TSVector(FP.MinValue);
            MaxValue = new TSVector(FP.MaxValue);
            Arbitrary = new TSVector(1, 1, 1);
            InternalZero = zero;
        }
        #endregion

        public static TSVector Abs(TSVector other)
        {
            return Abs(ref other);
        }
        public static TSVector Abs(ref TSVector other)
        {
            return new TSVector(FP.Abs(other.x), FP.Abs(other.y), FP.Abs(other.z));
        }

        /// <summary>
        /// Gets the squared length of the vector.
        /// </summary>
        /// <returns>Returns the squared length of the vector.</returns>
        public FP sqrMagnitude
        {
            get
            {
                return (((this.x * this.x) + (this.y * this.y)) + (this.z * this.z));
            }
        }
        public TSVector Normalized()
        {
            return normalized;
        }
        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        /// <returns>Returns the length of the vector.</returns>
        public FP magnitude
        {
            get
            {
                return FP.Sqrt(((this.x * this.x) + (this.y * this.y)) + (this.z * this.z));
            }
        }

        public FP Length()
        {
            return magnitude;
        }

        //>
        public bool IsLengthMoreThan(FP value)
        {
            return sqrMagnitude > value * value;

            //if (value < FP.Zero)
            //{
            //    return true;
            //}

            //return FP.FastAbs(x) > value || FP.FastAbs(y) > value || FP.FastAbs(z) > value || (sqrMagnitude > value * value);
        }

        //<
        public bool IsLengthLessThan(FP value)
        {
            return sqrMagnitude < value * value;

            //if (value < FP.Zero)
            //{
            //    return false;
            //}

            //return FP.FastAbs(x) < value && FP.FastAbs(y) < value && FP.FastAbs(z) < value && (sqrMagnitude < value * value);

        }

        public bool IsLengthLessEqualThan(FP value)
        {
            return sqrMagnitude <= value * value;

            //if (value < FP.Zero)
            //{
            //    return false;
            //}

            //return FP.FastAbs(x) <= value && FP.FastAbs(y) <= value && FP.FastAbs(z) <= value && (sqrMagnitude <= value * value);

        }
        public static TSVector ClampMagnitude(TSVector vector, FP maxLength)
        {
            return Normalize(ref vector) * maxLength;
        }

        /// <summary>
        /// Gets a normalized version of the vector.
        /// </summary>
        /// <returns>Returns a normalized version of the vector.</returns>
        public TSVector normalized
        {
            get {
                TSVector result = new TSVector(this.x, this.y, this.z);
                result.Normalize();

                return result;
            }
        }

        /// <summary>
        /// Constructor initializing a new instance of the structure
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>

        public TSVector(int x, int y, int z)
        {
            this.x = (FP)x;
            this.y = (FP)y;
            this.z = (FP)z;
        }

        public TSVector(FP x, FP y, FP z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public TSVector(TSVector copy)
        {
            this.x = copy.x;
            this.y = copy.y;
            this.z = copy.z;
        }

        public static TSVector MoveTowards(TSVector current, TSVector target, FP maxDistanceDelta)
        {
            TSVector a = target - current;
            FP magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == FP.Zero)
            {
                return target;
            }
            return current + a / magnitude * maxDistanceDelta;
        }

        /// <summary>
        /// Multiplies each component of the vector by the same components of the provided vector.
        /// </summary>
        public void Scale(TSVector other)
        {
            this.x = x * other.x;
            this.y = y * other.y;
            this.z = z * other.z;
        }

        /// <summary>
        /// Sets all vector component to specific values.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        public void Set(FP x, FP y, FP z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructor initializing a new instance of the structure
        /// </summary>
        /// <param name="xyz">All components of the vector are set to xyz</param>
        public TSVector(FP xyz)
        {
            this.x = xyz;
            this.y = xyz;
            this.z = xyz;
        }

        public TSVector(FP xyz, FP v)
        {
            this.x = xyz;
            this.y = v;
            this.z = FP.Zero;
        }

        public static TSVector Lerp(TSVector from, TSVector to, FP percent)
        {
            return Lerp(ref from, ref to, percent);
        }

        public static TSVector Lerp(ref TSVector from, ref TSVector to, FP percent)
        {
            return from + (to - from) * FP.Clamp01(percent);
        }

        /// <summary>
        /// Tests if an object is equal to this vector.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>Returns true if they are euqal, otherwise false.</returns>
        #region public override bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (!(obj is TSVector))
            {
                return false;
            }
            TSVector other = (TSVector)obj;

            return (((x == other.x) && (y == other.y)) && (z == other.z));
        }
        #endregion

        /// <summary>
        /// Multiplies each component of the vector by the same components of the provided vector.
        /// </summary>
        public static TSVector Scale(TSVector vecA, TSVector vecB)
        {
            TSVector result;
            result.x = vecA.x * vecB.x;
            result.y = vecA.y * vecB.y;
            result.z = vecA.z * vecB.z;

            return result;
        }

        /// <summary>
        /// Tests if two JVector are equal.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns true if both values are equal, otherwise false.</returns>
        #region public static bool operator ==(JVector value1, JVector value2)
        public static bool operator ==(TSVector value1, TSVector value2)
        {
            return (((value1.x._serializedValue == value2.x._serializedValue) && (value1.y._serializedValue == value2.y._serializedValue)) && (value1.z._serializedValue == value2.z._serializedValue));
        }
        #endregion

        /// <summary>
        /// Tests if two JVector are not equal.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns false if both values are equal, otherwise true.</returns>
        #region public static bool operator !=(JVector value1, JVector value2)
        public static bool operator !=(TSVector value1, TSVector value2)
        {
            if ((value1.x._serializedValue == value2.x._serializedValue) && (value1.y._serializedValue == value2.y._serializedValue))
            {
                return (value1.z._serializedValue != value2.z._serializedValue);
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Gets a vector with the minimum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>A vector with the minimum x,y and z values of both vectors.</returns>
        #region public static JVector Min(JVector value1, JVector value2)

        public static TSVector Min(TSVector value1, TSVector value2)
        {
            TSVector result;
            TSVector.Min(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Gets a vector with the minimum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="result">A vector with the minimum x,y and z values of both vectors.</param>
        public static void Min(ref TSVector value1, ref TSVector value2, out TSVector result)
        {
            result.x = (value1.x < value2.x) ? value1.x : value2.x;
            result.y = (value1.y < value2.y) ? value1.y : value2.y;
            result.z = (value1.z < value2.z) ? value1.z : value2.z;
        }
        #endregion

        /// <summary>
        /// Gets a vector with the maximum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>A vector with the maximum x,y and z values of both vectors.</returns>
        #region public static JVector Max(JVector value1, JVector value2)
        public static TSVector Max(TSVector value1, TSVector value2)
        {
            TSVector result;
            TSVector.Max(ref value1, ref value2, out result);
            return result;
        }

        public static FP Distance(TSVector v1, TSVector v2)
        {
            return FP.Sqrt ((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z));
        }

        /// <summary>
        /// Gets a vector with the maximum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="result">A vector with the maximum x,y and z values of both vectors.</param>
        public static void Max(ref TSVector value1, ref TSVector value2, out TSVector result)
        {
            result.x = (value1.x > value2.x) ? value1.x : value2.x;
            result.y = (value1.y > value2.y) ? value1.y : value2.y;
            result.z = (value1.z > value2.z) ? value1.z : value2.z;
        }
        #endregion

        /// <summary>
        /// Sets the length of the vector to zero.
        /// </summary>
        #region public void MakeZero()
        public void MakeZero()
        {
            x = FP.Zero;
            y = FP.Zero;
            z = FP.Zero;
        }
        #endregion

        /// <summary>
        /// Checks if the length of the vector is zero.
        /// </summary>
        /// <returns>Returns true if the vector is zero, otherwise false.</returns>
        #region public bool IsZero()
        public bool IsZero()
        {
            return (this.sqrMagnitude == FP.Zero);
        }

        /// <summary>
        /// Checks if the length of the vector is nearly zero.
        /// </summary>
        /// <returns>Returns true if the vector is nearly zero, otherwise false.</returns>
        public bool IsNearlyZero()
        {
            return (this.sqrMagnitude < ZeroEpsilonSq);
        }
        #endregion

        /// <summary>
        /// Transforms a vector by the given matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <returns>The transformed vector.</returns>
        #region public static JVector Transform(JVector position, JMatrix matrix)
        public static TSVector Transform(TSVector position, TSMatrix matrix)
        {
            TSVector result;
            TSVector.Transform(ref position, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by the given matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref TSVector position, ref TSMatrix matrix, out TSVector result)
        {
            FP num0 = ((position.x * matrix.M11) + (position.y * matrix.M21)) + (position.z * matrix.M31);
            FP num1 = ((position.x * matrix.M12) + (position.y * matrix.M22)) + (position.z * matrix.M32);
            FP num2 = ((position.x * matrix.M13) + (position.y * matrix.M23)) + (position.z * matrix.M33);

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// Transforms a vector by the transposed of the given Matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <param name="result">The transformed vector.</param>
        public static void TransposedTransform(ref TSVector position, ref TSMatrix matrix, out TSVector result)
        {
            FP num0 = ((position.x * matrix.M11) + (position.y * matrix.M12)) + (position.z * matrix.M13);
            FP num1 = ((position.x * matrix.M21) + (position.y * matrix.M22)) + (position.z * matrix.M23);
            FP num2 = ((position.x * matrix.M31) + (position.y * matrix.M32)) + (position.z * matrix.M33);

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }
        #endregion

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>Returns the dot product of both vectors.</returns>
        #region public static FP Dot(JVector vector1, JVector vector2)

        public FP Dot(ref TSVector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public FP Dot(TSVector vector2)
        {
            return ((x * vector2.x) + (y * vector2.y)) + (z * vector2.z);
        }

        public static FP Dot(TSVector vector1, TSVector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y)) + (vector1.z * vector2.z);
        }
        /// <summary>
        /// Calculates the dot product of both vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>Returns the dot product of both vectors.</returns>
        public static FP Dot(ref TSVector vector1, ref TSVector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y)) + (vector1.z * vector2.z);
        }
        #endregion

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of both vectors.</returns>
        #region public static void Add(JVector value1, JVector value2)
        public static TSVector Add(TSVector value1, TSVector value2)
        {
            TSVector result;
            TSVector.Add(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Adds to vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The sum of both vectors.</param>
        public static void Add(ref TSVector value1, ref TSVector value2, out TSVector result)
        {
            result.x = value1.x + value2.x;
            result.y = value1.y + value2.y;
            result.z = value1.z + value2.z;
        }
        #endregion

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TSVector Divide(TSVector value1, FP scaleFactor)
        {
            TSVector result;
            TSVector.Divide(ref value1, scaleFactor, out result);
            return result;
        }

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">Returns the scaled vector.</param>
        public static void Divide(ref TSVector value1, FP scaleFactor, out TSVector result)
        {
            result.x = value1.x / scaleFactor;
            result.y = value1.y / scaleFactor;
            result.z = value1.z / scaleFactor;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The difference of both vectors.</returns>
        #region public static JVector Subtract(JVector value1, JVector value2)
        public static TSVector Subtract(TSVector value1, TSVector value2)
        {
            return Subtract(ref value1, ref value2);
        }
        public static TSVector Subtract(ref TSVector value1, ref TSVector value2)
        {
            TSVector result;
            result.x = value1.x - value2.x;
            result.y = value1.y - value2.y;
            result.z = value1.z - value2.z;
            return result;
        }
        /// <summary>
        /// Subtracts to vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The difference of both vectors.</param>
        public static void Subtract(ref TSVector value1, ref TSVector value2, out TSVector result)
        {
            result.x = value1.x - value2.x;
            result.y = value1.y - value2.y;
            result.z = value1.z - value2.z;
        }


        #endregion

        /// <summary>
        /// The cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product of both vectors.</returns>
        #region public static JVector Cross(JVector vector1, JVector vector2)
        public static TSVector Cross(TSVector vector1, TSVector vector2)
        {
            TSVector result;
            result.x = (vector1.y * vector2.z) - (vector1.z * vector2.y);
            result.y = (vector1.z * vector2.x) - (vector1.x * vector2.z);
            result.z = (vector1.x * vector2.y) - (vector1.y * vector2.x);

            return result;
        }
        public static TSVector Cross(ref TSVector vector1, ref TSVector vector2)
        {
            TSVector result;
            result.x = (vector1.y * vector2.z) - (vector1.z * vector2.y);
            result.y = (vector1.z * vector2.x) - (vector1.x * vector2.z);
            result.z = (vector1.x * vector2.y) - (vector1.y * vector2.x);
            return result;
        }

        public TSVector Cross(TSVector vector2)
        {
            TSVector result;

            result.x = (y * vector2.z) - (z * vector2.y);
            result.y = (z * vector2.x) - (x * vector2.z);
            result.z = (x * vector2.y) - (y * vector2.x);

            return result;
        }
        public TSVector Cross(ref TSVector vector2)
        {
            TSVector result;
            result.x = (y * vector2.z) - (z * vector2.y);
            result.y = (z * vector2.x) - (x * vector2.z);
            result.z = (x * vector2.y) - (y * vector2.x);

            return result;
        }
        /// <summary>
        /// The cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <param name="result">The cross product of both vectors.</param>
        public static void Cross(ref TSVector vector1, ref TSVector vector2, out TSVector result)
        {
            result.x = (vector1.y * vector2.z) - (vector1.z * vector2.y);
            result.y = (vector1.z * vector2.x) - (vector1.x * vector2.z);
            result.z = (vector1.x * vector2.y) - (vector1.y * vector2.x);
        }
        #endregion

        /// <summary>
        /// Gets the hashcode of the vector.
        /// </summary>
        /// <returns>Returns the hashcode of the vector.</returns>
        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }
        #endregion

        /// <summary>
        /// Inverses the direction of the vector.
        /// </summary>
        #region public static JVector Negate(JVector value)
        public void Negate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        /// <summary>
        /// Inverses the direction of a vector.
        /// </summary>
        /// <param name="value">The vector to inverse.</param>
        /// <returns>The negated vector.</returns>
        public static TSVector Negate(TSVector value)
        {
            TSVector result;
            TSVector.Negate(ref value, out result);
            return result;
        }

        /// <summary>
        /// Inverses the direction of a vector.
        /// </summary>
        /// <param name="value">The vector to inverse.</param>
        /// <param name="result">The negated vector.</param>
        public static void Negate(ref TSVector value, out TSVector result)
        {
            FP num0 = -value.x;
            FP num1 = -value.y;
            FP num2 = -value.z;

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }
        #endregion

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="value">The vector which should be normalized.</param>
        /// <returns>A normalized vector.</returns>
        #region public static JVector Normalize(JVector value)
        public static TSVector Normalize(TSVector value)
        {
            return Normalize(ref value);
        }
        public static TSVector Normalize(ref TSVector value)
        {
            TSVector result;
            TSVector.Normalize(ref value, out result);
            return result;
        }
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void Normalize()
        {
            //待优化，特别是x,y,z都很小的情况
            FP num2 = ((this.x * this.x) + (this.y * this.y)) + (this.z * this.z);
            if (num2 > FP.Zero)
            {
                //1/FP.Sqrt(num2) may be zero
                FP num =  FP.Sqrt(num2);
                num = FP.One / num;
                this.x *= num;
                this.y *= num;
                this.z *= num;
            }
            else
            {
                this.x = FP.Zero;
                this.y = FP.Zero;
                this.z = FP.Zero;
            }

        }

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="value">The vector which should be normalized.</param>
        /// <param name="result">A normalized vector.</param>
        public static void Normalize(ref TSVector value, out TSVector result)
        {
            FP num2 = ((value.x * value.x) + (value.y * value.y)) + (value.z * value.z);
            if (num2 > FP.Zero)
            {
                //1/FP.Sqrt(num2) may be zero
                FP num = FP.Sqrt(num2);
                num = FP.One / num;
                result.x = value.x * num;
                result.y = value.y * num;
                result.z = value.z * num;
            }
            else
            {
                result.x = FP.Zero;
                result.y = FP.Zero;
                result.z = FP.Zero;
            }
        }
        #endregion

        #region public static void Swap(ref JVector vector1, ref JVector vector2)

        /// <summary>
        /// Swaps the components of both vectors.
        /// </summary>
        /// <param name="vector1">The first vector to swap with the second.</param>
        /// <param name="vector2">The second vector to swap with the first.</param>
        public static void Swap(ref TSVector vector1, ref TSVector vector2)
        {
            FP temp;

            temp = vector1.x;
            vector1.x = vector2.x;
            vector2.x = temp;

            temp = vector1.y;
            vector1.y = vector2.y;
            vector2.y = temp;

            temp = vector1.z;
            vector1.z = vector2.z;
            vector2.z = temp;
        }
        #endregion

        /// <summary>
        /// Multiply a vector with a factor.
        /// </summary>
        /// <param name="value1">The vector to multiply.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the multiplied vector.</returns>
        #region public static JVector Multiply(JVector value1, FP scaleFactor)
        public static TSVector Multiply(TSVector value1, FP scaleFactor)
        {
            value1.x = value1.x * scaleFactor;
            value1.y = value1.y * scaleFactor;
            value1.z = value1.z * scaleFactor;
            return value1;
        }

        /// <summary>
        /// Multiply a vector with a factor.
        /// </summary>
        /// <param name="value1">The vector to multiply.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">Returns the multiplied vector.</param>
        public static void Multiply(ref TSVector value1, FP scaleFactor, out TSVector result)
        {
            result.x = value1.x * scaleFactor;
            result.y = value1.y * scaleFactor;
            result.z = value1.z * scaleFactor;
        }

        #endregion

        /// <summary>
        /// Calculates the cross product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>Returns the cross product of both.</returns>
        #region public static JVector operator %(JVector value1, JVector value2)
        public static TSVector operator %(TSVector vector1, TSVector vector2)
        {
            TSVector result;
            FP num3 = (vector1.y * vector2.z) - (vector1.z * vector2.y);
            FP num2 = (vector1.z * vector2.x) - (vector1.x * vector2.z);
            FP num = (vector1.x * vector2.y) - (vector1.y * vector2.x);
            result.x = num3;
            result.y = num2;
            result.z = num;

            return result;
        }
        #endregion

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>Returns the dot product of both.</returns>
        #region public static FP operator *(JVector value1, JVector value2)
        public static FP operator *(TSVector vector1, TSVector vector2)
        {
            return ((vector1.x * vector2.x) + (vector1.y * vector2.y)) + (vector1.z * vector2.z);
        }
        #endregion

        /// <summary>
        /// Multiplies a vector by a scale factor.
        /// </summary>
        /// <param name="value1">The vector to scale.</param>
        /// <param name="value2">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        #region public static JVector operator *(JVector value1, FP value2)
        public static TSVector operator *(TSVector value1, FP scaleFactor)
        {
            value1.x = value1.x * scaleFactor;
            value1.y = value1.y * scaleFactor;
            value1.z = value1.z * scaleFactor;

            return value1;
        }

        public static TSVector operator *(TSVector value1, int scaleFactor)
        {
            value1.x = value1.x * scaleFactor;
            value1.y = value1.y * scaleFactor;
            value1.z = value1.z * scaleFactor;

            return value1;
        }
        #endregion

        /// <summary>
        /// Multiplies a vector by a scale factor.
        /// </summary>
        /// <param name="value2">The vector to scale.</param>
        /// <param name="value1">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        #region public static JVector operator *(FP value1, JVector value2)
        public static TSVector operator *(FP scaleFactor, TSVector value2)
        {
            value2.x = value2.x * scaleFactor;
            value2.y = value2.y * scaleFactor;
            value2.z = value2.z * scaleFactor;

            return value2;
        }

        public static TSVector operator *(int scaleFactor, TSVector value2)
        {
            value2.x = value2.x * scaleFactor;
            value2.y = value2.y * scaleFactor;
            value2.z = value2.z * scaleFactor;

            return value2;
        }
        #endregion

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The difference of both vectors.</returns>
        #region public static JVector operator -(JVector value1, JVector value2)
        public static TSVector operator -(TSVector value1, TSVector value2)
        {
            value1.x._serializedValue = value1.x._serializedValue - value2.x._serializedValue;
            value1.y._serializedValue = value1.y._serializedValue - value2.y._serializedValue;
            value1.z._serializedValue = value1.z._serializedValue - value2.z._serializedValue;

            return value1;
        }
        #endregion

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of both vectors.</returns>
        #region public static JVector operator +(JVector value1, JVector value2)
        public static TSVector operator +(TSVector value1, TSVector value2)
        {
            value1.x._serializedValue = value1.x._serializedValue + value2.x._serializedValue;
            value1.y._serializedValue = value1.y._serializedValue + value2.y._serializedValue;
            value1.z._serializedValue = value1.z._serializedValue + value2.z._serializedValue;
            return value1;
        }
        #endregion

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TSVector operator /(TSVector value1, FP scaleFactor)
        {
            //TSVector result;
            //TSVector.Divide(ref value1, value2, out result);

            value1.x = value1.x / scaleFactor;
            value1.y = value1.y / scaleFactor;
            value1.z = value1.z / scaleFactor;

            return value1;
        }

        public static FP Angle(TSVector a, TSVector b)
        {
            return FP.Acos((a.sqrMagnitude == FP.Zero ? a : a.normalized) * (b.sqrMagnitude == FP.Zero ? b : b.normalized)) * FP.Rad2Deg;
        }

        public static FP GetSignedAngle(TSVector vectorA, TSVector vectorB, TSVector up)
        {
            var angle = TSVector.Angle(vectorA, vectorB);
            TSVector cross = TSVector.Cross(vectorA, vectorB);
            if (cross.y < FP.Zero)
            {
                angle = -angle;
            }
            return angle;
        }

        public static TSVector Rotate(TSVector p, FP angle)
        {
            var qr = TSQuaternion.Euler(0, angle, 0);
            TSMatrix4x4 m = TSMatrix4x4.TRS(TSVector.zero, qr, TSVector.one);
            var r = m.MultiplyPoint3x4(p);
            return r;
        }

        public static TSVector Rotate(TSVector p, TSQuaternion qr)
        {
            TSMatrix4x4 m = TSMatrix4x4.TRS(TSVector.zero, qr, TSVector.one);
            var r = m.MultiplyPoint3x4(p);
            return r;
        }

        public TSVector2 ToTSVector2()
        {
            return new TSVector2(this.x, this.z);
        }

        #region ChenPlus
        public static TSVector operator -(TSVector value1)
        {
            value1.x._serializedValue = -value1.x._serializedValue;
            value1.y._serializedValue = -value1.y._serializedValue;
            value1.z._serializedValue = -value1.z._serializedValue;

            return value1;
        }
        public static TSVector Project(TSVector vector1, TSVector vector2)
        {
            return Dot(ref vector1, ref vector2) / vector2.sqrMagnitude * vector2.normalized;
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.x.AsFloat(), this.y.AsFloat(), this.z.AsFloat());
        }
        public int costMagnitude
        {
            get
            {
                return (int)FP.Round(magnitude);
            }
        }

        public static explicit operator TSVector2(TSVector value)
        {
            TSVector2 result;
            result.x = value.x;
            result.y = value.y;
            return result;
        }

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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index:" + index);
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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index:" + index);
                }
            }
        }

        public TSVector Abs()
        {
            TSVector result;
            result.x._serializedValue = x._serializedValue < FP.Zero._serializedValue ? -x._serializedValue : x._serializedValue;
            result.y._serializedValue = y._serializedValue < FP.Zero._serializedValue ? -y._serializedValue : y._serializedValue;
            result.z._serializedValue = z._serializedValue < FP.Zero._serializedValue ? -z._serializedValue : z._serializedValue;
            return result;
        }

        public void abs()
        {
            x._serializedValue = x._serializedValue < FP.Zero._serializedValue ? -x._serializedValue : x._serializedValue;
            y._serializedValue = y._serializedValue < FP.Zero._serializedValue ? -y._serializedValue : y._serializedValue;
            z._serializedValue = z._serializedValue < FP.Zero._serializedValue ? -z._serializedValue : z._serializedValue;
        }
        public TSVector Absolute()
        {
            return new TSVector(FP.FastAbs(x), FP.FastAbs(y), FP.FastAbs(z));
        }

        public int MaxAxis()
        {
            return x < y ? (y < z ? 2 : 1) : (x < z ? 2 : 0);
        }

        public int MinAxis()
        {
            return x < y ? (x < z ? 0 : 2) : (y < z ? 1 : 2);
        }
        public FP Triple(ref TSVector b, ref TSVector c)
        {
            return x * (b.y * c.z - b.z * c.y) +
                   y * (b.z * c.x - b.x * c.z) +
                   z * (b.x * c.y - b.y * c.x);
        }

        public void SetMin(ref TSVector v)
        {
            if (v.x < x)
            {
                x = v.x;
            }
            if (v.y < y)
            {
                y = v.y;
            }
            if (v.z < z)
            {
                z = v.z;
            }
        }


        public void SetMax(ref TSVector v)
        {
            if (v.x > x)
            {
                x = v.x;
            }
            if (v.y > y)
            {
                y = v.y;
            }
            if (v.z > z)
            {
                z = v.z;
            }
        }

        #endregion

    }

}
#endif