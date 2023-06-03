using System;
namespace GatewayApi.Models
{
   public class AuthToken
   {
      public string Token { get; set; }
      public DateTime ExpirationDate { get; set; }
   }
}