using System;
#if USEBATTLEDLL
#else
namespace TrueSync
{
    public struct TSRect
    {
        private FP m_XMin;

        private FP m_YMin;

        private FP m_Width;

        private FP m_Height;

        public FP x
        {
            get
            {
                return this.m_XMin;
            }
            set
            {
                this.m_XMin = value;
            }
        }

        public FP y
        {
            get
            {
                return this.m_YMin;
            }
            set
            {
                this.m_YMin = value;
            }
        }

        public TSVector2 position
        {
            get
            {
                return new TSVector2(this.m_XMin, this.m_YMin);
            }
            set
            {
                this.m_XMin = value.x;
                this.m_YMin = value.y;
            }
        }

        public TSVector2 center
        {
            get
            {
                return new TSVector2(this.x + this.m_Width / 2, this.y + this.m_Height / 2);
            }
            set
            {
                this.m_XMin = value.x - this.m_Width / 2;
                this.m_YMin = value.y - this.m_Height / 2;
            }
        }

        public TSVector2 min
        {
            get
            {
                return new TSVector2(this.xMin, this.yMin);
            }
            set
            {
                this.xMin = value.x;
                this.yMin = value.y;
            }
        }

        public TSVector2 max
        {
            get
            {
                return new TSVector2(this.xMax, this.yMax);
            }
            set
            {
                this.xMax = value.x;
                this.yMax = value.y;
            }
        }

        public FP width
        {
            get
            {
                return this.m_Width;
            }
            set
            {
                this.m_Width = value;
            }
        }

        public FP height
        {
            get
            {
                return this.m_Height;
            }
            set
            {
                this.m_Height = value;
            }
        }

        public TSVector2 size
        {
            get
            {
                return new TSVector2(this.m_Width, this.m_Height);
            }
            set
            {
                this.m_Width = value.x;
                this.m_Height = value.y;
            }
        }

        [Obsolete("use xMin")]
        public FP left
        {
            get
            {
                return this.m_XMin;
            }
        }

        [Obsolete("use xMax")]
        public FP right
        {
            get
            {
                return this.m_XMin + this.m_Width;
            }
        }

        [Obsolete("use yMin")]
        public FP top
        {
            get
            {
                return this.m_YMin;
            }
        }

        [Obsolete("use yMax")]
        public FP bottom
        {
            get
            {
                return this.m_YMin + this.m_Height;
            }
        }

        public FP xMin
        {
            get
            {
                return this.m_XMin;
            }
            set
            {
                FP xMax = this.xMax;
                this.m_XMin = value;
                this.m_Width = xMax - this.m_XMin;
            }
        }

        public FP yMin
        {
            get
            {
                return this.m_YMin;
            }
            set
            {
                FP yMax = this.yMax;
                this.m_YMin = value;
                this.m_Height = yMax - this.m_YMin;
            }
        }

        public FP xMax
        {
            get
            {
                return this.m_Width + this.m_XMin;
            }
            set
            {
                this.m_Width = value - this.m_XMin;
            }
        }

        public FP yMax
        {
            get
            {
                return this.m_Height + this.m_YMin;
            }
            set
            {
                this.m_Height = value - this.m_YMin;
            }
        }

        public TSRect(FP x, FP y, FP width, FP height)
        {
            this.m_XMin = x;
            this.m_YMin = y;
            this.m_Width = width;
            this.m_Height = height;
        }

        public TSRect(TSVector2 position, TSVector2 size)
        {
            this.m_XMin = position.x;
            this.m_YMin = position.y;
            this.m_Width = size.x;
            this.m_Height = size.y;
        }

        public TSRect(TSRect source)
        {
            this.m_XMin = source.m_XMin;
            this.m_YMin = source.m_YMin;
            this.m_Width = source.m_Width;
            this.m_Height = source.m_Height;
        }

        public static TSRect MinMaxRect(FP xmin, FP ymin, FP xmax, FP ymax)
        {
            return new TSRect(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        public void Set(FP x, FP y, FP width, FP height)
        {
            this.m_XMin = x;
            this.m_YMin = y;
            this.m_Width = width;
            this.m_Height = height;
        }

        public override string ToString()
        {
            return string.Format("(x:{0:F2}, y:{1:F2}, width:{2:F2}, height:{3:F2})", new object[]
            {
                this.x,
                this.y,
                this.width,
                this.height
            });
        }

        public bool Contains(TSVector2 point)
        {
            return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
        }

        public bool Contains(TSVector point)
        {
            return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
        }

        public bool Contains(TSVector point, bool allowInverse)
        {
            if (!allowInverse)
            {
                return this.Contains(point);
            }
            bool flag = false;
            if ((this.width < FP.Zero && point.x <= this.xMin && point.x > this.xMax) || (this.width >= FP.Zero && point.x >= this.xMin && point.x < this.xMax))
            {
                flag = true;
            }
            return flag && ((this.height < FP.Zero && point.y <= this.yMin && point.y > this.yMax) || (this.height >= FP.Zero && point.y >= this.yMin && point.y < this.yMax));
        }

        private static TSRect OrderMinMax(TSRect rect)
        {
            if (rect.xMin > rect.xMax)
            {
                FP xMin = rect.xMin;
                rect.xMin = rect.xMax;
                rect.xMax = xMin;
            }
            if (rect.yMin > rect.yMax)
            {
                FP yMin = rect.yMin;
                rect.yMin = rect.yMax;
                rect.yMax = yMin;
            }
            return rect;
        }

        public bool Overlaps(TSRect other)
        {
            return other.xMax > this.xMin && other.xMin < this.xMax && other.yMax > this.yMin && other.yMin < this.yMax;
        }

        public bool Overlaps(TSRect other, bool allowInverse)
        {
            TSRect rect = this;
            if (allowInverse)
            {
                rect = TSRect.OrderMinMax(rect);
                other = TSRect.OrderMinMax(other);
            }
            return rect.Overlaps(other);
        }

        public static TSVector2 NormalizedToPoint(TSRect rectangle, TSVector2 normalizedRectCoordinates)
        {
            return new TSVector2(FP.Lerp(rectangle.x, rectangle.xMax, normalizedRectCoordinates.x), FP.Lerp(rectangle.y, rectangle.yMax, normalizedRectCoordinates.y));
        }


        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.width.GetHashCode() << 2 ^ this.y.GetHashCode() >> 2 ^ this.height.GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is TSRect))
            {
                return false;
            }
            TSRect rect = (TSRect)other;
            return this.x.Equals(rect.x) && this.y.Equals(rect.y) && this.width.Equals(rect.width) && this.height.Equals(rect.height);
        }

        public static bool operator !=(TSRect lhs, TSRect rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y || lhs.width != rhs.width || lhs.height != rhs.height;
        }

        public static bool operator ==(TSRect lhs, TSRect rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height;
        }

    }
}
#endif