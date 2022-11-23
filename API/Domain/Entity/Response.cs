namespace API.Domain.Entity
{
    public class Response
    {
        public int success { get; set; } = 0;
        public string message { get; set; } = string.Empty;

        public int ID { get; set; } = 0;
    }
}
