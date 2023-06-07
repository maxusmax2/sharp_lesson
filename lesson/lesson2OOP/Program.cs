using static System.Console;

void SavePathToDB(string cargoId, NauticalMiles milesPath, Kilometer KmPath)
{
    WriteLine("Cargo id : {0}",cargoId);
    WriteLine("milesPath : {0}", milesPath.Value);
    WriteLine("KmPath: {0}", KmPath.Value);
}
var id = "test";
var kilometer1 = new Kilometer(100);
NauticalMiles nauticalMiles = new NauticalMiles(40);
var kilometer2 = new Kilometer(-1);
SavePathToDB(id, (NauticalMiles)kilometer1, (Kilometer)nauticalMiles + kilometer2);

public class Kilometer
{
    private const Double _kilometerToMilesCoefficient = 1.852;
    public  Double Value { get;}
    public Kilometer(Double value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }
    public static Kilometer operator +(Kilometer kilometer, NauticalMiles miles)
    {
        if (miles == null) throw new ArgumentNullException(nameof(miles));
        if (kilometer == null) throw new ArgumentException(nameof(kilometer));
        return new Kilometer(miles.Value * _kilometerToMilesCoefficient + kilometer.Value);
    }
    public static explicit operator NauticalMiles(Kilometer kilo)
    {
        if (kilo == null) throw new ArgumentException(nameof(kilo)); 
        return new NauticalMiles(kilo.Value * _kilometerToMilesCoefficient);
    }
    public static Kilometer operator *(Kilometer kilometer, Double val)
    {
        if (kilometer == null) throw new ArgumentNullException(nameof(kilometer));
        if (val < 0) throw new ArgumentOutOfRangeException(nameof(val));
        return new Kilometer(kilometer.Value * val);
    }
    public static Kilometer operator +(Kilometer kilo1, Kilometer kilo2)
    {   
        if (kilo1 == null) throw new ArgumentNullException(nameof(kilo1));
        return new Kilometer(kilo1.Value + kilo2.Value);
    }
}
public class NauticalMiles
{
    private const Double _milesToKilometerCoefficient = 0.539957;
    public Double Value { get;}
    public NauticalMiles(Double value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }
    public static explicit operator Kilometer(NauticalMiles miles) 
    {
        if (miles == null) throw new ArgumentNullException(nameof(miles));
        return new Kilometer(miles.Value * _milesToKilometerCoefficient);
    } 
    public static NauticalMiles operator +(NauticalMiles miles, Kilometer kilometer) 
    {
        if (miles == null) throw new ArgumentNullException(nameof(miles));
        if (kilometer == null) throw new ArgumentException(nameof(kilometer));
        return new NauticalMiles(miles.Value + kilometer.Value *_milesToKilometerCoefficient);
    }
    public static NauticalMiles operator +(NauticalMiles miles1, NauticalMiles miles2)
    {
        if (miles1 == null) throw new ArgumentNullException(nameof(miles1));
        if (miles2 == null) throw new ArgumentNullException(nameof(miles2));
        return new NauticalMiles(miles1.Value + miles2.Value);
    }
    public static NauticalMiles operator *(NauticalMiles miles, Double val)
    {
        if (miles == null) throw new ArgumentNullException(nameof(miles));
        if (val < 0) throw new ArgumentOutOfRangeException(nameof(val));
        return new NauticalMiles(miles.Value * val);
    }
}
