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
    
    public partial class Applicant_Details
    {  [Key]
    [Required]
    [Display(Name ="Applicant Id")]
        public int Applicant_Id { get; set; }
        [Required(ErrorMessage ="NO")]
        [Display(Name = "Name")]
        public string Login_Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime Date_Of_Birth { get; set; }
        [Required]
        [Display(Name = "Aadhar Number")]
        public string Aadhar_Number { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string Caste { get; set; }
        [Display(Name = "Scheme Id")]
        [Required]
        public Nullable<int> Scheme_Id { get; set; }
        [Display(Name = "Marital Status")]
        [Required]
        public string Marital_Status { get; set; }
        [Display(Name = "Economic Backward Class")]
        [Required]
        public string Economic_Backward_Class { get; set; }
        [Display(Name = "Economic Backward Class Certificate Number")]
        [Required]
        public string Economic_Backward_Class_Cert { get; set; }
        [Display(Name = "Father's Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Father_Name { get; set; }
        [Display(Name = "Mother's Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Mother_Name { get; set; }
        [Required]
        [Display(Name = "Annual Income")]
        [DataType(DataType.Currency)]
        public decimal Annual_Income { get; set; }
        [Display(Name = "Income certificate Number")]
        [Required]
        public string Income_Certificate_No { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone_Number { get; set; }
        [Required]
        public string Disability { get; set; }
        [Display(Name = "Disability Description")]
        [Required]
        public string Disabilty_Desc { get; set; }
        
        public virtual RegScheme_details RegScheme_details { get; set; }
        
        public virtual REG_Number REG_Number { get; set; }
        public virtual Login_Details Login_Details { get; set; }
        public virtual Scheme_Details Scheme_Details { get; set; }
        public virtual Files3 Files3 { get; set; }
    }
}
