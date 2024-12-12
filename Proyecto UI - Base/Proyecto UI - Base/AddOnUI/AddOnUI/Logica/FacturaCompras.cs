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
        public static void GenerarControles(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Button oBtnCancel = oForm.Items.Item("2").Specific; //

                SAPbouiCOM.Item oItem = oForm.Items.Add("BtnAnu", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                oItem.Left = oBtnCancel.Item.Left + oBtnCancel.Item.Width + 7;
                oItem.Top = oBtnCancel.Item.Top;
                oItem.Width = 80;
                oItem.Height = oBtnCancel.Item.Height;

                SAPbouiCOM.Button oBtn = ((SAPbouiCOM.Button)(oItem.Specific));
                oBtn.Caption = "Anular Factura";

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void AnularCompra(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.ComboBox cEstado = oForm.Items.Item("81").Specific;
                string sEstado = cEstado.Selected.Value.ToString();

                if (sEstado != "1")
                {
                    throw new Exception("Solo se pueden cancelar documentos en estado abierto");
                }


                int iRpta = Globals.SBO_Application.MessageBox("Desea anular la factura?", 3, "Si", "No", "Quizas");


                if (iRpta == 1)
                {
                    SAPbouiCOM.EditText eDocNum = oForm.Items.Item("8").Specific;


                    Globals.Query = "SELECT \"DocEntry\" FROM OPCH WHERE \"DocNum\" = " + eDocNum.Value.ToString();
                    Globals.RunQuery(Globals.Query);
                    int iDocEntry = Int32.Parse(Globals.oRec.Fields.Item(0).Value.ToString());
                    Globals.Release(Globals.oRec);


                    SAPbobsCOM.Documents oDocSAP =
                       (SAPbobsCOM.Documents)Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseInvoices);


                    if (oDocSAP.GetByKey(iDocEntry))
                    {
                        SAPbobsCOM.Documents oDocCancel = oDocSAP.CreateCancellationDocument();
                        //modificar campos en el documento de cancelación
                        oDocCancel.Comments = oDocSAP.Comments + " - Cancelado por SDK";


                        Globals.lRetCode = oDocCancel.Add();


                        Globals.Release(oDocSAP);
                        Globals.Release(oDocCancel);


                        if (Globals.lRetCode == 0)
                        {
                            Globals.SBO_Application.SetStatusBarMessage("Documento anulado correctamente", SAPbouiCOM.BoMessageTime.bmt_Short, false);


                            Globals.SBO_Application.ActivateMenuItem("1304");
                        }
                        else
                        {
                            Globals.oCompany.GetLastError(out Globals.lErrCode, out Globals.sErrMsg);
                            throw new Exception(String.Concat(Globals.lErrCode, ": " + Globals.sErrMsg));
                        }
                    }
                    else
                    {
                        Globals.Release(oDocSAP);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
