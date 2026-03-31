
namespace GaiaProject.Services
{
    using Project_Gaya.Interfaces;

    public class DivideOperation : IOperation

    {

        internal string Name { get; set; }
        string IOperation.Name => Name;

        public DivideOperation(string name)
        {
            Name = name;
        }

        public  double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("You can not divide by zero!");

            return Math.Round(a / b, 2);
        }
    }
}