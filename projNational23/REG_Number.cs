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
    
    public partial class REG_Number
    {
        public int Applicant_Id { get; set; }
        public string Register_Number { get; set; }
        public Nullable<int> Hsc_Rollno { get; set; }
        public Nullable<int> Ssc_Rollno { get; set; }
        public Nullable<int> MAT_SAT_Rollno { get; set; }
    
        public virtual Academic_Details Academic_Details { get; set; }
        public virtual AcademicHSC_Details AcademicHSC_Details { get; set; }
        public virtual AcademicSSC_Details AcademicSSC_Details { get; set; }
        public virtual Applicant_Details Applicant_Details { get; set; }
        public virtual NationalEdu_Details NationalEdu_Details { get; set; }
    }
}
