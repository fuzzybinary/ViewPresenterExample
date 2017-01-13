using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using ViewPresenterExample.Core.ViewModels;

namespace ViewPresenterExample.iOS.ViewControllers
{
    public partial class ModalViewController : MvxViewController<ModalViewModel>
    {
        public ModalViewController() : base("ModalViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ModalViewController, ModalViewModel>();
            set.Bind(CloseButton).To(vm => vm.CloseCommand);
            set.Bind(Text).To(vm => vm.Text);
            set.Apply();
        }
    }
}