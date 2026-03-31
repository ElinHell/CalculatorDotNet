
namespace GaiaProject.Services
{
    using Project_Gaya.Interfaces;

    public class MultiplyOperation : IOperation

    {
        internal string Name { get; set; }
        string IOperation.Name => Name;
        public MultiplyOperation(string name)
        {
            Name = name;
        }

        public  double Execute(double a, double b)
        {
            return a * b;
        }
    }
}