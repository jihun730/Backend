using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace _0802pro1.Models
{
    public class MyIdentityUser : IdentityUser
    {
        public string UserNickname { get; set; }

        public List<ProductModel> Products { get; } = new List<ProductModel>();
    }
}
