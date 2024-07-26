using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ServeAll.Core.Repository
{
    public interface IReadOnlyRepository<T> where T: class
    {
        IQueryable<T> All(string query);
        IEnumerable<T> SelectAll(string query); 
        IEnumerable<T> CreateQuery(string input);
        T FindBy(Expression<System.Func<T, bool>> expression);
        IEnumerable<T> FilterByIEnumerable(Expression<Func<T, bool>> predicate); 
        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
        IEnumerable<T> DistinctBy(IEnumerable<T> source, Func<T, string> keySelector);
     
    }
}