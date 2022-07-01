/* Copyright (C) <2009-2011> <Thorben Linneweber, Jitter Physics>
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
*/

#if USEBATTLEDLL
#else
namespace TrueSync
{

    /// <summary>
    /// Contains common math operations.
    /// </summary>
    public sealed class TSMath
    {

        /// <summary>
        /// PI constant.
        /// </summary>
        public static FP Pi = FP.Pi;

        /**
        *  @brief PI over 2 constant.
        **/
        public static FP PiOver2 = FP.PiOver2;

        /// <summary>
        /// A small value often used to decide if numeric
        /// results are zero.
        /// </summary>
        public static FP Epsilon = FP.Epsilon;
        public static FP EpsilonSqr = FP.Epsilon * FP.Epsilon;

        /**
        *  @brief Degree to radians constant.
        **/
        public static FP Deg2Rad = FP.Deg2Rad;

        /**
        *  @brief Radians to degree constant.
        **/
        public static FP Rad2Deg = FP.Rad2Deg;

        /// <summary>
        /// Gets the square root.
        /// </summary>
        /// <param name="number">The number to get the square root from.</param>
        /// <returns></returns>
        #region public static FP Sqrt(FP number)
        public static FP Sqrt(FP number)
        {
            return FP.Sqrt(number);
        }
        #endregion

        /// <summary>
        /// Gets the maximum number of two values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>Returns the largest value.</returns>
        #region public static FP Max(FP val1, FP val2)
        public static FP Max(FP val1, FP val2)
        {
            return (val1 > val2) ? val1 : val2;
        }
        #endregion

        /// <summary>
        /// Gets the minimum number of two values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>Returns the smallest value.</returns>
        #region public static FP Min(FP val1, FP val2)
        public static FP Min(FP val1, FP val2)
        {
            return (val1 < val2) ? val1 : val2;
        }
        #endregion

        /// <summary>
        /// Gets the maximum number of three values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <param name="val3">The third value.</param>
        /// <returns>Returns the largest value.</returns>
        #region public static FP Max(FP val1, FP val2,FP val3)
        public static FP Max(FP val1, FP val2, FP val3)
        {
            FP max12 = (val1 > val2) ? val1 : val2;
            return (max12 > val3) ? max12 : val3;
        }
        #endregion

