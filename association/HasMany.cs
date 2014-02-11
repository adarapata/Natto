using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Natto.Interface;

namespace Natto.Association {
    public class HasMany<T> where T : IDataAccessObject, new()
    {
        public List<T> nodes { get; set; }
        public HasMany(Func<T, bool> predicate)
        {
            nodes = ActiveRecord<T>.Where(predicate);
        }
    }
}