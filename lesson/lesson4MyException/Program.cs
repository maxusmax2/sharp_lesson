[Serializable]
class MyException : Exception 
{
    public string MyProperty { get; }
    public MyException() { }
    public MyException(string message) : base(message) { }
    public MyException(string message, Exception innerException) : base(message, innerException) { }
    public MyException(string message, string myProperty) 
        : this(message) 
    {
        MyProperty = myProperty;
    }

}
