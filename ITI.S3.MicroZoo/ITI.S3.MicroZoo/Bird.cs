namespace ITI.S3.MicroZoo
{
    public class Bird
    {
        readonly Zoo _context;
        string _name;
        Vector _position;
        bool _isAlive;

        internal Bird( Zoo context, string name )
        {
            _context = context;
            _name = name;
            _position = context.GetNextRandomPosition();
            _isAlive = true;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _context.OnRename( this, value );
                _name = value;
            }
        }

        public double X => _position.X;

        public double Y => _position.Y;

        public bool IsAlive => _isAlive;

        internal void Update()
        {

        }

        internal Vector Position => _position;
    }
}
