namespace cube;
using machine;
public class Cube: Machine
{

    public Cube(string _name, double _size)
        :base(_name)
    {
        base.type = "Cube";
        base.price = 0.10;
        base.volume = _size * _size *_size;
        base.description = "Cube with for " + _name;
        Task initiating = initiate(1000);
        initiating.Wait();
    }
}