using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectECommerce.Models.DB
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        //[Required(ErrorMessage ="Address Line 1 is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        //[Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }
        //[Required(ErrorMessage = "Pincode is required")]
        public string Pincode { get; set; }
        //[Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public string Landmark { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //[RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Mobile is required")]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
