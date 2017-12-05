using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Etiket")]
    public class Etiket
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Etiket Adı :")]
        [MaxLength(100,ErrorMessage ="Etiket Adı 100 karakteri geçmemeli.")]
        [Required]
        public string EtiketAdi { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
