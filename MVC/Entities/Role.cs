#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MVC.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        //public ICollection<User> Users { get; set; }

        //public IEnumerable<User> MyProperty { get; set; }
        //public IList<User> MyProperty { get; set; }

        public List<User> Users { get; set; }

    }
}
