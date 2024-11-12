using BE;
using LN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Entidades : Form
    {
        public csSAP oSAP;
        public Entidades()
        {
           
            InitializeComponent();
        }

        public Entidades(csSAP objSAP)
        {
            this.oSAP = objSAP;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                csItems oItems = new csItems();
                oItems.ItemCode = this.txtCode.Text.Trim();
                oItems.ItemName = this.txtDescrip.Text.Trim();
                oItems.GroupCode = Int32.Parse(txtGroup.Text.Trim());
                oItems.InvntItem = this.chkAI.Checked ? "Y" : "N";
                oItems.SellItem = this.chkAC.Checked ? "Y" : "N";
                oItems.PrchseItem = this.chkAC.Checked ? "Y" : "N";
                oItems.U_C2410_P001 = this.txtCP.Text.Trim();
                if (oSAP.AddItems(oItems))
                {
                    MessageBox.Show("Item Agregado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                    csItems oItems = new csItems();
                    if(this.txtCode.Text.Trim() == "") throw new Exception("El codigo del Item debe ser obligatorio");
                    oItems.ItemCode = this.txtCode.Text.Trim();
                   
                if (oSAP.GetItems(ref oItems))
                    {
                        
                        this.txtDescrip.Text = oItems.ItemName;
                        this.txtGroup.Text = oItems.GroupCode.ToString();
                        this.chkAI.Checked = oItems.InvntItem == "Y" ? true : false;
                        this.chkAC.Checked = oItems.SellItem == "Y" ? true : false;
                        this.chkAV.Checked = oItems.PrchseItem == "Y" ? true : false;
                        this.txtCP.Text = oItems.U_C2410_P001;

                    MessageBox.Show("Item Encontrado");
                }
               
                oItems.ItemCode = this.txtCode.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtCode.Text.Trim() == "") throw new Exception("El codigo del Item debe ser obligatorio");
                if (oSAP.DeleteItems(this.txtCode.Text.Trim())){
                    MessageBox.Show("Item Eliminado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                csAddress objAddress;
                csContacts objContacts; //Contactos
                CsBussinesPartner objBussinesPartner = new CsBussinesPartner();//Socio de Negocio

                objBussinesPartner.CardCode = "PL20612838550";
                objBussinesPartner.CardName = "RC3 INGENIEROS SAC";
                objBussinesPartner.CardType = "S";
                objBussinesPartner.LicTradNum = "20612838550";
                objBussinesPartner.GroupCode = 101;
                objBussinesPartner.U_C2410_P001 = "JORGE";
                objBussinesPartner.U_C2410_P002 = "MUÑOZ";

                objAddress = new csAddress();//
                objAddress.Address = "FISCAL";
                objAddress.Address2 = "MZA. A LOTE. 1";
                objAddress.Street = "AV. LOS FRESNOS";
                objAddress.Block = "MZA. A LOTE. 1";
                objAddress.City = "LIMA";
                objAddress.State = "";
                objAddress.Country = "PE";
                objAddress.AdresType = "B";
                objBussinesPartner.listAddress.Add(objAddress);//Add Address


                objAddress = new csAddress();
                objAddress.Address = "ALMACEN";
                objAddress.Address2 = "MZA. A LOTE. 1";
                objAddress.Street = "AV. LOS FRESNOS";
                objAddress.Block = "MZA. A LOTE. 1";
                objAddress.City = "LIMA";
                objAddress.State = "";
                objAddress.Country = "PE";
                objAddress.AdresType = "S";
                objBussinesPartner.listAddress.Add(objAddress);//Add Address


                objContacts = new csContacts();
                objContacts.Name = "CONTACTO1";
                objContacts.FirstName = "JORGE";
                objContacts.MiddleName = "MUÑOZ";
                objContacts.LastName = "MUÑOZ";
                objContacts.Cellolar = "999999999";
                objBussinesPartner.listContacts.Add(objContacts);//Add Contacts

                if(oSAP.AddBussinesPartner(objBussinesPartner))
                {
                    MessageBox.Show("Socio de Negocio Agregado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                CsBussinesPartner oBP = new CsBussinesPartner();
                if (this.txtBP.Text.Trim() == "") throw new Exception("El codigo del Socio de Negocio debe ser obligatorio");
                oBP.CardCode = this.txtBP.Text.Trim();

                if (oSAP.GetBusinessPartners(ref oBP))
                {
                    MessageBox.Show("Socio de Negocio Encontrado");
                }
                oBP.CardCode = this.txtBP.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
