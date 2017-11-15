using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Snail
    {
        public string Id { get; set; }

        public double? ShellRadius { get; set; }

        public double Length { get; set; }

        public bool IsAlive { get; set; }
    }
}