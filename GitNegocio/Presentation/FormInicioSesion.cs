using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using Comun.Cache;

namespace Presentation
{
    public partial class FormInicioSesion : Form
    {
        public FormInicioSesion()
        {
            InitializeComponent();
        }

        //SIGUIENTE CODIGO PARA PODER MOVER LA VENTANA--------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //IMPLEMENTARLOS EN EL PANEL DE TITULO CON EL EVENTO MouseDown-------------------------------
        
        private void FormInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "";
            txtCont.Text = "";
            lblErrorMsg.Visible = false;
            this.Show();
            txtUsuario.Focus();
        }

        //Método para generar un mensaje de error según sea el caso
        private void msgError(string msg)
        {
            lblErrorMsg.Text = "               " + msg;
            lblErrorMsg.Visible = true;
        }

        //Checa si el usuario está activado o desactivado
        private void LoginCheck()
        {
            if (txtUsuario.Text != "USUARIO")
            {
                if (txtCont.Text != "CONTRASEÑA")
                {
                    //Instanciamos UserModel para acceder al método que nos regresa si está activado o no
                    UserModel user = new UserModel();
                    var esActivado = user.UserLogin(txtUsuario.Text, txtCont.Text);

                    //Si los datos son incorrectos, no se encuentra nada en la base de datos, por lo que es NULL
                    if(esActivado == null)
                    {
                        msgError("Usuario o contraseña incorrectos");
                        return;
                    }

                    //1 si está activado, 0 si está desactivado
                    if(esActivado.Equals("1"))
                    {
                        this.Hide();
                        /*Instanciamos el Form de bienvenida, pero todavia no lo agregamos, entonces solo ponemos un msg.                        * 
                         * 
                        FormBienvenida bn = new FormBienvenida();
                        bn.ShowDialog();*/
                        MessageBox.Show("Bienvenido " + UserCache.NomEmp + " " + UserCache.AppEmp + " " + UserCache.ApmEmp);

                        FormMenuPrincipal menu = new FormMenuPrincipal();
                        menu.Show();
                        menu.FormClosed += Logout;
                    }
                    else if (esActivado.Equals("0"))
                    {
                        msgError("Usuario desactivado");
                        txtUsuario.Text = "";
                        txtCont.Text = "";
                    }
                }
                else
                {
                    msgError("Por favor ingrese la contraseña");
                }
            }
            else
            {
                msgError("Por favor ingrese el usuario");
            }                
        }

        #region Iconos Min y Cerrar

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconCerrar_MouseHover(object sender, EventArgs e)
        {
            iconCerrar.BackColor = Color.Red;
        }

        private void iconCerrar_MouseLeave(object sender, EventArgs e)
        {
            iconCerrar.BackColor = Color.WhiteSmoke;
        }

        private void iconMinimizar_MouseHover(object sender, EventArgs e)
        {
            iconMinimizar.BackColor = Color.Silver;
        }

        private void iconMinimizar_MouseLeave(object sender, EventArgs e)
        {
            iconMinimizar.BackColor = Color.WhiteSmoke;
        }

        #endregion

        #region Comportamiento de los TXT

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtCont_Enter(object sender, EventArgs e)
        {
            if(txtCont.Text == "CONTRASEÑA")
            {
                txtCont.Text = "";
                txtCont.ForeColor = Color.Black;
                txtCont.UseSystemPasswordChar = true;
            }
        }

        private void txtCont_Leave(object sender, EventArgs e)
        {
            if (txtCont.Text == "")
            {
                txtCont.Text = "CONTRASEÑA";
                txtCont.ForeColor = Color.DimGray;
                txtCont.UseSystemPasswordChar = false;
            }
        }

        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }
    }
}
