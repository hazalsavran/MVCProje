using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Abouth
    {
        [Key]
        public int AbouthID { get; set; }
        [StringLength(1000)]
        public string AbouthDetails1 { get; set; }
        [StringLength(1000)]
        public string AbouthDetails2 { get; set; }
        [StringLength(100)]
        public string AbouthImage1 { get; set; }
        public string AbouthImage2 { get; set; }

    }
}
