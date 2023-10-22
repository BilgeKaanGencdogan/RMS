using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace MVC.Entities
{
    public class UserResource
    {
        [Key]
        
        public int UserId { get; set; }

        public User User { get; set; }

        [Key]
        
        public int ResourceId { get; set; }

        public Resource Resource { get; set; }
    }
}
