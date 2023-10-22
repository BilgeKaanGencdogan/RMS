#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MVC.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public double? Score { get; set; } // zorunlu olmasın diye ? kodyuk bullable

        public DateTime Date { get; set; }

        public List<UserResource> UserResource { get; set; }
    }
}
