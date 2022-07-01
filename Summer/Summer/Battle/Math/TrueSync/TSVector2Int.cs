#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors
 * Alan McGovern

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion License

using System;
#if USEBATTLEDLL
#else
namespace TrueSync {
    [Serializable]
    public struct TSVector2Int : IEquatable<TSVector2Int>
    {
#region Private Fields

        public static readonly TSVector2Int zero = new TSVector2Int(0, 0);
        public static readonly TSVector2Int one = new TSVector2Int(1, 1);

        public static readonly TSVector2Int right = new TSVector2Int(1, 0);
        public static readonly TSVector2Int left = new TSVector2Int(-1, 0);

        public static readonly TSVector2Int up = new TSVector2Int(0, 1);
        public static readonly TSVector2Int down = new TSVector2Int(0, -1);

        public static readonly TSVector2Int initPos = new TSVector2Int(-1, -1) * 1000;
        #endregion Private Fields

        #region Public Fields

        public int x;
        public int y;

#endregion Public Fields

#region Properties
        /*
        public static TSVector2Int zero
        {
            get { return zeroVector; }
        }

        public static TSVector2Int one
        {
            get { return oneVector; }
        }

        public static TSVector2Int right
        {
            get { return rightVector; }
        }

        public static TSVector2Int left {
            get { return leftVector; }
        }

        public static TSVector2Int up
        {
            get { return upVector; }
        }

        public static TSVector2Int down {
            get { return downVector; }
        }
        */
#endregion Properties

#region Constructors

        /// <summary>
        /// Constructor foe standard 2D vector.
        /// </summary>
        /// <param name="x">
        /// A <see cref="System.Single"/>
        /// </param>
        /// <param name="y">
        /// A <see cref="System.Single"/>
        /// </param>
        public TSVector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructor for "square" vector.
        /// </summary>
        /// <param name="value">
        /// A <see cref="System.Single"/>
        /// </param>
        public TSVector2Int(int value)
        {
            x = value;
            y = value;
        }

        public void Set(int x, int y) {
            this.x = x;
            this.y = y;
        }

#endregion Constructors

#region Public Methods

        public static void Reflect(ref TSVector2Int vector, ref TSVector2Int normal, out TSVector2Int result)
        {
            int dot = Dot(vector, normal);
            result.x = vector.x - ((2*dot)*normal.x);
            result.y = vector.y - ((2*dot)*normal.y);
        }

        public static TSVector2Int Reflect(TSVector2Int vector, TSVector2Int normal)
        {
            TSVector2Int result;
            Reflect(ref vector, ref normal, out result);
            return result;
        }

        public static TSVector2Int Add(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }

        public static void Add(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = value1.x + value2.x;
            result.y = value1.y + value2.y;
        }
        
        static int DistanceSquared(TSVector2Int value1, TSVector2Int value2)
        {
            int result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref TSVector2Int value1, ref TSVector2Int value2, out int result)
        {
            result = (value1.x - value2.x)*(value1.x - value2.x) + (value1.y - value2.y)*(value1.y - value2.y);
        }

        /// <summary>
        /// Devide first vector with the secund vector
        /// </summary>
        /// <param name="value1">
        /// A <see cref="TSVector2Int"/>
        /// </param>
        /// <param name="value2">
        /// A <see cref="TSVector2Int"/>
        /// </param>
        /// <returns>
        /// A <see cref="TSVector2Int"/>
        /// </returns>
        public static TSVector2Int Divide(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }

        public static void Divide(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = value1.x/value2.x;
            result.y = value1.y/value2.y;
        }

