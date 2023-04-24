using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naficebi.Services
{
    public class ConfirmPassword
    {
        public static bool ConfirmPasswd(string password,string confirm)
        {
            return password.Equals(confirm);
        }
    }
}
