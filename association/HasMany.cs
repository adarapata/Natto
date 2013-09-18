using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class HasMany<T> where T : IDataAccessObject, new()
{
    public List<T> nodes { get; set; }
    public HasMany(Func<T, bool> predicate)
    {
        nodes = AcitiveRecord<T>.Where(predicate);
    }
}
