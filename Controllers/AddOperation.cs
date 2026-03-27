namespace GaiaProject.Controllers
{
    public class AddOperation : IOperation
    {
        public string Name => "add";
        public double Execute(double a, double b) => a + b;
    }

    public class SubtractOperation : IOperation
    {
        public string Name => "subtract";
        public double Execute(double a, double b) => a - b;
    }

    public class MultiplyOperation : IOperation
    {
        public string Name => "multiply";
        public double Execute(double a, double b) => a * b;
    }

    public class DivideOperation : IOperation
    {
        public string Name => "divide";
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("You can not divide by zero!");
            return a / b;
        }
    }
}
