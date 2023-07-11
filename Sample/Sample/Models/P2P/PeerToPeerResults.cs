namespace Sample.Models.P2P
{
    public class PeerToPeerResults
    {
        public int id { get; set; }

        public string? nomainatedEmpId { get; set; }
        public string? nomainaterId { get; set; }

        public string? citation { get; set; }

       public Employee? employee { get; set; }

       // public PeerToPeer? peerToPeer { get; set; }
    }
}
