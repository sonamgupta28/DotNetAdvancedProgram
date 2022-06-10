using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Catalog
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "text")]
        public string Name { get; set; }
        public string Image { get; set; }       
        public string ParentCategory { get; set; }        
    }
}
