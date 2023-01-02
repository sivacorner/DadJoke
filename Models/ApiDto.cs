namespace DadJokes.Models
{
    public class ApiDto
    {
        public bool? success { get; set; }
        public IList<Jokes>? body { get; set; }
    }
}
