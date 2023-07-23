namespace Model.DbEntities
{
    public class Permanence
    {

        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int ClinicId { get; set; }

        public int carryingCapacity { get; set; }
        public Clinic Clinic { get; set; } = null!;

    }

}