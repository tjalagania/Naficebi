using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.DataBaseAccessLayer
{
    public interface IMsAccessDb<T> where T : class
    {
        Task<IEnumerable<T>> GetAccessTablesAsync();
    }
}
