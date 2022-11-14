namespace sphere;
using machine;
public class Sphere: Machine
{
    public double pie = 22/7;
    public Sphere(string _name, double _radius)
        :base(_name)
    {
        base.type = "Sphere";
        base.price = 0.15;
        base.volume = (_radius * _radius * _radius) * (4/3) *pie;
        base.description = "Sphere with for " + _name;
        Task initiating = initiate(3000);
        initiating.Wait();
    }
}