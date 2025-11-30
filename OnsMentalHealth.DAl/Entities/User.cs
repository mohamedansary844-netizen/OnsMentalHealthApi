using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class User :IdentityUser
    {
        public string Gender { get; set; }
        public DateOnly Birthday { get; set; }

       // public List<Booking> bookings { get; set; }    

        public  List<Comment> Comments { get; set; } 
         
        public List<Reaction> Reactions { get; set; }  
    }     
}
