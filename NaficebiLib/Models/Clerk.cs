using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Models
{
    public class Clerk
    {
        public int Id { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public List<CourtCase> Cases { get; set; }
    }
}
