using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "It should be a Maximum of 50 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "It should be a Maximum of 50 Characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Popular")]
        public bool Popular { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Onay")]
        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
