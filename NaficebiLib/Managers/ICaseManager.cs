using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public interface ICaseManager
    {
        Task<int> AddCase(CourtCase CourtCase);
        Task<int> AddCaseWithItems(string CaseNumber, string Accused, string CasePath,Clerk Clerk);
        Task<IEnumerable<CourtCase>> GetAllCases();
        Task<IEnumerable<CourtCase>> GetCaseByClerk(Clerk Clerk,bool isarchive=false);
        Task UpdateState(CourtCase CourtCase,CaseState state);
        Task AddArchive(CourtCase CourtCase);
    }
}
