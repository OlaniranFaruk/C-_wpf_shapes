namespace cylinder;
using machine;
public class Cylinder: Machine
{
    public double pie = 22/7;
    public Cylinder(string _name, double _radius, double _height)
        :base(_name)
    {
        base.type = "Cylinder";
        base.price = 0.15;
        base.volume = (_radius * _radius) * pie * _height;
        base.description = "Cylinder with for " + _name;
        Task initiating = initiate(2000);
        initiating.Wait();
    }
}