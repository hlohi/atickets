using atickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// why we need a unique identifier in the class or table
namespace atickets.Models
{
    public class Actor : IEntityBase
    {
        //Since this class is going to be used to create or get data from the database 
        //...the model needs a property which is going to be a unique identifier for this class and the table rows for the database
        [Key] // Namespace:ComponentModel.DataAnnotations                                                                                                                                                                                                                                                                                                                                                                             
        public int Id { get; set; }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL  { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage =  "Full Name is required")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
        
        //Reletionships
        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}
