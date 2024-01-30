using Examen_1U_Desarrollo.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_1U_Desarrollo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipal();
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
