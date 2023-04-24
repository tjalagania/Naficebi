using Naficebi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Naficebi.VIewModel
{
    public class AuthorizationViewModel: MainView
    {
        public ICommand NavigateComand { get; set; }
        public AuthorizationViewModel()
        {
            NavigateComand = new RelayCommand(NavigateCommandExec);
        }

        private void NavigateCommandExec(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
