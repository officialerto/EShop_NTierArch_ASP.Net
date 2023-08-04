using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        [Display(Name = "Adet")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Kullanıcı")]
        public int UserId { get; set; }
    }
}
