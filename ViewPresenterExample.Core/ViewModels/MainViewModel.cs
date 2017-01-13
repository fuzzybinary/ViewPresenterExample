using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ViewPresenterExample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public ICommand ModalCommand
        {
            get { return new MvxCommand(DoModal); }
        }

        public ICommand DialogCommand
        {
            get { return new MvxCommand(DoDialog); }
        }

        public void OnDialogResponse(string response)
        {
            Debug.WriteLine($"Got response {response}");
        }

        private void DoModal()
        {
            ShowViewModel<ModalViewModel>();
        }

        private void DoDialog()
        {
            ShowViewModel<DialogViewModel>();
        }
    }
}
