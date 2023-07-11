using System.ComponentModel.DataAnnotations;

namespace Sample.Models.P2P
{
    public class PeerToPeer
    {
        [Key]
        public int Id { get; set; }
        public string nominatorId { get; set; }

        public string? awardCategory { get; set; }

        public int? month { get; set; }

        public string? citation { get; set; }

       public string? empId { get; set; }

        public Employee? employee { get; set; }

        public PeerToPeerResults? Results { get; set; }  
    }
}
