using System.ComponentModel.DataAnnotations;

namespace WebGame.Models.Account
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
