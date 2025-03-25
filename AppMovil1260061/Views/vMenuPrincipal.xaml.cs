using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;
using AppMovil1260061.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;

namespace AppMovil1260061.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vMenuPrincipal : Xamarin.Forms.TabbedPage
    {
        public vMenuPrincipal()
        {
            InitializeComponent();
            BindingContext = new vmMenuPrincipal();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new vRegistrarProducto());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vRegistrarCiente());
        }
    }
}