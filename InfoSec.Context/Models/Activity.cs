using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoSec.Context.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int DayNumber { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        public int ModeratorId { get; set; }
        public User Moderator { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public ICollection<User> Juries { get; set; }
        public Activity()
        {
            Juries = new HashSet<User>();
        }
    }
}