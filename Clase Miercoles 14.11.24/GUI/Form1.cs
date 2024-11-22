using BE;
using LN;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public csSAP oSAP = new csSAP();
        Entidades frmEntidades;
        public Form1()
        {
            frmEntidades = new Entidades(oSAP);
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
                    frmEntidades.ShowDialog();
                    MessageBox.Show("Conexion Exitosa");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
