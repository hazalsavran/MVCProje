using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
     public class Context:DbContext
    {
        public DbSet<Abouth> Abouths { get; set; }//abouth sınıfın ismi, abouths ise sqlde tablonun ismi olcak
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact>  Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }

        //Buraya yazılmış dbset türündeki tüm alanları sql e yansıtacak



    }
}
