using Project_Gaya.Interfaces;

namespace Project_Gaya.Services
{
    public class SubtractOperation : IOperation
    {
        internal string Name { get; set; }
        string IOperation.Name => Name;

        public SubtractOperation(string name)
        {
            Name = name;
        }

        public   double Execute(double a, double b)
        {
            return a - b;
        }
    }
}
