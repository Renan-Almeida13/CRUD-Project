namespace Domain.Commons
{
    public abstract class Handler
    {
        public List<string> Errors { get; set; }

        protected Handler() 
        { 
            Errors = new List<string>();
        }
    }
}
