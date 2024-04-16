using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfoSec.Context.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTimeOffset BirthDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ImagePath { get; set;}
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? DirectionId { get; set; }
        public Direction Direction { get; set; }
        public ICollection<Event> EventWinners { get; set; }
        public ICollection<Activity> ActivityModerators { get; set; }
        public ICollection<Activity> ActivityJuries { get; set; }
        public User()
        {
            ActivityJuries = new HashSet<Activity>();
        }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
