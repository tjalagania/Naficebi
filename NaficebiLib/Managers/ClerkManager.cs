using Microsoft.EntityFrameworkCore;
using NaficebiLib.DataBaseSqlLeyer;
using NaficebiLib.Managers;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public class ClerkManager : IClerkManager
    {
        public async Task<int?> AddClerk(Clerk clerk)
        {
            int? i = null; 
            using(var appdbcontext = new ApplicationDbContext())
            {
                if(clerk is not null)
                {
                    await appdbcontext.Clerk.AddAsync(clerk);
                   i =  await appdbcontext.SaveChangesAsync();
                }
            }
            return i;
        }

        public async Task<int?> AddClerk(string login, string password, string fullname)
        {
            var clerk = new Clerk()
            {
                Login = login,
                Password = password,
                Fullname = fullname
            };
           return await AddClerk(clerk);
        }

        public async Task<Clerk> GetClerk(string login, string password)
        {
            using(var context = new ApplicationDbContext())
            {
                Clerk cl = await context.Clerk.FirstOrDefaultAsync(cl => cl.Password.Equals(password) && cl.Login.Equals(login));
                return cl; 
            }
        }
        
    }
}
