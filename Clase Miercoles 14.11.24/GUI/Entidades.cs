﻿using System;
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

using System.Xml.Linq;
using System.Xml.XPath;

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

        private void Entidades_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboCancel();
                CargarComboClose();
                CargarComboPagos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboPagos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("NAME");

                DataRow _row;

                _row = dt.NewRow();
                _row["ID"] = "PR"; _row["NAME"] = "Pago Recibido"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "PE"; _row["NAME"] = "Pago Efectuado"; dt.Rows.Add(_row);

                LoadCombo(dt, ref comboBox1);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarComboClose()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("NAME");

                DataRow _row;

                _row = dt.NewRow();
                _row["ID"] = "OC"; _row["NAME"] = "Orden de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "EC"; _row["NAME"] = "Entrada de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "DC"; _row["NAME"] = "Devolución de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "OV"; _row["NAME"] = "Orden de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "EV"; _row["NAME"] = "Entrada de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "DV"; _row["NAME"] = "Devolución de Venta"; dt.Rows.Add(_row);

                LoadCombo(dt, ref cboListClose);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboCancel()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("NAME");

                DataRow _row;

                _row = dt.NewRow();
                _row["ID"] = "OC"; _row["NAME"] = "Orden de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "EC"; _row["NAME"] = "Entrada de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "DC"; _row["NAME"] = "Devolución de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "FC"; _row["NAME"] = "Factura de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "NC"; _row["NAME"] = "Nota Crédito de Compra"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "OV"; _row["NAME"] = "Orden de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "EV"; _row["NAME"] = "Entrada de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "DV"; _row["NAME"] = "Devolución de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "FV"; _row["NAME"] = "Factura de Venta"; dt.Rows.Add(_row);

                _row = dt.NewRow();
                _row["ID"] = "NV"; _row["NAME"] = "Nota Crédito de Venta"; dt.Rows.Add(_row);

                LoadCombo(dt, ref cboListCancel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCombo(DataTable dt, ref ComboBox Combo)
        {
            try
            {
                Combo.DataSource = dt;
                Combo.DisplayMember = dt.Columns[1].Caption;
                Combo.ValueMember = dt.Columns[0].Caption;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                if (this.txtCode.Text.Trim() == "") throw new Exception("El codigo del Item debe ser obligatorio");
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
                if (this.txtCode.Text.Trim() == "") throw new Exception("El codigo del Item debe ser obligatorio");
                if (oSAP.DeleteItems(this.txtCode.Text.Trim()))
                {
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

                if (oSAP.AddBussinesPartner(objBussinesPartner))
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBP.Text.Trim() == "") throw new Exception("El codigo del BussinesPartner debe ser obligatorio");
                if (oSAP.DeleteBussinesPartner(this.txtBP.Text.Trim()))
                {
                    MessageBox.Show("BusinessPartner Eliminado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBP.Text.Trim() == "") throw new Exception("El codigo del BussinesPartner debe ser obligatorio");//
                if (oSAP.UpdateBussinesPartner(this.txtBP.Text.Trim())) //Actualizar BussinesPartner
                {
                    MessageBox.Show("BusinessPartner Actualizado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                csJournalEntry oJE = new csJournalEntry(); //Asiento Contable
                csJournalEntryLines oLine;//Lineas del Asiento
                csJournalEntryLines oLine2;//Lineas del Asiento

                oJE.RefDate = DateTime.Now.ToString("yyyyMMdd");
                oJE.DueDate = DateTime.Now.ToString("yyyyMMdd");
                oJE.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oJE.Memo = "Memo";
                oJE.Ref1 = "Ref1";
                oJE.Ref2 = "Ref2";
                oJE.Ref3 = "Ref3";
                oJE.Indicator = "";
                oJE.Project = "";
                oJE.TransCode = "";

                oLine = new csJournalEntryLines();//Linea 1

                oLine.Account = "4115101";
                oLine.Debit = 100.00;
                oLine.FCDebit = 0;
                oLine.FCCredit = 0;
                oLine.Credit = 0;
                oLine.Project = "KOLPA";
                oJE.Lines.Add(oLine);


                oLine2 = new csJournalEntryLines(); //Linea 2
                oLine2.Account = "4115102"; //Cuenta
                oLine2.Debit = 0;
                oLine2.FCDebit = 0;
                oLine2.FCCredit = 0;
                oLine2.Credit = 100.00;
                oLine2.Project = "CHACUA";
                oJE.Lines.Add(oLine2);



                string sTransID = ""; //ID del Asiento
                if (oSAP.AddJournalEntries(oJE, ref sTransID)) //Agregar Asiento
                {
                    MessageBox.Show("Asiento Agregado");

                    this.txtJE.Text = sTransID; //ID del Asiento
                }
                else
                {
                    MessageBox.Show("Error al agregar Asiento"); //Error al agregar Asiento
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtJEC.Text.Trim() == "") throw new Exception("El ID del Asiento debe ser obligatorio"); //ID del Asiento
                string sCancelTransID = ""; //ID del Asiento Cancelado
                if (oSAP.CancelJournalEntries(Int32.Parse(txtJEC.Text), ref sCancelTransID)) //Cancelar Asiento
                {
                    this.txtJECC.Text = sCancelTransID; //ID del Asiento Cancelado
                    MessageBox.Show("Asiento Contable Cancelado");
                }
                else
                {
                    MessageBox.Show("Error al cancelar Asiento Contable");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnOC_Click(object sender, EventArgs e)
        {

            try
            {
                csDocuments oDoc = new csDocuments(); //Documento
                csDocumentLines oLine; //Lineas


                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.CardCode = "PL20612838550";
                oDoc.DocType = "I";
                oDoc.DocCurr = "SOL";
                oDoc.Comments = "Created by SDK";
                oDoc.U_U_C2410_P001 = "a";
                oDoc.U_U_C2410_P002 = "b";
                oDoc.TipoDoc = "OC";

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 10;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 20;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                oDoc.Lines.Add(oLine);//Add Linea 1
                string stransID = ""; //ID del Documento

                if (oSAP.AddMarketingDocument(oDoc, ref stransID)) //Agregar Documento
                {

                    MessageBox.Show("Documento Agregado");
                    this.txtOC.Text = stransID; //ID del Documento
                }

                else
                {
                    MessageBox.Show("Error al agregar Documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnEM_Click(object sender, EventArgs e)
        {
            try
            {
                csDocuments oDoc = new csDocuments(); //Documento
                csDocumentLines oLine; //Lineas
                csDocumentLinesBatch oBatch;
                csDocumentLinesBinAllocations oBin;


                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.CardCode = "PL20612838550";
                oDoc.DocType = "I";
                oDoc.DocCurr = "SOL";
                oDoc.Comments = "Created by SDK";
                oDoc.U_U_C2410_P001 = "a";
                oDoc.U_U_C2410_P002 = "b";
                oDoc.TipoDoc = "EM";

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 10;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //oLine.OcrCode5 = "";

                //Campos de Enlace
                oLine.BaseType = 22;
                oLine.BaseEntry = Int32.Parse(txtOC.Text);
                oLine.BaseLine = 0;
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 20;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //Campos de Enlace
                oLine.BaseType = 22;
                oLine.BaseEntry = Int32.Parse(txtOC.Text);
                oLine.BaseLine = 1;

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 10;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 10;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);
                #endregion


                oDoc.Lines.Add(oLine); //Add Linea 1
                string stransID = ""; //ID del Documento
                if (oSAP.AddMarketingDocument(oDoc, ref stransID)) //Agregar Documento
                {
                    MessageBox.Show("Documento Agregado");
                    this.txtEM.Text = stransID; //ID del Documento
                }
                else
                {
                    MessageBox.Show("Error al agregar Documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                csDocuments oDoc = new csDocuments(); //Documento
                csDocumentLines oLine; //Lineas
                csDocumentLinesBatch oBatch;
                csDocumentLinesBinAllocations oBin;


                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.CardCode = "PL20612838550";
                oDoc.DocType = "I";
                oDoc.DocCurr = "SOL";
                oDoc.Comments = "Created by SDK";
                oDoc.U_U_C2410_P001 = "a";
                oDoc.U_U_C2410_P002 = "b";
                oDoc.TipoDoc = "DC";

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 5;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //oLine.OcrCode5 = "";

                //Campos de Enlace
                oLine.BaseType = 20;
                oLine.BaseEntry = Int32.Parse(txtEM.Text);
                oLine.BaseLine = 0;
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 10;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //Campos de Enlace
                oLine.BaseType = 20;
                oLine.BaseEntry = Int32.Parse(txtEM.Text);
                oLine.BaseLine = 1;

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 5;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 5;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);
                #endregion
                /*  #region Ubicaciones

                  oBin = new csDocumentLinesBinAllocations();
                  oBin.BinAbsEntry = 2;
                  oBin.Quantity = 5;
                  oBin.SerialAndBatchNumbersBaseLine = 0;
                  oLine.LinesBinAllocations.Add(oBin);

                  oBin = new csDocumentLinesBinAllocations();
                  oBin.BinAbsEntry = 2;
                  oBin.Quantity = 5;
                  oBin.SerialAndBatchNumbersBaseLine = 1;
                  oLine.LinesBinAllocations.Add(oBin);
                  #endregion*/

                oDoc.Lines.Add(oLine); //Add Linea 1
                string stransID = ""; //ID del Documento
                if (oSAP.AddMarketingDocument(oDoc, ref stransID)) //Agregar Documento
                {
                    MessageBox.Show("Documento Agregado");
                    this.txtDC.Text = stransID; //ID del Documento
                }
                else
                {
                    MessageBox.Show("Error al agregar Documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                csDocuments oDoc = new csDocuments(); //Documento
                csDocumentLines oLine; //Lineas


                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.CardCode = "PL20612838550";
                oDoc.DocType = "I";
                oDoc.DocCurr = "SOL";
                oDoc.Comments = "Created by SDK";
                oDoc.U_U_C2410_P001 = "a";
                oDoc.U_U_C2410_P002 = "b";
                oDoc.TipoDoc = "FC";

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 5;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //Campos de enlace
                oLine.BaseType = 20;
                oLine.BaseEntry = Int32.Parse(txtEM.Text);
                oLine.BaseLine = 0;
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 15;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //Campos de enlace
                oLine.BaseType = 20;
                oLine.BaseEntry = Int32.Parse(txtEM.Text);
                oLine.BaseLine = 1;
                oDoc.Lines.Add(oLine);
                string stransID = ""; //ID del Documento
                if (oSAP.AddMarketingDocument(oDoc, ref stransID)) //Agregar Documento
                {
                    MessageBox.Show("Documento Agregado");
                    this.txtFC.Text = stransID; //ID del Documento
                }
                else
                {
                    MessageBox.Show("Error al agregar Documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                csDocuments oDoc = new csDocuments(); //Documento
                csDocumentLines oLine; //Lineas
                csDocumentLinesBatch oBatch;

                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.CardCode = "PL20612838550";
                oDoc.DocType = "I";
                oDoc.DocCurr = "SOL";
                oDoc.Comments = "Created by SDK";
                oDoc.U_U_C2410_P001 = "a";
                oDoc.U_U_C2410_P002 = "b";
                oDoc.TipoDoc = "NC";

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 5;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //oLine.OcrCode5 = "";

                //Campos de Enlace
                oLine.BaseType = 18;
                oLine.BaseEntry = Int32.Parse(txtFC.Text);
                oLine.BaseLine = 0;
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 10;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                //Campos de Enlace
                oLine.BaseType = 18;
                oLine.BaseEntry = Int32.Parse(txtFC.Text);
                oLine.BaseLine = 1;

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 5;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 5;
                //oBatch.MnfSerial = "";
                //oBatch.LotNumber = "";
                //oBatch.InDate =
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);
                #endregion

                oDoc.Lines.Add(oLine);//Add Linea 1
                string stransID = ""; //ID del Documento
                if (oSAP.AddMarketingDocument(oDoc, ref stransID)) //Agregar Documento
                {
                    MessageBox.Show("Documento Agregado");
                    this.txtNC.Text = stransID; //ID del Documento
                }
                else
                {
                    MessageBox.Show("Error al agregar Documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                csDocumentLinesBinAllocations oBin;
                csDocumentLinesBatch oBatch;
                csDocumentLines oLine;

                csDocuments oDoc = new csDocuments();
                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.Comments = "Created by SDK";
                // oDoc.BPLid = 1;
                oDoc.U_U_C2410_P001 = "Prueba1";
                oDoc.U_U_C2410_P002 = "Prueba2";
                oDoc.TipoDoc = "EI";

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 10;
                oLine.UnitPrice = 122.50;
                oLine.WhsCode = "M101";
                oLine.AcctCode = "4115101";
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";

                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 20;
                oLine.UnitPrice = 122.50;
                oLine.WhsCode = "A001";
                oLine.AcctCode = "4115102";
                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 20;
                oLine.WhsCode = "A001";
                oLine.UnitPrice = 100.00;
                oLine.AcctCode = "4115101";
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 10;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 10;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);
                #endregion


                /* #region Ubicaciones

                 //Lote 0
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 2;
                 oBin.Quantity = 3;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oLine.ListBinAllocation.Add(oBin);

                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 60;
                 oBin.Quantity = 7;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oLine.ListBinAllocation.Add(oBin);

                 //Lote 1
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 3;
                 oBin.Quantity = 10;
                 oBin.SerialAndbatchNumbersBaseLine = 1;
                 oLine.ListBinAllocation.Add(oBin);
                 #endregion */
                oDoc.Lines.Add(oLine);

                string sDocEntry = "";
                if (oSAP.AddMarketingDocument(oDoc, ref sDocEntry))
                {
                    this.txtEI.Text = sDocEntry;
                    MessageBox.Show("Documento creado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                csDocumentLinesBinAllocations oBin;
                csDocumentLinesBatch oBatch;
                csDocumentLines oLine;

                csDocuments oDoc = new csDocuments();
                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.Comments = "Created by SDK";
                // oDoc.BPLid = 1;
                oDoc.U_U_C2410_P001 = "Prueba1";
                oDoc.U_U_C2410_P002 = "Prueba2";
                oDoc.TipoDoc = "SI";

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 10;
                oLine.UnitPrice = 122.50;
                oLine.WhsCode = "A001";
                oLine.AcctCode = "4115101";
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";
                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 20;
                oLine.UnitPrice = 122.50;
                oLine.WhsCode = "A001";
                oLine.AcctCode = "4115102";
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 10;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 10;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);
                #endregion

                /* #region Ubicaciones

                 //Lote 0
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 2;
                 oBin.Quantity = 3;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oLine.ListBinAllocation.Add(oBin);

                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 60;
                 oBin.Quantity = 7;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oLine.ListBinAllocation.Add(oBin);

                 //Lote 1
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 3;
                 oBin.Quantity = 10;
                 oBin.SerialAndbatchNumbersBaseLine = 1;
                 oLine.ListBinAllocation.Add(oBin);
                 #endregion */

                oDoc.Lines.Add(oLine);

                string sDocEntry = "";
                if (oSAP.AddMarketingDocument(oDoc, ref sDocEntry))
                {
                    this.txtSI.Text = sDocEntry;
                    MessageBox.Show("Documento creado con éxito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Inventario_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                csDocumentLinesBinAllocations oBin;
                csDocumentLinesBatch oBatch;
                csDocumentLines oLine;

                csDocuments oDoc = new csDocuments();
                oDoc.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oDoc.Comments = "Created by SDK";
                oDoc.BPLid = 1;
                oDoc.U_U_C2410_P001 = "Prueba1";
                oDoc.U_U_C2410_P002 = "Prueba2";
                oDoc.Filler = "A001";
                oDoc.ToWhsCode = "M101";

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 5;
                //oLine.UnitPrice = 122.50;
                oLine.FromWhsCode = "A001";
                oLine.WhsCode = "M101";
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";

                /* oBin = new csDocumentLinesBinAllocations();
                 oBin.BinAbsEntry = 57;
                 oBin.Quantity = 5;
                 //oBin.SerialAndbatchNumbersBaseLine = 0;
                 oBin.Direction = 1;
                 oLine.LinesBinAllocations.Add(oBin);*/


                oDoc.Lines.Add(oLine);

                oLine = new csDocumentLines();
                oLine.ItemCode = "0050390002";
                oLine.Quantity = 10;
                oLine.FromWhsCode = "05";
                oLine.WhsCode = "05"; ;
                oLine.Project = "CRIS4";
                oLine.OcrCode1 = "TRANS";
                oLine.OcrCode2 = "CRIS4";
                oLine.OcrCode3 = "MANT";
                oLine.OcrCode4 = "NO-APLI";

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 5;
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 5;
                oLine.LinesBatch.Add(oBatch);
                #endregion

                /* #region Ubicaciones

                 //Lote 0
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 2;
                 oBin.Quantity = 2;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oBin.Direction = 2;
                 oLine.ListBinAllocation.Add(oBin);

                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 60;
                 oBin.Quantity = 3;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oBin.Direction = 2;
                 oLine.ListBinAllocation.Add(oBin);

                 //Llegada
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 50;
                 oBin.Quantity = 5;
                 oBin.SerialAndbatchNumbersBaseLine = 0;
                 oBin.Direction = 1;
                 oLine.ListBinAllocation.Add(oBin);

                 //Lote 1
                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 3;
                 oBin.Quantity = 5;
                 oBin.SerialAndbatchNumbersBaseLine = 1;
                 oBin.Direction = 2;
                 oLine.ListBinAllocation.Add(oBin);

                 oBin = new csDocumentLinesBinAllocation();
                 oBin.BinAbsEntry = 70;
                 oBin.Quantity = 5;
                 oBin.SerialAndbatchNumbersBaseLine = 1;
                 oBin.Direction = 1;
                 oLine.ListBinAllocation.Add(oBin);
                 #endregion*/

                oDoc.Lines.Add(oLine);

                string sDocEntry = "";
                if (oSAP.AddStockTransfers(oDoc, ref sDocEntry))
                {
                    this.txtTI.Text = sDocEntry;
                    MessageBox.Show("Documento creado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboListCancel.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona un documento para cancelar.");
                    return;
                }

                string sCancelDocEntry = "";
                if (oSAP.CancelMarketingDocument(cboListCancel.SelectedValue.ToString(),
                    Int32.Parse(txtDocCancel.Text), ref sCancelDocEntry))
                {
                    txtResultCancelDoc.Text = sCancelDocEntry;
                    MessageBox.Show("Documento cancelado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSAP.CloseMarketingDocument(cboListClose.SelectedValue.ToString(),
                    Int32.Parse(txtDocCerrar.Text)))
                {
                    MessageBox.Show("Documento cerrado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelarPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSAP.CancelPayments(comboBox1.SelectedValue.ToString(), Int32.Parse(this.txtPayCancel.Text)))
                {
                    MessageBox.Show("Pago cancaelado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                csPaymentsCCard oPayCCard;
                csPaymentsChecks oPayChecks;
                csPaymentsDet oPayDet;

                csPayments oPay = new csPayments();
                oPay.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.CardCode = "C06723225";
                oPay.DocType = "C";
                oPay.Comments = "Creted by SDK";
                oPay.CashAcct = "_SYS00000000001";
                oPay.CashSum = 1079.96;
                oPay.BPLId = 1;
                oPay.TipoDoc = "PR";

                oPayDet = new csPaymentsDet();
                oPayDet.InvoiceId = 1091;
                oPayDet.InvType = "13";
                oPayDet.SumApplied = 1079.96;
                oPay.ListDets.Add(oPayDet);


                string sDocEntry = "";
                if (oSAP.AddPayments(oPay, ref sDocEntry))
                {
                    this.txtInvoicePay.Text = sDocEntry;
                    MessageBox.Show("Pago creado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                csPaymentsCCard oPayCCard;
                csPaymentsChecks oPayChecks;
                csPaymentsDet oPayDet;

                csPayments oPay = new csPayments();
                oPay.DocDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.TaxDate = DateTime.Now.ToString("yyyyMMdd");
                oPay.CardCode = "P20610350772";
                oPay.DocType = "S";
                oPay.Comments = "Creted by SDK";
                oPay.CashAcct = "_SYS00000000001";
                oPay.CashSum = 2500.00;
                oPay.BPLId = 1;
                oPay.TipoDoc = "PE";

                oPayDet = new csPaymentsDet();
                oPayDet.InvoiceId = 1166;
                oPayDet.InvType = "18";
                oPayDet.SumApplied = 5000;
                oPay.ListDets.Add(oPayDet);

                oPayCCard = new csPaymentsCCard();
                oPayCCard.CreditCard = 3;
                oPayCCard.NumOfPmnts = 1;
                oPayCCard.CreditSum = 2500.00;
                oPayCCard.FirstPaymentDue = "20250101";
                oPayCCard.VoucherNum = "1234";
                oPayCCard.CreditAcct = "_SYS00000000005";
                oPay.ListCCard.Add(oPayCCard);

                string sDocEntry = "";
                if (oSAP.AddPayments(oPay, ref sDocEntry))
                {
                    this.txtOutgoingPay.Text = sDocEntry;
                    MessageBox.Show("Pago creado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                oSAP.ExecuteRecordSet(this.txtConsulta.Text);

                //Pasar consulta a lista de objetos
                string xml = csSAP.oRec.GetAsXML();

                XDocument XDoc = null;
                XDoc = XDocument.Parse(xml);

                var xElements2 = XDoc.XPathSelectElements("BOM/BO/ocrd");

                var ListaFinalX = xElements2.Descendants("row").Select((s, i) => new CsBussinesPartner
                {
                    CardCode = s.Element("cardcode").Value,
                    CardName = s.Element("cardname").Value,
                });

                List<CsBussinesPartner> ListaFinalW = xElements2.Descendants("row").Select((s, i) => new CsBussinesPartner
                {
                    CardCode = s.Element("cardcode").Value,
                    CardName = s.Element("cardname").Value,
                }).ToList();

                int conta = ListaFinalW.Count;

                foreach (CsBussinesPartner obj in ListaFinalW)
                {
                    string a = obj.CardCode;
                    string b = obj.CardName;
                };



                //Recorrido normal
                if (csSAP.oRec.RecordCount > 0)
                {
                    while (!csSAP.oRec.EoF)
                    {
                        txtConsulta.Text += csSAP.oRec.Fields.Item(0).Value.ToString() + " - " + csSAP.oRec.Fields.Item(1).Value.ToString();
                        csSAP.oRec.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    

}
