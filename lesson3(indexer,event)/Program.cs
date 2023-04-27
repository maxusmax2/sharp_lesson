using System.Reflection.Metadata.Ecma335;

A a = new A(new int[] { 1, 42, 73, 37, 31 });
a.IndexingNotice += (A sender, AEventArgs e) => Console.WriteLine(e.Message + $"Длина массива : {sender.Length}");

Console.WriteLine(a[0]);
a[4] = 11;
Console.WriteLine(a[4]);
class A
{
    public delegate void AHandler(A sender, AEventArgs e);
    public event AHandler? IndexingNotice;

    private int[] _array;
    public int Length { get { return _array.Length; } }
    public A(int[] array)
    {
        _array = array;
    }
    public int this[int index]
    {
        get 
        {
            if(index < 0 || index > _array.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            IndexingNotice?.Invoke(this, new AEventArgs($"Был получен элемент с индексом {index} равный {_array[index]}.", index, _array[index]));
            return _array[index];
        }
        set 
        { 
            if(index < 0 || index > _array.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            IndexingNotice?.Invoke(this, new AEventArgs($"Было присвоено {value} элементу с индексом {index}.", index, value));
            _array[index] = value; 
        }
    }
}
class AEventArgs : EventArgs
{
    public string Message { get; }
    public int Index { get; }
    public int Value { get; }
    public AEventArgs(string message, int index, int value)
    {
        Message = message;
        Index = index;
        Value = value;
    }
}
