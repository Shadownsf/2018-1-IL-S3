using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.LightAndSwitch
{
    public class Switch
    {
        readonly Light[] _lights;
        bool _isOn;

        public Switch( int slots )
        {
            _lights = new Light[ slots ];
        }

        public bool Attach( Light light )
        {
            int firstFreeSlotIdx = -1;
            for( int i = 0; i < _lights.Length; i++ )
            {
                if( _lights[ i ] == light ) return false;
                if( _lights[ i ] == null ) firstFreeSlotIdx = i;
            }

            if( firstFreeSlotIdx < 0 ) return false;

            _lights[ firstFreeSlotIdx ] = light;
            if( _isOn ) light.Toggle();
            return true;
        }

        public bool Detach( Light light )
        {
            for( int i = 0; i < _lights.Length; i++ )
            {
                if( light == _lights[ i ] )
                {
                    _lights[ i ] = null;
                    if( _isOn ) light.Toggle();
                    return true;
                }
            }

            return false;
        }

        public void Toggle()
        {
            _isOn = !_isOn;
            foreach( Light light in _lights )
            {
                if( light != null ) light.Toggle();
            }
        }
    }
}
