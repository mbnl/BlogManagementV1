using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Kategori Adı :")]
        [MaxLength(150,ErrorMessage ="Kategori Adı 150 karakteri geçmemeli.")]
        [Required]
        public string KategoriAdi { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
