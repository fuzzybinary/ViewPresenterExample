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
using MvvmCross.Droid.Views;
using ViewPresenterExample.Core.ViewModels;

namespace ViewPresenterExample.Droid.Resources.UI.Activities
{
    [Activity(Label = "ModalActivity")]
    public class ModalActivity : MvxActivity<ModalViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_modal);

            var closeButton = FindViewById<Button>(Resource.Id.closeButton);
            var text = FindViewById<TextView>(Resource.Id.textView);

            var set = this.CreateBindingSet<ModalActivity, ModalViewModel>();
            set.Bind(closeButton).To(vm => vm.CloseCommand);
            set.Bind(text).To(vm => vm.Text);
            set.Apply();
        }
    }
}