using System.ComponentModel.DataAnnotations;

namespace PomeranianTransfermarkt.Entities
{
    public class Clubs
    {
        [Key]
        public int ClubId { get; set; }
        public string Name { get; set; } = default!;
        public string Stadium { get; set; } = default!;
        public string Trainer { get; set; } = default!;
        public string League { get; set; } = default!;
        public List<Players> Players { get; set; } = default!;
        public List<Trainers> Trainers { get; set; } = default!;

    }
}
