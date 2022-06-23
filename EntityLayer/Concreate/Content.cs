using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        // Content yazar (yazı kim tarafından yazıldı?)
        // content başlık (hangi başlığa yazıldı?)

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; } //başlık ve içeriği ilişkili hale getirdik
        public int? WriterID { get; set; } //int? demek o alanı nullable yapar

        public virtual Writer Writer { get; set; }

    }
}
