using static System.Console;

void SavePathToDB(string cargoId, NauticalMiles milesPath, Kilometer KmPath)
{
    WriteLine("Cargo id : {0}",cargoId);
    WriteLine("milesPath : {0}", milesPath.Value);
    WriteLine("KmPath: {0}", KmPath.Value);
}
var id = "test";
var kilometer1 = new Kilometer(100);
var nauticalMiles = new NauticalMiles(40);
var kilometer2 = new Kilometer(80);
SavePathToDB(id, (NauticalMiles)kilometer1, (Kilometer)nauticalMiles + kilometer2);

public class Kilometer
{
    public Double Value { get; set; }
    public Kilometer(Double value)
    {
        Value = value;
    }
    public static Kilometer operator +(Kilometer kilometer, NauticalMiles miles)
    {
        return new Kilometer(miles.Value * 1.852 + kilometer.Value);
    }
    public static explicit operator NauticalMiles(Kilometer kilo) => new NauticalMiles(kilo.Value * 0.539957);
    public static Kilometer operator *(Kilometer kilometer, Double val)
    {
        return new Kilometer(kilometer.Value * val);
    }
    public static Kilometer operator +(Kilometer kilo1, Kilometer kilo2)
    {
        return new Kilometer(kilo1.Value + kilo2.Value);
    }
}
public class NauticalMiles
{
    public Double Value { get; set; }
    public NauticalMiles(Double value) 
    {
        Value = value;
    }
    public static explicit operator Kilometer(NauticalMiles miles) => new Kilometer(miles.Value * 0.539957);
    public static NauticalMiles operator +(NauticalMiles miles, Kilometer kilometer) 
    {
        return new NauticalMiles(miles.Value + kilometer.Value * 0.539957 );
    }
    public static NauticalMiles operator +(NauticalMiles miles1, NauticalMiles miles2)
    {
        return new NauticalMiles(miles1.Value + miles2.Value);
    }
    public static NauticalMiles operator *(NauticalMiles miles, Double val)
    {
        return new NauticalMiles(miles.Value * val);
    }
}
