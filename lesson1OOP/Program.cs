using static System.Console;

Transport[] transports = new Transport[] {new Car(),new Airplane(),new Boat()};

foreach(Transport transport in transports) 
{
    transport.Move();
}

public abstract class Transport 
{
    public abstract void Move();
}

class Car : Transport
{
    public override void Move()
    {
        WriteLine("Ехать");
    }
}

class Airplane : Transport
{
    public override void Move()
    {
        WriteLine("Летать");
    }
}

class Boat : Transport
{
    public override void Move()
    {
        WriteLine("Плыть");
    }
}