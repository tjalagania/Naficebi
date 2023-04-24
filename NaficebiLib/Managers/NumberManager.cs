using Microsoft.EntityFrameworkCore;
using NaficebiLib.DataBaseSqlLeyer;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public class NumberManager : INumberManager<Numbers>
    {
        public async Task<int> AddNumber(Numbers value)
        {
            using(ApplicationDbContext db = new())
            {
                await db.Numbers.AddAsync(value);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Numbers>> GetNumbersWithCase(int caseId)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
               return await db.Numbers.Where(nm => nm.CourtCaseId.Equals(caseId)).ToListAsync();
            }
        }
    }
}
