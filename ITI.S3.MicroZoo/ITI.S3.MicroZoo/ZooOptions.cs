using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.S3.MicroZoo
{
    public class ZooOptions
    {
        double _catSpeed;
        double _birdSpeed;

        public ZooOptions()
        {
            _catSpeed = 0.01;
            _birdSpeed = 0.02;
        }

        public double CatSpeed
        {
            get { return _catSpeed; }
            set { _catSpeed = value; }
        }

        public double BirdSpeed
        {
            get { return _birdSpeed; }
            set { _birdSpeed = value; }
        }
    }
}
