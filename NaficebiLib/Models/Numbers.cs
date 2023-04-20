using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Models
{
    public class Numbers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SelectedNumber { get; set; }
        public string? CreatedDate { get; set; }
        public int CourtCaseId { get; set; }
        public string? Path { get; set; }
        public virtual CourtCase? CourtCase{ get;set;}
    }
}
