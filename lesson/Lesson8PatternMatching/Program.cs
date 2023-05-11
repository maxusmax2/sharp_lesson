using System.Diagnostics.Metrics;

object obj = new Car(new Engine(105));

var isCarWith105HP = obj is Car { Engine.Power:105};// 1 Задание

/*Console.WriteLine(isCarWith105HP);

if (obj is Car res && res.Engine.Power == 105)// 2 Задание 
{
    Console.WriteLine(res.Engine.Power);
}

static bool IsLowPowerVenicle(object value) => value switch// 3 Задание
{
    Car car when car.Engine.Power <100 => true,
    Motorcycle motocycle when motocycle.Engine.Power <100 => true,
    null => throw new ArgumentNullException(),
    _ => false,
};
*/
/*static bool IsLowPowerVenicle(object value, bool isElectro) => value switch// 4 Задание
{
    _ when isElectro => false,
    Car car when car.Engine.Power <100 => true,
    Motorcycle motocycle when motocycle.Engine.Power <100 => true,
    null => throw new ArgumentNullException(),
    _ => false,
};
*/
/*
static bool IsLowPowerVenicle(object value, bool isElectro) => value switch// 5 Задание
{
    SmartCar smartCar => smartCar.IsLowPowerVenicle,
    _ when isElectro => false,
    Car car when car.Engine.Power  <100 => true,
    Motorcycle motocycle when motocycle.Engine.Power <100 => true,
    null => throw new ArgumentNullException(),
    _ => false,
};
*/
static bool IsLowPowerVenicle(object value, bool isElectro) => value switch// 6 Задание
{
    SmartCar smartCar => smartCar.IsLowPowerVenicle,
    //_ when isElectro => false,
    Car car when car.Engine.Power  <100 && !isElectro => true,
    Motorcycle motocycle when motocycle.Engine.Power <100 && !isElectro => true,
    null => throw new ArgumentNullException(),
    _ => throw new ArgumentException(),
};
public record SmartCar(bool IsLowPowerVenicle);
public record Engine(int Power);
public class Car 
{
    public Engine Engine {  get;}

    public Car(Engine engine)
    {
        Engine = engine ?? throw new ArgumentNullException(nameof(engine));
    }
}

public record Motorcycle(Engine Engine);


