using System;
using System.Collections.Generic;
using System.Linq;

public class RandomService<T> where T : class
{
    public IEnumerable<T> Get(IEnumerable<T> list, int count) => list.OrderBy(f => Guid.NewGuid()).Take(count);
}