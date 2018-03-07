using System;

namespace ITI.S3.Bottle
{
    public class Flask
    {
        int _maxCapacity;
        int _volume;

        public Flask( int maxCapacity )
        {
            _maxCapacity = maxCapacity;
            _volume = 0;
        }

        public void Fill( int volume )
        {
            _volume = Math.Min( _volume + volume, _maxCapacity );
        }

        public void Fill()
        {
            _volume = _maxCapacity;
        }

        public void Empty( int volume )
        {
            _volume = Math.Max( 0, _volume - volume );
        }

        public void Empty()
        {
            _volume = 0;
        }

        public int MaxCapacity
        {
            get { return _maxCapacity; }
        }

        public int Volume
        {
            get { return _volume; }
        }

        public bool IsEmpty
        {
            get { return _volume == 0; }
        }

        public bool IsFull
        {
            get { return _volume == _maxCapacity; }
        }
    }
}
