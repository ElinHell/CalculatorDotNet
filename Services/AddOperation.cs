
namespace GaiaProject.Services
{
    using Project_Gaya.Interfaces;

    public class AddOperation : IOperation
        
       
    {
        internal string Name { get; set; }

        string IOperation.Name => Name;

        public AddOperation(string name)
        {
            Name = name;
        }

        public   double Execute(double a, double b)
        {
            return a + b;
        }

 
    }
}