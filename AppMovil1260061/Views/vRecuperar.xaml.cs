﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMovil1260061.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil1260061.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vRecuperar : ContentPage
    {
        public vRecuperar ()
        {
            InitializeComponent();
            BindingContext = new vmResetPassword();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}