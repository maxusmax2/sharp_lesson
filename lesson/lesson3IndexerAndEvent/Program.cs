A a = new A(new int[] { 1, 42, 73, 37, 31 });
a.GetNotice += (object a, GetEventArgs e) => Console.WriteLine($"{e.Message} Длина массива : {((A)a).Length}");

a.SetNotice += (object a, SetEventArgs e) => Console.WriteLine($"{e.Message} Длина массива : {((A)a).Length}");
Console.WriteLine(a[0]);
a[4] = 11;
Console.WriteLine(a[4]);
class A
{
    public event EventHandler<GetEventArgs>? GetNotice;
    public event EventHandler<SetEventArgs>? SetNotice;
    private int[] _array;
    public int Length { get { return _array.Length; } }
    public A(int[] array)
    {
        if( array == null ) throw new ArgumentException(nameof(array));
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
            GetNotice?.Invoke(this, new GetEventArgs(index, _array[index]));
            return _array[index];
        }
        set 
        { 
            if(index < 0 || index > _array.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            SetNotice?.Invoke(this, new SetEventArgs( index, value));
            _array[index] = value; 
        }
    }
}
class SetEventArgs : EventArgs
{
    public string Message { get; }
    public int Index { get; }
    public int Value { get; }
    public SetEventArgs(int index, int value)
    {
        Message = $"Было присвоено {value} элементу с индексом {index}.";
        Index = index;
        Value = value;
    }
}
class GetEventArgs : EventArgs
{
    public string Message { get; }
    public int Index { get; }
    public int Value { get; }
    public GetEventArgs(int index, int value)
    {
        Message = $"Был получен элемент с индексом {index} равный {value}.";
        Index = index;
        Value = value;
    }
}
