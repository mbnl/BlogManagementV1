using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Rol Türü :")]
        [MinLength(3, ErrorMessage = "3 karakterden az bir Rol girilemez."), MaxLength(150, ErrorMessage = "Gireceğiniz Rol 150 karakteri geçemez.")]
        [Required]
        public string RolAdi { get; set; }
    }
}
