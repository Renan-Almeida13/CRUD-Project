namespace Domain.Commons
{
    public class Command
    {
        public int UserId { get; set; }
    }

    public class CommandPagination
    {
        public int UserId { get; set; }
        public int Page { get; set; }
        public int Items { get; set; }
    }
}
