using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATweb.DATA.EF.Models
{
    internal class Metadata
    {
        #region Courses
        public class CoursesMetadata
        {
            public int CourseId { get; set; }

            [Required(ErrorMessage = "*Course Name is required")]
            [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
            [Display(Name = "Course")]
            public string CourseName { get; set; } = null!;
            [Required(ErrorMessage = "*Course Description is required")]
            [Display(Name = "Description")]
            public string CourseDescription { get; set; } = null!;
            [Required(ErrorMessage = "*Credit Hours is required")]
            [Range(0,16,ErrorMessage = "*Credit hours range between 0 (unaccredited) to 16 accredited hours")]
            [Display(Name = "Credit Hours")]
            public byte CreditHours { get; set; }
            [StringLength(250, ErrorMessage = "*Cannot exceed 250 characters")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string? Curriculum { get; set; }
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [DataType(DataType.MultilineText)]
            [StringLength(500, ErrorMessage = "*Cannot exceed 500 characters")]
            public string? Notes { get; set; }
            [Display(Name = "Currently Active?")]
            public bool IsActive { get; set; }
        }
        #endregion

        #region SchelduleClassStatuses
        public class ScheduledClassStatusMetadata
        {
            public int Scsid { get; set; }
            [Required]
            [StringLength(50, ErrorMessage ="*Cannot exceed 50 characters")]
            [Display(Name = "Schedule Class Status")]
            public string Scsname { get; set; } = null!;
        }
        #endregion

        #region ScheduledClasses
        public class ScheduledClassMetadata
        {
            public int ScheduledClassId { get; set; }
            [Required(ErrorMessage = "CourseId is required")]
            [Range(0, int.MaxValue)]
            public int CourseId { get; set; }
            [Required(ErrorMessage = "Start Date is required")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyy format
            public DateTime StartDate { get; set; }
            [Required(ErrorMessage = "End Date is required")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyy format
            public DateTime EndDate { get; set; }
            [Required(ErrorMessage = "Instructor is required")]
            [StringLength(40, ErrorMessage = "*Cannot exceed 40 characters")]
            public string InstructorName { get; set; } = null!;
            [Required(ErrorMessage = "Location is required")]
            [StringLength(20, ErrorMessage = "*Cannot exceed 20 characters")]
            public string Location { get; set; } = null!;
            [Required(ErrorMessage = "Schedule Class Status is required")]
            [Range(0, int.MaxValue)]
            public int Scsid { get; set; }
        }


        #endregion

        #region Enrollments
        public class EnrollmentMetadata
        {
            public int EnrollmentId { get; set; }
            [Required(ErrorMessage = "*Student ID required")]
            [Range(0, int.MaxValue)]
            public int StudentId { get; set; }
            [Required(ErrorMessage = "Schedule Class ID is required")]
            [Range(0, int.MaxValue)]
            public int ScheduledClassId { get; set; }
            [Required(ErrorMessage = "Enrollment Date is required")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyy format
            public DateTime EnrollmentDate { get; set; }
        }


        #endregion

        #region StudentStatuses
        public class StudentStatusMetadata
        {
            public int Ssid { get; set; }
            [Required(ErrorMessage = "*Student Status required")]
            [StringLength(30, ErrorMessage = "*Cannot exceed 30 characters")]
            [Display(Name = "Student Status")]
            public string Ssname { get; set; } = null!;
            [StringLength(250, ErrorMessage = "*Cannot exceed 250 characters")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [Display(Name = "Description")]
            public string? Ssdescription { get; set; }
        }
        #endregion

        #region Students
        public class StudentMetadata
        {
            public int StudentId { get; set; }
            [StringLength(20)]
            [Display(Name = "First Name")]
            [Required(ErrorMessage = "*First Name is required")]
            public string FirstName { get; set; } = null!;
            [StringLength(20)]
            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "*Last Name is required")]
            public string LastName { get; set; } = null!;
            [Required(ErrorMessage = "*House is required")]
            [StringLength(15)]
            public string Major { get; set; } = null!;
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
            public string? Address { get; set; }
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(25, ErrorMessage = "*Cannot exceed 25 characters")]
            public string? City { get; set; }
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(2, ErrorMessage = "*Cannot exceed 2 characters")]
            public string? State { get; set; }
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
            [DataType(DataType.PostalCode)]
            public string? ZipCode { get; set; }
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
            [DataType(DataType.PhoneNumber)]
            public string? Phone { get; set; }
            [StringLength(50, ErrorMessage = "*Cannot exceed 50 characters")]
            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "*Email is required")]
            public string Email { get; set; } = null!;
            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(100, ErrorMessage = "*Cannot exceed 100 characters")]
            public string? PhotoUrl { get; set; }
            [Required(ErrorMessage = "Student Status ID is required")]
            [Range(0, int.MaxValue)]
            public int Ssid { get; set; }
        }
        #endregion
    }
}//end Metadata
