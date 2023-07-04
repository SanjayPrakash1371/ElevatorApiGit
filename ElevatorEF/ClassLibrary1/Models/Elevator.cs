namespace ElevatorEF.Models
{
    public class Elevator
    {
        public int Id { get; set; }

        public int floorno { get; set; }

        public int weight { get; set; }

        public DateTime dateTime { get; set; }

        // int count
        // liftlog .start==floorno
    }
}
