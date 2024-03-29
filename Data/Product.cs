using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAFTLECOME.Data
{

    [Table("Product")]
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
