using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public interface IClerkManager
    {
        Task<int?> AddClerk(Clerk clerk);
        Task<int?> AddClerk(string login, string password, string fullname);
        Task<Clerk> GetClerk(string login,string password);
    }
}
