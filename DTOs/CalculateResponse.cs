using GaiaProject.Models;

namespace Project_Gaya.DTOs
{
    public class CalculateResponse
    {
        public double Result { get; set; }

        public List<OperationHistory> LastOperations { get; set; }

        public int CountThisMonth { get; set; }
    }
}


