using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ViewPresenterExample.Core.ViewModels
{
    public class ModalViewModel : MvxViewModel
    {
        public string Text { get; set; } = "Modal Dialog";

        public ICommand CloseCommand
        {
            get { return new MvxCommand(DoClose); }
        } 

        private void DoClose()
        {
            ChangePresentation(new MvxClosePresentationHint(this));
        }
    }
}
