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
   public class AdminManager: IAdminService
    {
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            adminDal.Update(admin);
        }

        public Admin GetByID(int id)
        {

            return adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return adminDal.List();


        }
    }
}
