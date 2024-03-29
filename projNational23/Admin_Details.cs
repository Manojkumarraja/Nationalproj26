//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projNational23
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Admin_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin_Details()
        {
            this.RegScheme_details = new HashSet<RegScheme_details>();
        }
    
        [Key]
        public int Admin_Id { get; set; }


        [Display(Name = "Login Id")]
        [Required(ErrorMessage = "Please Enter valid Login Id")]
        public string Login_Id { get; set; }


        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Designation")]
        [Required]
        public string Designation { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact_Number { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegScheme_details> RegScheme_details { get; set; }
        public virtual Login_Details Login_Details { get; set; }
    }
}
