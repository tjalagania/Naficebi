using Microsoft.EntityFrameworkCore;
using NaficebiLib.DataBaseSqlLeyer;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public class CaseManager : ICaseManager
    {
        public async Task<int> AddCase(CourtCase CourtCase)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {

                    await db.CourtCase.AddAsync(CourtCase);
                    return await db.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    throw new Exception($"ვერ მოხერხდა საქმის ბაზებში დამატება: {ex.Message}");
                }


            }
           
        }

        public async Task<int> AddCaseWithItems(string CaseNumber, string Accused, string CasePath, Clerk clerk)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CourtCase cs = new CourtCase()
                {
                    CaseNumber = CaseNumber,
                    NameOftheAccused = Accused,
                    Path = @$"{CasePath}",
                    CreateDate = DateTime.Now,
                    ClercId = clerk.Id
                    
                };
                return await AddCase(cs);


            }

        }

        public Task<IEnumerable<CourtCase>> GetAllCases()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourtCase>> GetCaseByClerk(Clerk Clerk,bool isarchive=false)
        {
           using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return await db.CourtCase.Where(cs => cs.ClercId.Equals(Clerk.Id) && cs.IsArchive == isarchive).ToListAsync();
            }
        }

        public async Task UpdateState(CourtCase CourtCase,CaseState state)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var courtcase = await db.CourtCase.FirstOrDefaultAsync(cs=>cs.Id== CourtCase.Id);
                if(courtcase != null )
                {
                    courtcase.State = state;
                    db.CourtCase.Update(courtcase);
                    await db.SaveChangesAsync();
                }
                
            }
        }

        public async Task AddArchive(CourtCase CourtCase)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var courtCase = await db.CourtCase.FirstOrDefaultAsync(cs=>cs.Id.Equals(CourtCase.Id));
                if (courtCase == null)
                    return;
                
                courtCase.IsArchive = true;
                db.CourtCase.Update(courtCase); 
                await db.SaveChangesAsync();    
                
            }
        }

        ~CaseManager() {
            GC.Collect();
        }
    }
}
