using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Core.ViewModels;
using ViewPresenterExample.Core.ViewModels;

namespace ViewPresenterExample.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            
        }

        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
