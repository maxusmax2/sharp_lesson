using System.Collections;
foreach (var item in GetEnumerable().MyWhere(x => x%2 == 0).Take(5)) 
{
    Console.WriteLine(item);
}
IEnumerable<int> GetEnumerable() 
{
    int i = 0 ;
    while (true) 
    {
        yield return i++;
    }
}
public static class ExtensionMethod 
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> enumerable,Func<T,bool> predicate)
    { 
        if(enumerable == null) throw new ArgumentNullException(nameof(enumerable));
        return new MyEnumerableWhere<T>(enumerable.GetEnumerator(),predicate);
    }
    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> enumerable, int count)
    {
        if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
        return new MyEnumerableTake<T>(enumerable.GetEnumerator(), count);
    }
} 
public class MyEnumerableWhere<T> : IEnumerable<T>
{
    
    private IEnumerator<T> _en;
    private Func<T, bool> _predicate;
    public MyEnumerableWhere(IEnumerator<T> en, Func<T, bool> predicate) 
    {
        _en = en;
        _predicate = predicate;
    }
    public IEnumerator<T> GetEnumerator() 
    {
        return new MyEnumeratorWhere<T>(_en,_predicate);
    }
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
    class MyEnumeratorWhere<T> : IEnumerator<T>
    {

        private int _currentIndex;
        private Func<T, bool> _predicate;
        private IEnumerator<T> _en;
        public MyEnumeratorWhere(IEnumerator<T> en, Func<T, bool> predicate)
        {
            _en = en;
            _predicate = predicate;
            _currentIndex = -1;
        }

        public bool MoveNext() 
        {
            while (_en.MoveNext()) 
            {
                if (_predicate(Current))
                    return true;
            }
            return false; 
        }
        public void Reset()
        {
            _currentIndex = -1;
        }

        public T Current
        {
            get { return _en.Current; }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        void IDisposable.Dispose(){}
    }
}
public class MyEnumerableTake<T> : IEnumerable<T>
{

    private IEnumerator<T> _en;
    private int _count;
    public MyEnumerableTake(IEnumerator<T> en, int count)
    {
        _en = en;
        _count = count;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumeratorTake<T>(_en, _count);
    }
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
    class MyEnumeratorTake<T> : IEnumerator<T>
    {

        private int _count;
        private int _currentIndex;
        private IEnumerator<T> _en;
        public MyEnumeratorTake(IEnumerator<T> en, int count)
        {
            _en = en;
            _count = count;

        }

        public bool MoveNext()
        {
            _currentIndex++;
            _en.MoveNext();
            if (_currentIndex >= _count) 
            {
                return false;
            }
            return true;
            
        }
        public void Reset()
        {
            _currentIndex = -1;
        }

        public T Current
        {
            get { return _en.Current; }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        void IDisposable.Dispose() { }
    }
}
