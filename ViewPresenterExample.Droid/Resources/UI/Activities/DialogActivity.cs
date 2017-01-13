using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using ViewPresenterExample.Core.ViewModels;

namespace ViewPresenterExample.Droid.Resources.UI.Activities
{
    [Activity(Label = "DialogActivity")]
    public class DialogActivity : MvxActivity<DialogViewModel>, IMvxViewDispatcher
    {
        public static readonly string ExtraDialogResult = "ViewPresenterExample.DialogActivity.DialogResult";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel.ViewDispatcher = this;

            SetContentView(Resource.Layout.activity_dialog);

            var closeButton = FindViewById<Button>(Resource.Id.closeButton);
            var textEntry = FindViewById<TextView>(Resource.Id.textEntry);

            var set = this.CreateBindingSet<DialogActivity, DialogViewModel>();
            set.Bind(closeButton).To(vm => vm.CloseCommand);
            set.Bind(textEntry).To(vm => vm.DialogResponse);
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
                var returnIntent = new Intent();
                returnIntent.PutExtra(ExtraDialogResult, ViewModel.DialogResponse);
                SetResult(Result.Ok, returnIntent);
                Finish();
                return true;
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