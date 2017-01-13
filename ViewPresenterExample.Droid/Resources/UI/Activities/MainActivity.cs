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
    [Activity(Label = "MainActivity")]
    public class MainActivity : MvxActivity<MainViewModel>, IMvxViewDispatcher
    {
        public static readonly int RequestCodeDialog = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel.ViewDispatcher = this;

            SetContentView(Resource.Layout.activity_main);

            var modal = FindViewById<Button>(Resource.Id.modalButton);
            var dialog = FindViewById<Button>(Resource.Id.dialogButton);

            var set = this.CreateBindingSet<MainActivity, MainViewModel>();
            set.Bind(modal).To(vm => vm.ModalCommand);
            set.Bind(dialog).To(vm => vm.DialogCommand);
            set.Apply();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == RequestCodeDialog && resultCode == Result.Ok)
            {
                var result = data.GetStringExtra(DialogActivity.ExtraDialogResult);
                ViewModel.OnDialogResponse(result);
            }
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            if (request.ViewModelType == typeof(DialogViewModel))
            {
                var requestTranslator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
                var intent = requestTranslator.GetIntentFor(request);
                intent.SetFlags(0); // Clear flags set by the request translator....
                StartActivityForResult(intent, RequestCodeDialog);
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