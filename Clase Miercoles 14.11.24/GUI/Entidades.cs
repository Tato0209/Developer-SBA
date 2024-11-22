using BE;
using LN;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

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
                oLine.BaseType = 22;
                oLine.BaseEntry = Int32.Parse(txtOC.Text);
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
                oLine.BaseType = 22;
                oLine.BaseEntry = Int32.Parse(txtOC.Text);
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

                #region Ubicaciones

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
                oLine.Quantity = 1;
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
                oLine.BaseEntry = Int32.Parse(txtEM.Text);
                oLine.BaseLine = 0;

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

                oLine = new csDocumentLines(); //Linea 1
                oLine.ItemCode = "0050390001";
                oLine.Quantity = 1;
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

                oDoc.Lines.Add(oLine); //Add Linea 1
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
                oLine.ItemCode = "0010010001";
                oLine.Quantity = 1;
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

                #region Lotes
                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120002";
                oBatch.Quantity = 2;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                oBatch = new csDocumentLinesBatch();
                oBatch.BatchNumber = "1120003";
                oBatch.Quantity = 3;
                oBatch.MnfDate = "20240901";
                oBatch.ExpDate = "20250731";
                oLine.LinesBatch.Add(oBatch);

                #endregion


                oDoc.Lines.Add(oLine); //Add Linea 1
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
    }
}
