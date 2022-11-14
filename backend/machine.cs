namespace machine;
using System.Text.Json;
public class Machine: IComparable<Machine>
{
    public string status {get; set;}
    public string name {get; set;}
    public double volume {get; set;}

    public string description {get; set;}
    public string type {get; set;}

    public double price {get; set;}
    
    

    public Machine(string _name )
    {
        this.name = _name;
    }

    // public void createCube(string _name, double _size)
    // {
    //     Task initiating = initiate(1000);
    //     initiating.Wait();

    //     this.name = _name;
    //     this.volume = _size * _size * _size;
    // }

    public int CompareTo(Machine m){
        if(this.volume > m.volume)
            return 1;
        else if (this.volume == m.volume)
            return 0;
        return 1;
    }

    public async Task initiate(int waitTime)
    {
        this.status = "Calibrating...";
        Thread.Sleep(1000);
        this.status = "Creating part...";
        Thread.Sleep(waitTime);
        this.status = "Cleaning...";
        Thread.Sleep(1000);
    }
    new public string ToString()
    {
       return JsonSerializer.Serialize(this);

    }

}
