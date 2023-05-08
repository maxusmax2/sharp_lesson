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

    private bool iterationFlag = false;
    private int _count = 0;
    private QueueFrame _first;
    private QueueFrame _last;
    
    public T Dequeue()
    {
        if(_count <= 0 || _first == null || iterationFlag) throw new InvalidOperationException();
        T item = _first.Item;
        _first = _first.Next;
        _count--;
        return item;
    }

    public void Enqueue(T item)
    {
        if (iterationFlag) throw new InvalidOperationException();
        ArgumentNullException.ThrowIfNull(item);
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
    }

    public IEnumerator<T> GetEnumerator()
    {
        iterationFlag = true;
        return new QueueIterator(_count,_first,()=>iterationFlag = true,()=>iterationFlag = false);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
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
        private QueueFrame _frame;
        private Action _startIterate;
        private Action _stopIterate;

        public QueueIterator(int count, QueueFrame frame, Action startIterate,Action stopIterate)
        {
            _count = initCount = count;
            initFrame = _frame = new QueueFrame(default(T), frame);
            _startIterate = startIterate;
            _stopIterate = stopIterate;
        }

        public T Current =>_frame.Item;

        object IEnumerator.Current => _frame.Item;

        public void Dispose() { }

        public bool MoveNext()
        {
            _startIterate();
            if(_count > 0 && _frame!=null) 
            {
                _count--;
                _frame = _frame.Next;
                return true;
            }
            _stopIterate();
            return false;
        }

        public void Reset()
        {
            _count = initCount;
            _frame = initFrame;
        }
    }
}
