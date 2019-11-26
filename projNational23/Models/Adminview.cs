using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace projNational23.Models
{
    public class Adminview
    {
        [Key]
        [Display(Name = "Login ID")]
        public string Login_Id { get; set; }
        [Display(Name = "Applicant ID")]
        public int Applicant_Id { get; set; }

        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Date Of Birth")]

        public System.DateTime Date_Of_Birth { get; set; }

        [Display(Name = "Aadhar Number")]
        public string Aadhar_Number { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Religion")]
        public string Religion { get; set; }
        [Display(Name = "Caste")]
        public string Caste { get; set; }

        [Display(Name = "Scheme ID")]
        public Nullable<int> Scheme_Id { get; set; }

        [Display(Name = "Economic Backward Class")]
        public string Economic_Backward_Class { get; set; }

        [Display(Name = "Economic Backward Certificate Number")]
        public string Economic_Backward_Class_Cert { get; set; }

        [Display(Name = "Father Name")]

        public string Father_Name { get; set; }
        [Display(Name = "Mother Name")]

        public string Mother_Name { get; set; }

        [Display(Name = "Annual Income")]
        [DataType(DataType.Currency)]
        public decimal Annual_Income { get; set; }

        [Display(Name = "Income Certificate Number ")]
        [DataType(DataType.Text)]
        public string Income_Certificate_No { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
        [Display(Name = "Disability")]
        public string Disability { get; set; }

        [Display(Name = "Register Number")]

        public string Register_No { get; set; }

        [Display(Name = "Present Course")]
        [DataType(DataType.Text)]
        public string Present_Course { get; set; }

        [Display(Name = "Course Period")]
        [DataType(DataType.Text)]
        public int Course_Period { get; set; }

        [Display(Name = "Mode Of Study")]

        public string Mode_Of_Study { get; set; }

        [Display(Name = "Course Start Date")]
        [DataType(DataType.Date)]
        public System.DateTime Course_Start_Date { get; set; }

        [Display(Name = "Institution Name")]

        public string Institution_Name { get; set; }


        [Display(Name = "Degree Percentage")]

        public int Degree_Percentage { get; set; }

        [Display(Name = "HSC Roll Number")]

        public int Roll_No { get; set; }

        [Display(Name = "HSC Marks Percentage")]

        public int Marks_Percentage { get; set; }

        [Display(Name = "SSC Roll Number")]
        public int sscRoll_No { get; set; }

        [Display(Name = "SSC Marks Percentage")]

        public int sscMarks_Percentage { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Eligibility Test Roll No")]
        public int MAT_SAT_Rollno { get; set; }

        [Display(Name = "Eligibility Test Score")]
        public int MAT_SAT_Score { get; set; }

        [Display(Name = "Eigth Class Percentage")]
        public int Eighth_class_per { get; set; }

        [Display(Name = "Nineth Class Percentage")]
        public int Nineth_class_per { get; set; }

        [Display(Name = "Eleventh Class Specialization")]
        public string Eleventh_specialization { get; set; }
        [Display(Name = "Admin ID")]
        public Nullable<int> Admin_Id { get; set; }

        [Display(Name = "Date Of Apply")]
        [DataType(DataType.Date)]
        public System.DateTime Date_of_apply { get; set; }

        [Display(Name = "Smart Card Id")]
        public string Smart_Card_Id { get; set; }
        [Display(Name = "Application Status")]
        public string App_status { get; set; }

        [Display(Name = "Account Number")]
        public string Acc_No { get; set; }

        [Display(Name = "Bank Name")]
        public string Bank_name { get; set; }

        [Display(Name = "IFSC Code")]
        public string IFSC_CODE { get; set; }

        [Display(Name = "Payment Status")]
        public string Payment_Status { get; set; }

        [Display(Name = "Funded Amount")]
        public Nullable<decimal> Funded_amt { get; set; }
        [Display(Name = "Fund Transferred Date")]

        public Nullable<System.DateTime> Fund_transfer_date { get; set; }
        public byte[] Photo { get; set; }

        [Display(Name = "Aadhar Card")]
        public byte[] Aadhar_Card { get; set; }

        [Display(Name = "SSC Marksheet")]
        public byte[] SSC_MarkSheet { get; set; }

        [Display(Name = "HSC Marksheet")]
        public byte[] HSC_Marksheet { get; set; }

        [Display(Name = "Degree Marksheet")]
        public byte[] Degree_Marksheet { get; set; }

        [Display(Name = "Acknowledgement marksheet Class 8")]
        public byte[] AcknowledgeCert_Class8 { get; set; }

        [Display(Name = "Acknowledgement marksheet Class 9")]
        public byte[] AcknowledgeCert_Class9 { get; set; }

        [Display(Name = "Acknowledgement marksheet Class 11")]
        public byte[] AcknowledgeCert_Class11 { get; set; }

        [Display(Name = "Community Certificate")]
        public byte[] Community_Certificate { get; set; }

        [Display(Name = "Nativity Certificate")]
        public byte[] Nativity_Certificate { get; set; }

        [Display(Name = "ID Card")]
        public byte[] Id_Card { get; set; }
        [Display(Name = "Fee Receipt")]
        public byte[] Fees_Receipt { get; set; }
    }
}