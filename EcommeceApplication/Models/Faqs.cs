using System.ComponentModel.DataAnnotations;

namespace EcommeceApplication.Models
{
    public class Faqs
    {
        [Key]
        public int faq_id { get; set; }
        public int faq_question { get; set; }
        public int faq_answer { get; set; }
    }
}
