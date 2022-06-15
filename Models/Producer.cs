using atickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// since the properties from the actor and producer class are the same it would be a good practice to create a base class and inherit from one of them.
namespace atickets.Models
{
    public class Producer:IEntityBase
    {
        
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")] 
        public string ProfilePictureURL { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]

        public string FullName { get; set; }
        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Reletionships

        public List<Movie> Movies { get; set; }

    }
}
