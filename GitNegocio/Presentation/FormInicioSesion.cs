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

        #region Iconos Min y Cerrar
        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }        
    }
}
