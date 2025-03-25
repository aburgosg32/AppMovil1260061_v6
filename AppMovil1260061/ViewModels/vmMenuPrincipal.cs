using System;
using System.Collections.Generic;
using System.Text;
using AppMovil1260061.Connection;
using AppMovil1260061.Models;
using AppMovil1260061.Data;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppMovil1260061.ViewModels
{
    public class vmMenuPrincipal : BaseViewModel
    {
        #region Variables
        string lblNombreCompleto;
        string lblEmail;
        string lblTelefono;
        string lblUserName;
        string idUsuario;
        string lblImage;
        string txtBuscarProducto;
        string txtBuscarCliente;
        List<mProductos> listaProductos;
        List<mClientes> listaClientes;
        #endregion
        #region Objetos

        public string TxtBuscarCliente
        {
            get { return txtBuscarCliente; }
            set {
                if (txtBuscarCliente != value)
                {
                    txtBuscarCliente = value;
                    OnPropertyChanged(); // Notificar a la UI que la propiedad cambió
                    _ = BuscarCliente(); // Llamar búsqueda en tiempo real (ignorar warning de async void)
                }
            }
        }
        public string TxtBuscarProducto
        {
            get { return txtBuscarProducto; }
            set {
                if (txtBuscarProducto != value)
                {
                    txtBuscarProducto = value;
                    OnPropertyChanged(); // Notificar a la UI que la propiedad cambió
                    _ = BuscarProducto(); // Llamar búsqueda en tiempo real (ignorar warning de async void)
                }
            }
        }
        public List<mClientes> ListaClientes
        {
            get { return listaClientes; }
            set { SetValue(ref listaClientes, value); }
        }
        public List<mProductos> ListaProductos
        {
            get { return listaProductos; }
            set { SetValue(ref listaProductos, value); }
        }
        public string LblImage
        {
            get { return lblImage; }
            set { SetValue(ref lblImage, value); }
        }
        public string IdUsuario
        {
            get { return idUsuario; }
            set { SetValue(ref idUsuario, value); }
        }
        public string LblNombreCompleto
        {
            get { return lblNombreCompleto; }
            set { SetValue(ref lblNombreCompleto, value); }
        }
        public string LblEmail
        {
            get { return lblEmail; }
            set { SetValue(ref lblEmail, value); }
        }
        public string LblTelefono
        {
            get { return lblTelefono; }
            set { SetValue(ref lblTelefono, value); }
        }
        public string LblUserName
        {
            get { return lblUserName; }
            set { SetValue(ref lblUserName, value); }
        }
        #endregion
        #region Procesos
       
        public async Task ListarProductos()
        {
            var funcion = new dProductos();
            ListaProductos = await funcion.MostrarProductos();
        }

        public async Task ListarClientes()
        {
            var funcion = new dClientes();
            ListaClientes = await funcion.MostrarClientes();
        }
        public async Task verDatosUsuario()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.Apykey));
            var guardardatosuser = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("token", ""));
            var refreshContent = await authProvider.RefreshAuthAsync(guardardatosuser);
            Preferences.Set("token", JsonConvert.SerializeObject(refreshContent));
            string correo = guardardatosuser.User.Email;

            var funcion = new dUsuarios();
            var datos = new mUsuarios();
            datos.Email = correo;

            var lista = await funcion.MostrarDatosUsuario(datos);
            foreach (var item in lista)
            {
                LblNombreCompleto = item.FullName;
                LblEmail = item.Email;
                LblTelefono = item.Phone;
                LblUserName = item.UserName;
                IdUsuario = item.idusuario;
                LblImage = item.Image;
                break;
            }

        }

        public async Task BuscarProducto()
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarProducto))
            {
                await ListarProductos(); // Si el texto está vacío, mostrar toda la lista
                return;
            }

            var funcion = new dProductos();
            ListaProductos = await funcion.BuscarProducto(TxtBuscarProducto);
        }

        public async Task BuscarCliente()
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarCliente))
            {
                await ListarClientes(); // Si el texto está vacío, mostrar toda la lista
                return;
            }
            var funcion = new dClientes();
            ListaClientes = await funcion.BuscarClientes(TxtBuscarCliente);
        }
        #endregion
        #region Comandos
        public Command cmdBuscarProducto { get; }
        public Command cmdBuscarCliente { get; }
        #endregion
        #region Constructor
        public vmMenuPrincipal()
        {
            cmdBuscarProducto = new Command(async () => await BuscarProducto());
            cmdBuscarCliente = new Command(async () => await BuscarCliente());
            verDatosUsuario();
            ListarProductos();
            ListarClientes();
        }
        #endregion
    }
}
