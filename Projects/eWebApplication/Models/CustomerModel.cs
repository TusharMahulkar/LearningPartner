using System.ComponentModel.DataAnnotations;

namespace eShopWebApplication.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
      
        public string Email { get; set; } = null!;
       
        public string? Phone { get; set; }

        public bool IsActive { get; set; }
         
    }
}
