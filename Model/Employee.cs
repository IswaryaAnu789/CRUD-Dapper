using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Dapperempdetails.Model
{
    public class Employee
    {
        [Key]

        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only contain letters and spaces")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range (18,99,ErrorMessage ="age should be between 18 to 99")]
        public int Age { get; set; }

        [Required]
        public string Job { get; set; } = string.Empty;

        [Required]
        [StringLength(10,MinimumLength =10 , ErrorMessage ="Minimum length needs to be 10")]
        [RegularExpression(@"^9\d{9}$", ErrorMessage = "should start with number 9")]
        public string Phoneno { get; set; } = string.Empty;

        public int Isactive {  get; set; }

        
    }
}
