using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Models;
using AppMovil1260061.ViewModels;
using AppMovil1260061.Data;
using AppMovil1260061.Connection;
using Firebase.Database.Query;
using System.Linq;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    public class vmClientes : BaseViewModel
    {

        #region variables
        public string txtapellidosnombre;
        public string txtdni;
        public string txtfotocasa;
        public string txtdireccion;
        public string txttelefono;
        public string txtciudad;
        public string txtocupacion;
        public string txtcorreo;
        #endregion

        #region objetos
        public string Txtapellidosnombre
        {
            get { return txtapellidosnombre; }
            set { SetValue(ref txtapellidosnombre, value); }
        }
        public string Txtdni
        {
            get { return txtdni; }
            set { SetValue(ref txtdni, value); }
        }
        public string Txtfotocasa
        {
            get { return txtfotocasa; }
            set { SetValue(ref txtfotocasa, value); }
        }
        public string Txtdireccion
        {
            get { return txtdireccion; }
            set { SetValue(ref txtdireccion, value); }
        }
        public string Txttelefono
        {
            get { return txttelefono; }
            set { SetValue(ref txttelefono, value); }
        }
        public string Txtciudad
        {
            get { return txtciudad; }
            set { SetValue(ref txtciudad, value); }
        }
        public string Txtocupacion
        {
            get { return txtocupacion; }
            set { SetValue(ref txtocupacion, value); }
        }
        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }

        #endregion

        #region procesos
        private async Task InsertarCliente()
        {
            var funcion = new dClientes();
            var paramentos = new mClientes();
            paramentos.apellidosnombre = Txtapellidosnombre;
            paramentos.ciudad = Txtciudad;
            paramentos.correo = Txtcorreo;
            paramentos.direccion = Txtdireccion;
            paramentos.dni = Txtdni;
            paramentos.fotocasa = Txtfotocasa;
            paramentos.ocupacion = Txtocupacion;
            paramentos.telefono = Txttelefono;
            var estadofuncion = await funcion.InsertarCliente(paramentos);
            if (estadofuncion == true)
            {
                UserDialogs.Instance.ShowLoading("Registrando Cliente ...");
                await Task.Delay(2000);
                await DisplayAlert("Exito", "Cliente Registrado", "Aceptar");
                UserDialogs.Instance.HideLoading();

            }
            else
            {
                UserDialogs.Instance.ShowLoading("Registrando Cliente ...");
                await Task.Delay(2000);
                await DisplayAlert("Error", "Cliente no se registro", "Aceptar");
                UserDialogs.Instance.HideLoading();
            }
        }
        #endregion

        #region comandos
        public Command cmdInsertarCliente { get; }
        #endregion

        #region constructor
        public vmClientes()
        {
            cmdInsertarCliente = new Command(async () => await InsertarCliente());
        }
        #endregion
    }
}
