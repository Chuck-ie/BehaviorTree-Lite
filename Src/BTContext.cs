using System.Collections.Generic;
using System.Diagnostics;

public class BTContext
{
    private readonly Dictionary<string, object> _context = [];

    public void Reset()
    {
        foreach (KeyValuePair<string, object> pair in _context)
            _context[pair.Key] = null;
    }

    public T Get<T>(string key)
    {
        Debug.Assert(_context.ContainsKey(key), $"BTContext key {key} not present");
        return (T)_context[key];
    }

    public void Set<T>(string key, T value)
    {
        Debug.Assert(_context.ContainsKey(key), $"BTContext key {key} not present");
        _context[key] = value;
    }
}