        public static TSVector2Int Divide(TSVector2Int value1, int divider)
        {
            int factor = 1/divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

        public static void Divide(ref TSVector2Int value1, int divider, out TSVector2Int result)
        {
            int factor = 1/divider;
            result.x = value1.x*factor;
            result.y = value1.y*factor;
        }

        public static int Dot(TSVector2Int value1, TSVector2Int value2)
        {
            return value1.x*value2.x + value1.y*value2.y;
        }
        public static int Dot(ref TSVector2Int value1, ref TSVector2Int value2)
        {
            return value1.x * value2.x + value1.y * value2.y;
        }
        public static void Dot(ref TSVector2Int value1, ref TSVector2Int value2, out int result)
        {
            result = value1.x*value2.x + value1.y*value2.y;
        }

        public override bool Equals(object obj)
        {
            return (obj is TSVector2Int) ? this == ((TSVector2Int) obj) : false;
        }

        public bool Equals(TSVector2Int other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (int) (x + y);
        }
        

        public int LengthSquared()
        {
           return  x  * x + y * y ;
        }
        
        public static TSVector2Int Max(TSVector2Int value1, TSVector2Int value2)
        {
            return new TSVector2Int(
                Math.Max(value1.x, value2.x),
                Math.Max(value1.y, value2.y));
        }

        public static void Max(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = Math.Max(value1.x, value2.x);
            result.y = Math.Max(value1.y, value2.y);
        }

        public static TSVector2Int Min(TSVector2Int value1, TSVector2Int value2)
        {
            return new TSVector2Int(
                Math.Min(value1.x, value2.x),
                Math.Min(value1.y, value2.y));
        }

        public static void Min(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = Math.Min(value1.x, value2.x);
            result.y = Math.Min(value1.y, value2.y);
        }

        public void Scale(TSVector2Int other) {
            this.x = x * other.x;
            this.y = y * other.y;
        }

        public static TSVector2Int Scale(TSVector2Int value1, TSVector2Int value2) {
            TSVector2Int result;
            result.x = value1.x * value2.x;
            result.y = value1.y * value2.y;

            return result;
        }

        public static TSVector2Int Multiply(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x *= value2.x;
            value1.y *= value2.y;
            return value1;
        }

        public static TSVector2Int Multiply(TSVector2Int value1, int scaleFactor)
        {
            value1.x *= scaleFactor;
            value1.y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref TSVector2Int value1, int scaleFactor, out TSVector2Int result)
        {
            result.x = value1.x*scaleFactor;
            result.y = value1.y*scaleFactor;
        }

        public static void Multiply(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = value1.x*value2.x;
            result.y = value1.y*value2.y;
        }

        public static TSVector2Int Negate(TSVector2Int value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }

        public static void Negate(ref TSVector2Int value, out TSVector2Int result)
        {
            result.x = -value.x;
            result.y = -value.y;
        }


        public static TSVector2Int Subtract(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }

        public static void Subtract(ref TSVector2Int value1, ref TSVector2Int value2, out TSVector2Int result)
        {
            result.x = value1.x - value2.x;
            result.y = value1.y - value2.y;
        }
        

        public TSVector ToTSVector() {
            return new TSVector(this.x, this.y, 0);
        }

        public override string ToString() {
            return string.Format("{0},{1}", x, y);
        }

#endregion Public Methods

#region Operators

        public static TSVector2Int operator -(TSVector2Int value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }


        public static bool operator ==(TSVector2Int value1, TSVector2Int value2)
        {
            return value1.x == value2.x && value1.y == value2.y;
        }


        public static bool operator !=(TSVector2Int value1, TSVector2Int value2)
        {
            return value1.x != value2.x || value1.y != value2.y;
        }


        public static TSVector2Int operator +(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }


        public static TSVector2Int operator -(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }


        public static int operator *(TSVector2Int value1, TSVector2Int value2)
        {
            return value1.x * value2.x + value1.y * value2.y;
        }


        public static TSVector2Int operator *(TSVector2Int value, int scaleFactor)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }


        public static TSVector2Int operator *(int scaleFactor, TSVector2Int value)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }


        public static TSVector2Int operator /(TSVector2Int value1, TSVector2Int value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }


        public static TSVector2Int operator /(TSVector2Int value1, int divider)
        {
            int factor = 1 / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

#endregion Operators

#region ChenPlus
        public int sqrMagnitude
        {
            get
            {
                return ((this.x * this.x) + (this.y * this.y));
            }
        }

        public static explicit operator TSVector(TSVector2Int value)
        {
            TSVector result;
            result.x = value.x;
            result.y = value.y;
            result.z = 0;
            return result;
        }
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2 index:" + index);
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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2 index:" + index);
                }
            }
        }

        #endregion
    }
}
#endif