using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcEmployeeModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage="This Field is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
        public string FamilyName { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="Email not valid")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(14,MinimumLength =10,ErrorMessage ="Invalide phone number")]
        public string PhoneNumber { get; set; }
        public Nullable<bool> Status { get; set; }

    }
}