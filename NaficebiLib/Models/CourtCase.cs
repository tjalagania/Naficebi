using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Models
{
    public enum CaseState
    {
        fist,
        second
    }
    public class CourtCase
    {
        [Key]
        public int Id { get; set; }
        public string? CaseNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? NameOftheAccused { get; set; }
        public string? Path { get; set; }
        public int ClercId { get; set; }
        public bool IsArchive { get; set; } = false;
        public CaseState State { get; set; } = CaseState.fist;
        public virtual Clerk? Clerk { get; set; }
        public virtual List<Numbers>? Numbers { get; set; } = new List<Numbers>();
    }
}
