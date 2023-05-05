using System.Collections;
using static System.Console;

    var fromOne = iterate(1);

    var fromTwo = iterate(2);
    var fromThree = iterate(3);
    WriteLine(string.Join(',', fromThree.Take(4)));
    var fromFour = iterate(4);
    WriteLine(fromFour.Count());

IEnumerable<int> iterate(int startingValue)
{
    if (startingValue is 2 or 5)
    {
        throw new ArgumentException("Starting from 2 or 5 is not allowed");
    }
    return new MyIEnumerable(startingValue);
    
}
public class MyIEnumerable : IEnumerable<int>
{
    private int _startingValue;
    public MyIEnumerable(int startingValue) 
    {
        _startingValue = startingValue;
    }
    public IEnumerator<int> GetEnumerator()
    {
        return new MyIEnumerator(_startingValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
public class MyIEnumerator : IEnumerator<int>
{
    private int _value;
    public MyIEnumerator(int startingValue) 
    {
        _value = startingValue;
    }
    public int Current => _value;

    object IEnumerator.Current => throw new NotImplementedException();

    void IDisposable.Dispose() => throw new NotImplementedException();

    public bool MoveNext()
    {
        _value++;
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}


