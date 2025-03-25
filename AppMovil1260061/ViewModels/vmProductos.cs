using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Models;
using AppMovil1260061.Data;
using System.Threading.Tasks;
using AppMovil1260061.Connection;
using Acr.UserDialogs;
using Xamarin.Forms;
using AppMovil1260061.ViewModels;

namespace AppMovil1260061.ViewModels
{
     public class vmProductos : BaseViewModel
    {
        #region variables
        public string txtnombre;
        public string txtfechavencimiento;
        public string txtcategoria;
        public string txtprecio;
        public string txticono;
        public string txtproveedor;
        public string txtstock;
        #endregion

        #region objetos
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre,value); }
        }
        public string Txtfechavencimiento
        {
            get { return txtfechavencimiento; }
            set { SetValue(ref txtfechavencimiento, value); }
        }
        public string Txtcategoria
        {
            get { return txtcategoria; }
            set { SetValue(ref txtcategoria, value); }
        }
        public string Txtprecio
        {
            get { return txtprecio; }
            set { SetValue(ref txtprecio, value); }
        }
        public string Txticono
        {
            get { return txticono; }
            set { SetValue(ref txticono, value); }
        }
        public string Txtproveedor
        {
            get { return txtproveedor; }
            set { SetValue(ref txtproveedor, value); }
        }
        public string Txtstock
        {
            get { return txtstock; }
            set { SetValue(ref txtstock, value); }
        }
        #endregion

        #region procesos
        private async Task InsertarProducto()
        {
            var funcion = new dProductos();
            var paramentos = new mProductos();
            paramentos.nombre = Txtnombre;
            paramentos.categoria = Txtcategoria;
            paramentos.precio = Txtprecio;
            paramentos.fechavencimiento = Txtfechavencimiento;
            paramentos.icono = Txticono;
            paramentos.proveedor = Txtproveedor;
            paramentos.stock = Txtstock;
            var estadofuncion = await funcion.InsertarProducto(paramentos);
            if (estadofuncion == true)
            {
                UserDialogs.Instance.ShowLoading("Registrando Producto ...");
                await Task.Delay(2000);
                await DisplayAlert("Exito", "Producto Registrado", "Aceptar");
                UserDialogs.Instance.HideLoading();
                // 🔹 Actualizar la lista de productos
                var vmPrincipal = DependencyService.Get<vmMenuPrincipal>();
                if (vmPrincipal != null)
                {
                    await vmPrincipal.ListarProductos();
                }

            }
            else
            {
                UserDialogs.Instance.ShowLoading("Registrando Producto ...");
                await Task.Delay(2000);
                await DisplayAlert("Error", "Producto no se registro", "Aceptar");
                UserDialogs.Instance.HideLoading();
            }
        }
        #endregion

        #region comandos
        public Command cmdInsertarProducto { get;}
        #endregion

        #region constructor
        public vmProductos()
        {
            cmdInsertarProducto = new Command(async () => await InsertarProducto());
        }
        #endregion
    }
}
