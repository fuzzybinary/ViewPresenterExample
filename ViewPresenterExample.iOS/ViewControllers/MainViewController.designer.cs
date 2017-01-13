// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ViewPresenterExample.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DialogButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ModalButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DialogButton != null) {
                DialogButton.Dispose ();
                DialogButton = null;
            }

            if (ModalButton != null) {
                ModalButton.Dispose ();
                ModalButton = null;
            }
        }
    }
}