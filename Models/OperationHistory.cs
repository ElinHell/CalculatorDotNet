namespace GaiaProject.Models
{
    public class OperationHistory
    {
        public int Id { get; set; } 
        public double A { get; set; }
        public double B { get; set; }
        public string? Operation { get; set; }
        public double Result { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
