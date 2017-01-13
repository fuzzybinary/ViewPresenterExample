using System;
using MvvmCross.iOS.Views;
using ViewPresenterExample.Core;
using UIKit;
using ViewPresenterExample.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using ViewPresenterExample.iOS.ViewControllers;
using MvvmCross.Binding.BindingContext;

namespace ViewPresenterExample.iOS
{
    public partial class MainViewController : MvxViewController<MainViewModel>, IMvxViewDispatcher,
        IDialogViewControllerDelegate
    {
        public MainViewController() : base("MainViewController", null)
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

            ViewModel.ViewDispatcher = this;
            
            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(ModalButton).To(vm => vm.ModalCommand);
            set.Bind(DialogButton).To(vm => vm.DialogCommand);
            set.Apply();
        }

        public void DidFinishWithResult(DialogViewController vc, string result)
        {
            vc.DismissModalViewController(true);
            ViewModel.OnDialogResponse(result);
        }

        public void DidCancel(DialogViewController vc)
        {
            vc.DismissModalViewController(true);
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            if(request.ViewModelType == typeof(DialogViewModel))
            {
                var view = this.CreateViewControllerFor(request) as DialogViewController;
                if(view != null)
                {
                    view.Delegate = this;
                    PresentModalViewController(view, true);
                }
                return true;
            }

            var dispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            return dispatcher.ShowViewModel(request);
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            var dispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            return dispatcher.ChangePresentation(hint);
        }

        public bool RequestMainThreadAction(Action action)
        {
            var dispatcher = Mvx.Resolve<IMvxMainThreadDispatcher>();
            return dispatcher.RequestMainThreadAction(action);
        }
    }
}