using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Xamarin.Forms;
using Firebase.Auth;
using System.Threading.Tasks;
using AppMovil1260061.Connection;

namespace AppMovil1260061.ViewModels
{
    class vmResetPassword : BaseViewModel
    {
        #region Variables
        string txtEmail;
        #endregion
        #region objetos
        public string TxtEmail
        {
            get { return txtEmail; }
            set { SetValue(ref txtEmail, value); }
        }
        #endregion
        #region procesos
        private async Task ResetearContraseña()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Enviando correo ...");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
                await authProvider.SendPasswordResetEmailAsync(TxtEmail);
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Aviso", "Se ha enviado un correo para restablecer su contraseña", "Aceptar");

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "No se pudo enviar. Correo Invalido", "Aceptar");
            }
        }
        #endregion
        #region Comandos
        public Command ResetPassword { get; }
        #endregion

        #region Constructor
        public vmResetPassword()
        {
            ResetPassword = new Command(async () => await ResetearContraseña());
        }
        #endregion
    }
}
