using System;
using System.Collections.Generic;

namespace App.Domain.Models
{
    public partial class Event
    {
        public Event()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Event(string title)
        {
            Title = title;
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
