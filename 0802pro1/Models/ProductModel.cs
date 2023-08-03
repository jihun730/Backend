using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _0802pro1.Models
{
    public class ProductModel
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }

        public string MyIdentityUserId { get; set; }
        public MyIdentityUser MyIdentityUser { get; set; }

    }
}
