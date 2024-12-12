using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddOnUI.App;

namespace AddOnUI.Logica
{
    public class FormTest
    {
        public static void Action(SAPbouiCOM.Form oform, SAPbouiCOM.ItemEvent pval)
        {
            try
            {
                if (pval.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD)
                {

                    if (pval.BeforeAction)
                    {
                       
                        
                        //ANTES DE CARGAR EL FORMULARIO
                    }
                    else
                    {
                        SAPbouiCOM.EditText startDate = (SAPbouiCOM.EditText)oform.Items.Item("Item_1").Specific;
                        SAPbouiCOM.EditText endDate = (SAPbouiCOM.EditText)oform.Items.Item("Item_3").Specific;

                        startDate.Value = DateTime.Now.ToString("yyyyMMdd");
                        endDate.Value = DateTime.Now.ToString("yyyyMMdd");
                        //DESPUES DE CARGAR EL FORMULARIO
                    }

                }


                if (pval.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)
                {
                    if (pval.BeforeAction)
                    {

                    }
                    else
                    {
                        if (pval.ItemUID == "Item_10")
                        {
                            Cerrar(oform);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void CargarFormulario()
        {
            SAPbouiCOM.Form oForm = default(SAPbouiCOM.Form);


            try
            {
                oForm = Globals.SBO_Application.Forms.Item("PruebasForm_2");
                Globals.SBO_Application.MessageBox("El formulario ya se encuentra abierto");
            }
            catch
            {
                SAPbouiCOM.FormCreationParams fcp = default(SAPbouiCOM.FormCreationParams);
                fcp = Globals.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams);
                fcp.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Sizable;
                fcp.FormType = "PruebasForm";
                fcp.UniqueID = "PruebasForm_2";
                string FormName = "\\PruebasForm.srf";
                fcp.XmlData = Globals.LoadFromXML(ref FormName);
                oForm = Globals.SBO_Application.Forms.AddEx(fcp);
            }
            oForm.Top = 50;
            oForm.Left = 200;
            oForm.Visible = true;
        }

        public static void Cerrar(SAPbouiCOM.Form oform)
        {
            try
            {
                oform.Close();
                return;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
