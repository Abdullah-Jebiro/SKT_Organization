namespace Model.Dtos
{
    public class ReservationStatus
    {
        public string Status { get; set; }
        public string stoppingTo { get; set; }=String.Empty;
        public bool stopping { get; set; }=false;
    }
}
