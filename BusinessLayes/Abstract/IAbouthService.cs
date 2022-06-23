using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Abstract
{
   public interface IAbouthService
    {
        List<Abouth> GetList();
        Abouth GetByID(int id);
        void AbouthAdd(Abouth abouth );

        
        void AbouthDelete(Abouth abouth);
        void AbouthUpdate(Abouth abouth);
    }
}