        /// <summary>
        /// Returns a number which is within [min,max]
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        #region public static FP Clamp(FP value, FP min, FP max)
        public static FP Clamp(FP value, FP min, FP max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static int ClampInt(int value, int min, int max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        #endregion

        /// <summary>
        /// Changes every sign of the matrix entry to '+'
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="result">The absolute matrix.</param>
        #region public static void Absolute(ref JMatrix matrix,out JMatrix result)
        public static void Absolute(ref TSMatrix matrix, out TSMatrix result)
        {
            result.M11 = FP.Abs(matrix.M11);
            result.M12 = FP.Abs(matrix.M12);
            result.M13 = FP.Abs(matrix.M13);
            result.M21 = FP.Abs(matrix.M21);
            result.M22 = FP.Abs(matrix.M22);
            result.M23 = FP.Abs(matrix.M23);
            result.M31 = FP.Abs(matrix.M31);
            result.M32 = FP.Abs(matrix.M32);
            result.M33 = FP.Abs(matrix.M33);
        }
        #endregion

        /// <summary>
        /// Returns the sine of value.
        /// </summary>
        public static FP Sin(FP value)
        {
            return FP.Sin(value);
        }

        /// <summary>
        /// Returns the cosine of value.
        /// </summary>
        public static FP Cos(FP value)
        {
            return FP.Cos(value);
        }

        /*/// <summary>
        /// Returns the tan of value.
        /// </summary>
        public static FP Tan(FP value)
        {
            return FP.Tan(value);
        }*/

        /// <summary>
        /// Returns the arc sine of value.
        /// </summary>
        public static FP Asin(FP value)
        {
            return FP.Asin(value);
        }

        /// <summary>
        /// Returns the arc cosine of value.
        /// </summary>
        public static FP Acos(FP value)
        {
            return FP.Acos(value);
        }

        /// <summary>
        /// Returns the arc tan of value.
        /// </summary>
        public static FP Atan(FP value)
        {
            return FP.Atan(value);
        }

        /// <summary>
        /// Returns the arc tan of coordinates x-y.
        /// </summary>
        public static FP Atan2(FP y, FP x)
        {
            return FP.Atan2(y, x);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number.
        /// </summary>
        public static FP Floor(FP value)
        {
            return FP.Floor(value);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified number.
        /// </summary>
        public static FP Ceiling(FP value)
        {
            return FP.Ceiling(value);
        }

        /// <summary>
        /// Rounds a value to the nearest integral value.
        /// If the value is halfway between an even and an uneven value, returns the even value.
        /// </summary>
        public static FP Round(FP value)
        {
            return FP.Round(value);
        }

        /// <summary>
        /// Returns a number indicating the sign of a Fix64 number.
        /// Returns 1 if the value is positive, 0 if is 0, and -1 if it is negative.
        /// </summary>
        public static int Sign(FP value)
        {
            return FP.Sign(value);
        }

        /// <summary>
        /// Returns the absolute value of a Fix64 number.
        /// Note: Abs(Fix64.MinValue) == Fix64.MaxValue.
        /// </summary>
        public static FP Abs(FP value)
        {
            return FP.Abs(value);
        }

        public static FP Barycentric(FP value1, FP value2, FP value3, FP amount1, FP amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }

        public static FP CatmullRom(FP value1, FP value2, FP value3, FP value4, FP amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/
            // Internally using FPs not to lose precission
            FP amountSquared = amount * amount;
            FP amountCubed = amountSquared * amount;
            return (FP)(0.5 * (2.0 * value2 +
                               (value3 - value1) * amount +
                               (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                               (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        public static FP Distance(FP value1, FP value2)
        {
            return FP.Abs(value1 - value2);
        }

        public static FP Hermite(FP value1, FP tangent1, FP value2, FP tangent2, FP amount)
        {
            // All transformed to FP not to lose precission
            // Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
            FP v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
            FP sCubed = s * s * s;
            FP sSquared = s * s;

            if (amount == 0f)
            {
                result = value1;
            }
            else if (amount == 1f)
            {
                result = value2;
            }
            else
                result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
                         (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
                         t1 * s +
                         v1;
            return (FP)result;
        }

        public static FP Lerp(FP value1, FP value2, FP amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static FP SmoothStep(FP value1, FP value2, FP amount)
        {
            // It is expected that 0 < amount < 1
            // If amount < 0, return value1
            // If amount > 1, return value2
            FP result = Clamp(amount, 0f, 1f);
            result = Hermite(value1, 0f, value2, 0f, result);
            return result;
        }

        public static FP Pow(FP value, int p)
        {
            if (p > 0)
            {
                return value * Pow(value, p - 1);
            }
            return 1;
        }

        const int A = 15342;
        const int C = 45194;
        const int RAND_MAX = 100000;
        static int prev = 7;

        // rand value 0~1
        static float Rand()
        {
            prev = (prev * A + C) % RAND_MAX;
            return (float)prev / (float)RAND_MAX;
        }

        public static FP Random()
        {
            return (FP)Rand();
        }

        // On Unit Sphere of radius
        public static TSVector OnUnitSphere(FP radius)
        {
            var u = TSMath.Random();
            var v = TSMath.Random();
            var theta = 2 * TSMath.Pi * u;
            var phi = TSMath.Acos(2 * v - 1);
            var x = (radius * TSMath.Sin(phi) * TSMath.Cos(theta));
            var y = (radius * TSMath.Sin(phi) * TSMath.Sin(theta));
            var z = (radius * TSMath.Cos(phi));
            return new TSVector(x, y, z);
        }

        public static TSVector OnUnitSemiSphere(FP radius)
        {
            var a = OnUnitSphere(radius);
            var y = a.y;
            if (y < 0)
            {
                y = -y;
            }
            return new TSVector(a.x, y, a.z);
        }

        #region 扩展方法
        public static bool Approximately(FP val1, FP val2)
        {
            return FP.FastAbs(val1 - val2) < FP.Epsilon;
        }

        public static bool Approximately(TSVector2 val1, TSVector2 val2)
        {
            return (val1 - val2).sqrMagnitude < EpsilonSqr;
        }

        /// <summary>
        /// Get the closest point on a line segment.
        /// </summary>
        /// <param name="p">A point in space</param>
        /// <param name="s0">Start of line segment</param>
        /// <param name="s1">End of line segment</param>
        public static TSVector2 ClosestPointOnSegment(TSVector2 p, TSVector2 s0, TSVector2 s1)
        {
            TSVector2 s = s1 - s0;
            FP len2 = s.sqrMagnitude;
            if (len2 < Epsilon)
            {
                return s0;
            }
            FP rate = TSMath.Clamp(TSVector2.Dot(p - s0, s) / len2,FP.Zero, FP.One);
            return s0 + rate * s;
        }

        /// <summary>
        ///  x-Xmin,y-XMax,z-YMin,w-Ymax
        /// </summary>
        /// <param name="aabb1"></param>
        /// <param name="aabb2"></param>
        /// <returns></returns>

        public static TSVector4 Combine(TSVector4 aabb1, TSVector4 aabb2)
        {
            aabb1.x = Min(aabb1.x, aabb2.x);
            aabb1.y = Max(aabb1.y, aabb2.y);
            aabb1.z = Min(aabb1.z, aabb2.z);
            aabb1.w = Max(aabb1.w, aabb2.w);
            return aabb1;
        }

        /// <summary>
        /// determinant two direction
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static FP Det(TSVector2 d0, TSVector2 d1)
        {
            return d0.x * d1.y - d1.x * d0.y;
        }

        #endregion
    }
}
#endif