using System;
using System.Collections.Generic;

namespace App.Domain.Models
{
    public partial class Ticket
    {
        public Guid Id { get; set; }
        public string Client { get; set; } = null!;
        public int EventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
