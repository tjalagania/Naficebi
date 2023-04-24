using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Models
{
    public class PrincipalModel : IComparable<PrincipalModel>
    {
        private readonly Random _random;
        private double? number1;
        private double? number2;

        public double? Number1
        {
            get=>number1;
            set => number1 = value;
        }
        public double? Number2
        {
            get => number2;
            set => number2 = value;
        }
        public PrincipalModel()
        {
            _random = new Random();
        }
        public string? PV_NUNMBER { get; set; }
        public string? LAST { get; set; }
        public string? FIRST { get; set; }
        public string? BIRTH_DATE { get; set; }
        public string? BP_FULL_ADDRESS { get; set; }

        public string FullName { get => $"{FIRST} {LAST}"; }
        
        public int CompareTo(PrincipalModel? other)
        {
            if(Number1 == null && Number2 == null)
                return _random.NextDouble().CompareTo(_random.NextDouble());
            else
            {
                double nm1 = (double)(_random.NextDouble() * Number1);
                double nm2 = (double)(_random.NextDouble() * Number2);
                return nm1.CompareTo(nm2);
            }
             
        }
    }
}
