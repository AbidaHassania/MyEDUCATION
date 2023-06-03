using System.ComponentModel.DataAnnotations;
namespace GatewayApi.Models
{
   public class AuthUser
   {
      [Required]
      public string Username { get; set; }
      [Required]
      public string Password { get; set; }
   }

}
