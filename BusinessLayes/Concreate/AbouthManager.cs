using BusinessLayes.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Concreate
{
    public class AbouthManager:IAbouthService
    {
        IAbouthDal _abouthDal;

        public AbouthManager(IAbouthDal abouthDal)
        {
            _abouthDal = abouthDal;
        }

        public void AbouthAdd(Abouth abouth)
        {
            _abouthDal.Insert(abouth);
        }

        public void AbouthDelete(Abouth abouth)
        {
            _abouthDal.Delete(abouth);
        }

        public void AbouthUpdate(Abouth abouth)
        {
            _abouthDal.Update(abouth);
        }

        public Abouth GetByID(int id)
        {
            return _abouthDal.Get(x => x.AbouthID == id);
        }

        public List<Abouth> GetList()
        {
            return _abouthDal.List();
        }
    }
}
