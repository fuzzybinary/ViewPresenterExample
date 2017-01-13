using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using UIKit;
using ViewPresenterExample.Core.ViewModels;

namespace ViewPresenterExample.iOS.ViewControllers
{
    public interface IDialogViewControllerDelegate
    {
        void DidFinishWithResult(DialogViewController vc, string result);
        void DidCancel(DialogViewController vc);
    }

    public class DialogViewController : MvxViewController<DialogViewModel>, IMvxViewDispatcher
    {
        private WeakReference<IDialogViewControllerDelegate> _delegate;
        public IDialogViewControllerDelegate Delegate
        {
            get
            {
                IDialogViewControllerDelegate d = null;
                _delegate?.TryGetTarget(out d);
                return d;
            }
            set
            {
                _delegate = new WeakReference<IDialogViewControllerDelegate>(value);
            }
        }

        private UITextField _textField;
        private UIButton _closeButton;

        public DialogViewController() : base()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            ViewModel.ViewDispatcher = this;
            
            View.BackgroundColor = UIColor.Blue;

            _textField = new UITextField();
            _textField.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_textField);
            _textField.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 12).Active = true;
            _textField.RightAnchor.ConstraintEqualTo(View.RightAnchor, -12).Active = true;
            _textField.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            _textField.BorderStyle = UITextBorderStyle.RoundedRect;

            _closeButton = new UIButton();
            _closeButton.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_closeButton);
            _closeButton.CenterXAnchor.ConstraintEqualTo(_textField.CenterXAnchor).Active = true;
            _closeButton.TopAnchor.ConstraintEqualTo(_textField.BottomAnchor, 20).Active = true;
            _closeButton.SetTitle("Close", UIControlState.Normal);
            
            var set = this.CreateBindingSet<DialogViewController, DialogViewModel>();
            set.Bind(_textField).To(vm => vm.DialogResponse);
            set.Bind(_closeButton).To(vm => vm.CloseCommand);
            set.Apply();
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            var dispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            return dispatcher.ShowViewModel(request);
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            if(hint is MvxClosePresentationHint)
            {
                if(Delegate != null)
                { 
                    Delegate.DidFinishWithResult(this, ViewModel.DialogResponse);
                    return true;
                }
            }
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
