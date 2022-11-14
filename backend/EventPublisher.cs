using System.Collections.ObjectModel;
delegate void MyEventHandler();

class MyEventPublisher{
    public event MyEventHandler MyHandler;

    public string PartIsReady(){
        return "Part is ready";
        MyHandler();
    }
}