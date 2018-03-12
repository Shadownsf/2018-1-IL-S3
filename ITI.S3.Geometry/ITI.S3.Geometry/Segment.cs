using System;

namespace ITI.S3.Geometry
{
    public class Segment
    {
        int _position;
        readonly ushort _length;

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="length">The length.</param>
        public Segment( int position, ushort length )
        {
            _position = position;
            _length = length;
        }

        /// <summary>
        /// Gets the left position.
        /// </summary>
        /// <value>
        /// The left.
        /// </value>
        public int Left => _position;

        /// <summary>
        /// Gets the right position.
        /// </summary>
        /// <value>
        /// The right.
        /// </value>
        public int Right => _position + _length;

        /// <summary>
        /// Gets the length of the current <see cref="Segment"/>.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length => _length;

        /// <summary>
        /// Moves the current <see cref="Segment"/>.
        /// </summary>
        /// <param name="delta">The delta.</param>
        public void Move( int delta )
        {
            _position += delta;
        }

        /// <summary>
        /// Determines whether the current <see cref="Segment"/> contains the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains( int point )
        {
            return Left <= point && point < Right;
        }

        /// <summary>
        /// Overlapses the specified <see cref="Segment"/>.
        /// </summary>
        /// <param name="other">The other <see cref="Segment"/>.</param>
        /// <returns></returns>
        public bool Overlaps( Segment other )
        {
            return other.Left < Right && other.Right > Left;
        }

        /// <summary>
        /// Gets the intersections with the specified <see cref="Segment"/>.
        /// </summary>
        /// <param name="other">The other <see cref="Segment"/>.</param>
        /// <returns>A new <see cref="Segment"/> that represents the intersection.</returns>
        public Segment Intersection( Segment other )
        {
            if( !Overlaps( other ) ) return null;
            if( Left <= other.Left ) return new Segment( other.Left, ( ushort )( Right - other.Left ) );
            return other.Intersection( this );
        }
    }
}
