namespace Cards.Domain.Models.Requests
{
    public class CreateCardRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}