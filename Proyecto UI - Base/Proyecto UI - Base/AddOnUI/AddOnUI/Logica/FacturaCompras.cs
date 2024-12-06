using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddOnUI.App;


namespace AddOnUI.Logica
{
    public class FacturaCompras
    {
        /*public static void CrearFacturaCompras()
        {
            try
            {
                SAPbobsCOM.Documents oPurchaseInvoice = default(SAPbobsCOM.Documents);
                oPurchaseInvoice = (SAPbobsCOM.Documents)Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseInvoices);
                oPurchaseInvoice.CardCode = "C20000";
                oPurchaseInvoice.DocDate = DateTime.Now;
                oPurchaseInvoice.DocDueDate = DateTime.Now;
                oPurchaseInvoice.TaxDate = DateTime.Now;
                oPurchaseInvoice.Lines.ItemCode = "A00001";
                oPurchaseInvoice.Lines.Quantity = 1;
                oPurchaseInvoice.Lines.Price = 100;
                oPurchaseInvoice.Lines.Add();
                if (oPurchaseInvoice.Add() != 0)
                {
                    Globals.SBO_Application.MessageBox(Globals.oCompany.GetLastErrorDescription());
                }
                else
                {
                    Globals.SBO_Application.MessageBox("Factura de compras creada correctamente");
                }
            }
            catch (Exception ex)
            {
                Globals.SBO_Application.MessageBox(ex.Message);
            }
        }*/

        public static void GenerarControles(SAPbouiCOM.Form oform)
        {
            try
            {
                SAPbouiCOM.Item oItem = oform.Items.Add("BtnAnu", SAPbouiCOM.BoFormItemTypes.it_BUTTON); // Agregar un boton a un formulario
                oItem.Left = 100; // Posicion en X
                oItem.Top = 100; // Posicion en Y
                oItem.Width = 100; // Ancho
                oItem.Height = 20; // Alto
                SAPbouiCOM.Button oButton = ((SAPbouiCOM.Button)oItem.Specific); // Castear el item a un boton
                oButton.Caption = "Anular Factura"; // Texto del boton
                // ((SAPbouiCOM.Button) oItem.Specific).Caption = "Anular Factura"; // Otra forma de asignar el texto del boton

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
