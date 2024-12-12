using AddOnUI.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Xml.Linq;


namespace AddOnUI.Logica
{
    internal class EntradaInventario
    {
        public static void GenerarControles(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Button oBtnCancel = oForm.Items.Item("2").Specific; 

                SAPbouiCOM.Item oItem = oForm.Items.Add("BtnCancel", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                oItem.Left = oBtnCancel.Item.Left + oBtnCancel.Item.Width + 7;
                oItem.Top = oBtnCancel.Item.Top;
                oItem.Width = 80;
                oItem.Height = oBtnCancel.Item.Height;

                SAPbouiCOM.Button oBtn = ((SAPbouiCOM.Button)(oItem.Specific));
                oBtn.Caption = "Cancelar Entrada";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AnularEntrada(SAPbouiCOM.Form oForm)
        {
            try
            {
                int iRpta = Globals.SBO_Application.MessageBox("Desea anular la entrada?", 3, "Si", "No", "Quizas");

                if (iRpta == 1)
                {
                    SAPbouiCOM.EditText eDocNum = oForm.Items.Item("7").Specific;

                    SAPbobsCOM.Documents oDocSAP =
                       (SAPbobsCOM.Documents)Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);
                    oDocSAP.DocDate = DateTime.Now;
                    oDocSAP.TaxDate = DateTime.Now;
                    SAPbouiCOM.Matrix mDetalle = oForm.Items.Item("13").Specific;//que es matrix En el contexto de SAP Business One, Matrix y Item("13") tienen significados específicos:
                    /*Matrix
                            SAPbouiCOM.Matrix es un control de interfaz de usuario en SAP Business One que permite mostrar datos en una estructura de tabla.Es similar a una tabla en una base de datos o una cuadrícula en una aplicación de escritorio. Cada fila y columna en la matriz puede contener diferentes tipos de controles, como textos, botones, etc.
                            Item("13")
                            oForm.Items.Item("13") se refiere a un elemento específico en el formulario SAP Business One identificado por el ID "13".En este caso, se está accediendo a un control Matrix en el formulario.El ID "13" es un identificador único para ese control en particular dentro del formulario.
                            */
                    for (int i = 1;i <=mDetalle.RowCount; i++)
                    {
                       oDocSAP.Lines.ItemCode = mDetalle.Columns.Item("1").Cells.Item(i).Specific.Value.ToString();
                       oDocSAP.Lines.Quantity = double.Parse(mDetalle.Columns.Item("9").Cells.Item(i).Specific.Value.ToString());
                       oDocSAP.Lines.WarehouseCode = mDetalle.Columns.Item("15").Cells.Item(i).Specific.Value.ToString();
                       oDocSAP.Lines.Add();
                    }

                    if(oDocSAP.Add().Equals(0))
                    {
                        string sDocEntry = Globals.oCompany.GetNewObjectKey();
                        Globals.Release(oDocSAP);
                        Globals.SBO_Application.SetStatusBarMessage(String.Concat("Salida de inventario anulada correctamente. DocEntry: ", sDocEntry),
                            SAPbouiCOM.BoMessageTime.bmt_Short, false);
                    }
                    else
                    {
                        Globals.oCompany.GetLastError(out Globals.lErrCode, out Globals.sErrMsg);
                        throw new Exception(String.Concat(Globals.lErrCode, ": " + Globals.sErrMsg));
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
