namespace GaiaProject.Controllers
{
    public interface IOperation
    {
        string Name { get; }
        double Execute(double a, double b);
    }
}
