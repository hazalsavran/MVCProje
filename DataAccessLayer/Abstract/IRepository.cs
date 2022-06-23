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

        T Get(Expression<Func<T, bool>> filter); // T tablosundan silme işlemi için 1 değer getiricez (ID)
                                                 // Expression func ile de bir şarta göre yapacağımızı belirtiyoruz
                                                 // bu şartın businesslayerdaki ICategoryService içinde id olduğunu söylüyoruz

        List<T> List(Expression<Func<T, bool>> filter); // şartlı listeleme işlemi


    }
}
