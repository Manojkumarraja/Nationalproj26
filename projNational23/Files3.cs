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

    public partial class Files3
    {

        [Key]
        [Display(Name = "Applicant Id")]
        public int Applicant_Id { get; set; }

        [Display(Name = "Applicant Photo")]
        public string Photo { get; set; }

        [Display(Name = "Adhar Card")]
        public string Aadhar_Card { get; set; }

        [Display(Name = "SSC Marksheet")]
        public string SSC_MarkSheet { get; set; }

        [Display(Name = "HSC Marksheet")]
        public string HSC_Marksheet { get; set; }

        [Display(Name = "Degree Marksheet")]
        public string Degree_Marksheet { get; set; }
      

        [Display(Name = "Community Certificate")]
        public string Community_Certificate { get; set; }

        [Display(Name = "Nativity Certificate")]
        public string Nativity_Certificate { get; set; }

        
        [Display(Name = "Income Certificate")]
        public string Income_Certificate { get; set; }
    
        public virtual Applicant_Details Applicant_Details { get; set; }
    }
}