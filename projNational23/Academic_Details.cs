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
    
    public partial class Academic_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Academic_Details()
        {
            this.REG_Number = new HashSet<REG_Number>();
        }
        [Key]
    [Display(Name ="Register Name")]
    [Required]
        public string Register_No { get; set; }

        [Display(Name = "Present Course")]
        [Required]
        public string Present_Course { get; set; }

        [Display(Name = "Course Period")]
        [Required]
        public int Course_Period { get; set; }

        [Display(Name = "Mode Of Study")]
        [Required]
        public string Mode_Of_Study { get; set; }

        [Display(Name = "Course State Date")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime Course_Start_Date { get; set; }

        [Display(Name = "Institution Name")]
        [Required]
        public string Institution_Name { get; set; }

        [Display(Name = "University Name")]
        [Required]
        public string University_Name { get; set; }

        [Display(Name = "Previous Course")]
        [Required]
        public string Previous_Course { get; set; }

        [Display(Name = "Degree Percentage")]
        [Required]
        public int Degree_Percentage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REG_Number> REG_Number { get; set; }
    }
}
