using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);
        void HeadingDelete(Heading heading);
        Heading GetByID(int id);
        void HeadingUpdate(Heading heading);

    }
}
