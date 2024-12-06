using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddOnUI.Logica;

namespace AddOnUI.App
{
    public class Main
    {
        public Main()
        {
            Connect.SetApplication();
            Connect.ConnectToCompany();

            Connect.SetFilters();

            Globals.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent); // Evento de item
            Globals.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(SBO_Application_FormDataEvent); // Evento de formulario
            Globals.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent); // Evento de aplicacion
            Globals.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent); // Evento de menu

            Menu.AddMenuItems();
            Menu.AddMenu();

            Globals.continuar = 0;
            Globals.SBO_Application.MessageBox("AddonPruebas conectado");
        }


        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.FormTypeEx != "0")
            {
                try
                {
                    SAPbouiCOM.Form oForm = Globals.SBO_Application.Forms.Item(pVal.FormUID);
                    if(pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD)
                    {

                        if(pVal.BeforeAction == true)
                        {
                            if (oForm.TypeEx == "141")
                            {
                                FacturaCompras.GenerarControles(oForm);
                            }

                            //ANTES DE CARGAR EL FORMULARIO
                        }
                        else
                        {
                            //DESPUES DE CARGAR EL FORMULARIO
                        }
                    }
                }
                catch (Exception ex)
                {
                    BubbleEvent = false;
                    if (ex.Message.IndexOf("Form - Not found  [66000-9]") != -1)
                    {
                        Globals.Error = "SYP: Activar campos de usuario al crear un documento";
                        Globals.SBO_Application.SetStatusBarMessage(Globals.Error, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    }
                    else
                    {
                        Globals.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    }
                }
            }
        }

        private void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
               

            }
            catch (Exception ex)
            {
                Globals.SBO_Application.SetStatusBarMessage(ex.Message);
                BubbleEvent = false;
                return;
            }
        }

        private void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            if (EventType == SAPbouiCOM.BoAppEventTypes.aet_ShutDown)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (EventType == SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (EventType == SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (EventType == SAPbouiCOM.BoAppEventTypes.aet_FontChanged)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (EventType == SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

           
        }
    }
}
