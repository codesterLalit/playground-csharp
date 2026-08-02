namespace Play.fun;

public class CountdownEnumerator: IEnumerator<int>
{
    private readonly int _start;
    private  int _current;
    private  bool _started;

    public CountdownEnumerator(int start)
    {
        _start = start;
        _current = start;
        _started = false;
    }

    public int Current => _current;
    object System.Collections.IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if(_started == false)
        {
            _started = true;
            return true;
        }

        if(_current >= 0)
        {
            _current = _current - 1;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _current = _start;
        _started = false;
    }

    public void Dispose(){}
}