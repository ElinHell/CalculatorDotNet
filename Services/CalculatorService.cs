using GaiaProject.Database;
using GaiaProject.Models;
using Project_Gaya.DTOs;
using Project_Gaya.Interfaces;
using Project_Gaya.Models;
using Project_Gaya.Services;

namespace GaiaProject.Services
{
    public class CalculatorService
    {
        private readonly CalculatorDbContext _db;
       
        private readonly string _add;
        private readonly string _substract;
        private readonly string _multiply;
        private readonly string _divide;
  




        public CalculatorService(CalculatorDbContext db, IEnumerable<IOperation> operations)
        {
            _db = db;
        }
        

        public double CalculateAndSave(Enum opertaionType, double a, double b)
        {
            double result = 0;

            List<IOperation> _operations = new List<IOperation>
            {
                new AddOperation("Add"),
                new SubtractOperation("Substract"),
                new MultiplyOperation("Multiply"),
                new DivideOperation("Divide")
            };
            string _operationName = opertaionType.ToString();
            var operation = _operations.FirstOrDefault(o => o.Name == _operationName);
            if (operation == null) throw new Exception("Unknown operation");

             result = operation.Execute(a, b);


            //save to db
            _db.Operations.Add(new OperationHistory
            {
                A = a,
                B = b,
                Operation = opertaionType.ToString(),
                Result = result,
                Date = DateTime.Now
            });

            _db.SaveChanges();
            return result;
        }

        public CalculateResponse CalculateWithHistory (Enum opertaionType, double a, double b)
        {
            List<IOperation> _operations = new List<IOperation>
            {
                new AddOperation("Add"),
                new SubtractOperation("Substract"),
                new MultiplyOperation("Multiply"),
                new DivideOperation("Divide")
            };
            string _operationName = opertaionType.ToString();
            var operation = _operations.FirstOrDefault( o => o.Name == _operationName);
            if (operation == null) throw new Exception("Unknown operation");

            double result = operation.Execute(a, b);

            var record = new OperationHistory
            {
                A = a,
                B = b,
                Operation = _operationName,
                Result = result,
                Date = DateTime.Now
            };

            _db.Operations.Add(record);
            _db.SaveChanges();

            var last3Operations = _db.Operations
                .Where(x => x.Operation == _operationName)
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToList();

            var startOfThisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var countOps = _db.Operations.Count(x => x.Operation == _operationName && x.Date >= startOfThisMonth);

            return new CalculateResponse
            {
                Result = result,
                LastOperations = last3Operations,
                CountThisMonth = countOps
            };

        }
    }
}
