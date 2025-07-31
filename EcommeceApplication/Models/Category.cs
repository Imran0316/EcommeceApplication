using System.ComponentModel.DataAnnotations;

namespace EcommeceApplication.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        public int Category_name { get; set; }
    }
}
