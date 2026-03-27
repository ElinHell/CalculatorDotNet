using GaiaProject.Controllers;
using GaiaProject.Database;

namespace GaiaProject.Services
{
    public class CalculatorService
    {
        private readonly CalculatorDbContext _db;
        private readonly List<IOperation> _operations;

        public CalculatorService(CalculatorDbContext db, IEnumerable<IOperation> operations)
        {
            _db = db;
            _operations = new List<IOperation>{
             new AddOperation(),
             new SubtractOperation(),
             new MultiplyOperation(),
             new DivideOperation()
            };
        }

        public double CalculateAndSave(string operationName, double a, double b)
        {
            var op = _operations.FirstOrDefault(o => o.Name == operationName);
            if (op == null)
                throw new InvalidOperationException($"Operation '{operationName}' is not supported.");

            double result = op.Execute(a, b);

            //save to db
            _db.Operations.Add(new OperationHistory
            {
                A = a,
                B = b,
                Operation = operationName,
                Result = result,
                Date = DateTime.Now
            });

            _db.SaveChanges();
            return result;
        }
    }
}
