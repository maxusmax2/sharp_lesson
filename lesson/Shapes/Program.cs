public class ChangeEventArgs : EventArgs 
{
    public double Perimeter { get; }
    public double Square { get; }

    public ChangeEventArgs(double perimeter, double square) 
    {
        Perimeter = perimeter;
        Square = square;
    }
}
public interface INotifyingChange
{
    event EventHandler<ChangeEventArgs> ChangeParamEvent;
}
struct Point 
{
    public Point(double x, double y) 
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public double GetSideLength(Point secondPoint) 
    {
        return Math.Sqrt(Math.Pow(secondPoint.X - X, 2) + Math.Pow(secondPoint.Y - Y, 2));
    }
}

abstract class Shape : INotifyingChange
{
    public abstract event EventHandler<ChangeEventArgs> ChangeParamEvent;

    public abstract double Square { get; }
    public abstract double Perimeter { get; }
}

class Triangle : Shape
{
    public override event EventHandler<ChangeEventArgs> ChangeParamEvent;
    private Point _point1, _point2, _point3;

    public Triangle(Point point1, Point point2, Point point3)
    {
        _point1 = point1;
        _point2 = point2;
        _point3 = point3;
    }
    public Triangle(Point point1, Point point2, Point point3, EventHandler<ChangeEventArgs> eventHandler) : this(point1, point2, point3)
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        ChangeParamEvent = eventHandler;
    }

    public override double Square
    {
        get
        {
            double p = Perimeter / 2;
            return Math.Sqrt( p * (p - _point1.GetSideLength(_point2)) * (p - _point2.GetSideLength(_point3)) * (p - _point3.GetSideLength(_point1)));
        }
    }
    public override double Perimeter 
    { 
        get 
        {
            return _point1.GetSideLength(_point2) + _point2.GetSideLength(_point3) + _point3.GetSideLength(_point1);
        } 
    }

    public Point Point1
    {
        get
        {
            return _point1;
        } 
        set 
        {
            _point1 = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter,Square));
        } 
    }
    public Point Point2
    {
        get
        {
            return _point2;
        }
        set
        {
            _point2 = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter, Square));
        }
    }
    public Point Point3
    {
        get
        {
            return _point3;
        }
        set
        {
            _point3 = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter, Square));
        }
    }
    protected virtual void OnChangeParamEvent(ChangeEventArgs e)
    {
        EventHandler<ChangeEventArgs> handler = ChangeParamEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}

class Quadrate : Shape 
{
    public override event EventHandler<ChangeEventArgs> ChangeParamEvent;
    private double _sideLength;
    private Point _point;

    public Quadrate(double length, Point point) 
    {
        _point = point;
        _sideLength = length;
    }
    public Quadrate(double length, Point point, EventHandler<ChangeEventArgs> eventHandler) : this(length,point)
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        ChangeParamEvent = eventHandler;
    }

    public override double Perimeter
    {
        get
        {
            return _sideLength * 4;
        }
    }
    public override double Square
    {
        get
        {
            return Math.Pow(_sideLength, 2);
        }
    }

    public double SideLength
    {
        get
        {
            return _sideLength;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(SideLength));
            }
            _sideLength = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter, Square));
        }
    }
    public Point Point
    {
        get
        {
            return _point;
        }
        set
        {
            _point = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter, Square));
        }
    }
    protected virtual void OnChangeParamEvent(ChangeEventArgs e)
    {
        EventHandler<ChangeEventArgs> handler = ChangeParamEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}

class Circle : Shape 
{
    public override event EventHandler<ChangeEventArgs> ChangeParamEvent;
    private double _radius;
    private Point _center;

    public Circle(double radius, Point center) 
    {
        _radius = radius;
        _center = center;
    }
    public Circle(double radius, Point center, EventHandler<ChangeEventArgs> eventHandler) : this(radius, center) 
    {
        ArgumentNullException.ThrowIfNull(eventHandler);
        ChangeParamEvent = eventHandler;
    }

    public override double Perimeter 
    {
        get 
        {
            return 2 * Math.PI * _radius;
        }
    }
    public override double Square
    {
        get 
        {
            return Math.PI * Math.Pow(_radius, 2); 
        }
    }

    public double Radius 
    {
        get 
        {
            return _radius;
        }
        set 
        {
            if(value <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(Radius));
            }
            _radius = value;
            OnChangeParamEvent(new ChangeEventArgs(Perimeter, Square));
        }
    }
    public Point Center 
    {
        get 
        {
            return _center;
        }
        set 
        {
            _center = value;
        }
    }
    protected virtual void OnChangeParamEvent(ChangeEventArgs e)
    {
        EventHandler<ChangeEventArgs> handler = ChangeParamEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}
