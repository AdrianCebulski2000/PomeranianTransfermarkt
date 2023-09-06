namespace PomeranianTransfermarkt.Entities
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public int Age { get; set; } = default!;
        public string Position { get; set; } = default!;
        public double MarketValue { get; set; } = default!;
        public string Nationality { get; set; } = default!;
    }
}
