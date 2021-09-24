using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //T neyi gönderiyosak o tablo
    {
        List<T> List();

        // T tablosundan p parametresi alıyoruz ve işlemleri yapıyoruz.
        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter); // şartlı listeleme işlemi


    }
}
