using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // لو احتجتها

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImageUrl { get; set; }
        public byte[]? Image { get; set; }     
        public int TherapistId { get; set; }

        public Therapist Therapist { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}