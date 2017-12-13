using System;
using System.Collections.Generic;

namespace Snails.Data.Entities
{
    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string WinnerId { get; set; }

        public Snail Winner { get; set; }

        public IEnumerable<Snail> Competitors { get; set; }
    }
}
