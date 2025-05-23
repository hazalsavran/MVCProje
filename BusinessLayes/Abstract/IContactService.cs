﻿using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Abstract
{
   public interface IContactService
    {
        List<Contact> GetList(string p);
        List<Contact> GetListAll();
        Contact GetByID(int id);
        void ContactAdd(Contact contact);


        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
