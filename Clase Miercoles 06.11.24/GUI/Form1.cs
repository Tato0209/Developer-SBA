using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using LN;

namespace GUI
{
    public partial class Form1 : Form
    {
        public csSAP oSAP = new csSAP();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                csCompany objCompany = new csCompany();
                objCompany.ServerBD = txtServerBD.Text.Trim();
                objCompany.UsuarioBD = txtUsuarioBD.Text.Trim();
                objCompany.PassBD = txtPassBD.Text.Trim();
                objCompany.ServerLC = txtServerLC.Text.Trim();
                objCompany.NameBD = txtNombreBD.Text.Trim();
                objCompany.UserSAP = txtUsuarioSAP.Text.Trim();
                objCompany.PassSAP = txtPassSAP.Text.Trim();
                objCompany.ServerType = cmbServerType.SelectedIndex;

                if (oSAP.LoginSAP(objCompany))
                {
                    MessageBox.Show("Conexion Exitosa");
                }
             }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
