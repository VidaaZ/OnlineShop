using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.UserInfo
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<SellerInfo> SellerInfos { get; set; }

    }

}
