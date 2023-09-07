using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomeranianTransfermarkt.Entities
{
    public class Trainers
    {
        [Key]
        public int TrainerId { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public int Age { get; set; } = default!;
        public string Nationality { get; set; } = default!;

        public List<Clubs> Clubs{ get; set; } = default!;
        public List<Players> Players { get; set; } = default!;
    }
}
