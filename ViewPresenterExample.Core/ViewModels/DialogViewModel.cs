using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ViewPresenterExample.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        private string _DialogResponse;
        public string DialogResponse
        {
            get { return _DialogResponse; }
            set { SetProperty(ref _DialogResponse, value); }
        }

        public ICommand CloseCommand
        {
            get { return new MvxCommand(OnClose); }
        }

        private void OnClose()
        {
            ChangePresentation(new MvxClosePresentationHint(this));
        }
    }
}
