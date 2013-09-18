using System.Collections;
using System;

public class HasOne<T> where T : IDataAccessObject, new()
{
    public T node { get; set; }
    public HasOne(Func<T, bool> predicate)
    {
        node = AcitiveRecord<T>.Find(predicate);
    }
}
