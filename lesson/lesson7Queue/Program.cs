using System.Collections;

var queue = new MyQueue<int>();
public interface IQueue<T> : IEnumerable<T>
{
    int Count { get; }
    T Dequeue();
    void Enqueue(T item);
}
public class MyQueue<T> :IQueue<T>
{
    public int Count { get { return _count; }  }

    private int _version;
    private int _count = 0;
    private QueueFrame _first;
    private QueueFrame _last;
    
    public T Dequeue()
    {
        if(_count <= 0 || _first == null ) throw new InvalidOperationException();
        T item = _first.Item;
        _first = _first.Next;
        _count--;
        _version++;
        return item;
    }

    public void Enqueue(T item)
    {
        var frame = new QueueFrame(item, _last);
        
        if (_count == 0 && _last == null)
        {
            _first = _last = frame;
        }
        else 
        {
            _last.Next = frame;
            _last = frame;
        }
        _count++;
        _version++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        
        return new QueueIterator(_count,_first,()=>_version);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    class QueueFrame
    {
        public T Item { get; }
        public QueueFrame Next { get; set; }
        public QueueFrame(T item, QueueFrame next)  
        {
            Next = next;
            Item = item;
        }
    }
    class QueueIterator : IEnumerator<T>
    {
        private readonly int initCount;
        private readonly QueueFrame initFrame;
        private int _count;
        private int _version;
        private QueueFrame _frame;
        private Func<int> getVersion;

        public QueueIterator(int count, QueueFrame frame, Func<int> getVersion)
        {
            
            _count = initCount = count;
            initFrame = _frame = new QueueFrame(default(T), frame);
            this.getVersion = getVersion;
            _version = this.getVersion();
        }

        public T Current =>_frame.Item;

        object IEnumerator.Current => _frame.Item;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_version != getVersion()) throw new InvalidOperationException();
            if(_count > 0 && _frame!=null) 
            {
                _count--;
                _frame = _frame.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _count = initCount;
            _frame = initFrame;
        }
    }
}
