namespace ITI.S3.MicroZoo
{
    public class Bird
    {
        readonly Zoo _context;
        string _name;

        internal Bird( Zoo context, string name )
        {
            _context = context;
            _name = name;
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
    }
}
