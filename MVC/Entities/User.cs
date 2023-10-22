#nullable disable
using MVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC.Entities
{
    public class User
    {
        ///* private int _id; // alan (field)

        // public int GetId()// davranış (behavior veya method)
        // {
        //     return _id;
        // }

        // public void SetId(int id)
        // {
        //     _id = id;
        // }*/

        [Key] //primary key, opsiyonel ama entity framework bunu addan priamry key olarak yakalıyor
        public int Id { get; set; } // özellik (property)

        public string Guid { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string UserName { get; set; } //referans typelar nullable olsun mu olmasın mı diye kontrol edilmelidir

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public Statuses Status { get; set; } //enum örneği

        public DateTime? BirthDate { get; set; } // ? DateTime structure tipinde bir reference type olduğu için nullable 
                                                 // olsun dedik ve ? koyduk

        public int RoleId { get; set; } // foreign key

        public Role Role { get; set; } // eğer bi yerde foreign key oluşturuyorsan onun tipinde,ki burda Role oluyor, 
                                       //referans key de oluşturmalıyız (navigational property)

        public List<UserResource> UserResource { get; set; }
    }
}
