using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using BE;

namespace LN
{
    public class csSAP
    {
        public static Company oCompany;
        public static int iRet;
        public static string sErrMsg;
        public static int iErrCod;


        public bool LoginSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany == null || !oCompany.Connected) {
                    oCompany = new Company();
                    oCompany.Server = objCompany.ServerBD;
                    oCompany.DbUserName = objCompany.UsuarioBD;
                    oCompany.DbPassword = objCompany.PassBD;
                    if (objCompany.ServerLC != "") oCompany.LicenseServer = objCompany.ServerLC;
                    oCompany.CompanyDB = objCompany.NameBD;
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PassSAP;
                    switch (objCompany.ServerType) {
                        case 0:
                            oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                            break;
                        case 1:
                            oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2016;
                            break;
                        case 2:
                            oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                            break;
                    }
                    oCompany.language = BoSuppLangs.ln_Spanish_La;
                    iRet = oCompany.Connect();
                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ":", sErrMsg));
                        throw new Exception(String.Concat(iRet, ":", sErrMsg));

                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public bool AddItems(csItems objItems)
        {
            SAPbobsCOM.Items oItems =
                    (SAPbobsCOM.Items)oCompany.GetBusinessObject(BoObjectTypes.oItems);
            try
            {

                bool bExiste = oItems.GetByKey(objItems.ItemCode); // Verificar si existe el item

                oItems.ItemCode = objItems.ItemCode;
                oItems.ItemName = objItems.ItemName;
                oItems.ItemsGroupCode = objItems.GroupCode;
                oItems.InventoryItem = objItems.InvntItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                oItems.SalesItem = objItems.SellItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                oItems.PurchaseItem = objItems.PrchseItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                oItems.UserFields.Fields.Item("U_C2410_P001").Value = objItems.U_C2410_P001; // Como declarar campo de usuario 


                iRet = bExiste ? oItems.Update() : oItems.Add();   // Si existe actualiza, sino agrega
                if (iRet == 0) {
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod, ":", sErrMsg));
                    throw new Exception(String.Concat(iRet, ":", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oItems);
            }
        }

        public bool GetItems(ref csItems objItems)
        {
            SAPbobsCOM.Items oItems =
                      (SAPbobsCOM.Items)oCompany.GetBusinessObject(BoObjectTypes.oItems);
            try
            {


                if (oItems.GetByKey(objItems.ItemCode))// GetByKey busca el item por el código // Unico Item
                {
                    objItems.ItemCode = oItems.ItemCode;
                    objItems.ItemName = oItems.ItemName;
                    objItems.GroupCode = oItems.ItemsGroupCode;
                    objItems.InvntItem = oItems.InventoryItem == BoYesNoEnum.tYES ? "Y" : "N";
                    objItems.SellItem = oItems.SalesItem == BoYesNoEnum.tYES ? "Y" : "N";
                    objItems.PrchseItem = oItems.PurchaseItem == BoYesNoEnum.tYES ? "Y" : "N";
                    objItems.U_C2410_P001 = oItems.UserFields.Fields.Item("U_C2410_P001").Value;

                    return true;
                }
                else
                {
                    throw new Exception("Artículo no registrado en SAP");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oItems);
            }
        }

        public void Release(object obj)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);// Liberar objeto COM // Se instancia el objeto y se libera con esta función 
        }

        public bool DeleteItems(string ItemCODE) // Eliminar Item
        {
            SAPbobsCOM.Items oItems = //    Instanciar objeto Items
                    (SAPbobsCOM.Items)oCompany.GetBusinessObject(BoObjectTypes.oItems); // Instanciar objeto Items
            try
            {
                if (oItems.GetByKey(ItemCODE))// GetByKey busca el item por el código // Unico Item
                {
                    iRet = oItems.Remove(); // Eliminar Item

                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ":", sErrMsg));
                        throw new Exception(String.Concat(iRet, ":", sErrMsg));
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oItems);
            }
        }
    }

}