using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public interface INumberManager<T> where T: Numbers
    {
        Task<int> AddNumber(T value);
        Task<IEnumerable<Numbers>> GetNumbersWithCase(int caseId);
    }
}
