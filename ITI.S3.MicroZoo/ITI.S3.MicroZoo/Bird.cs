namespace ITI.S3.MicroZoo
{
    public class Bird
    {
        readonly string _name;

        internal Bird( string name )
        {
            _name = name;
        }

        public string Name => _name;
    }
}
