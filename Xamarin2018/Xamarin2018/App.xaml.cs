using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin2018
{
    public partial class App : Application
    {
        public static string RutaBD;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string rutaBD)
        {
            InitializeComponent();

            RutaBD = rutaBD;

            MainPage = new NavigationPage(new MainPage());            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
