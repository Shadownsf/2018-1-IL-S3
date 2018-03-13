using System;

namespace ITI.S3.LightAndSwitch
{
    public class Light
    {
        bool _isOn;

        internal bool Toggle()
        {
            _isOn = !_isOn;
            return _isOn;
        }

        public bool IsOn => _isOn;
    }
}
