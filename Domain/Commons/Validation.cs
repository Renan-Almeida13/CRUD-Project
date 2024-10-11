namespace Domain.Commons
{
    public abstract class Validation
    {
        public List<string> Errors { get; set; }

        protected Validation()
        {
            Errors = new List<string>();
        }
    }
}
