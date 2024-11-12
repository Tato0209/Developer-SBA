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
                Release(oItems);// Liberar objeto Items
            }
        }
        public bool AddBussinesPartner(CsBussinesPartner objBussinesPartner)
        {
            SAPbobsCOM.BusinessPartners oBP = //    Instanciar objeto BusinessPartners
                    (SAPbobsCOM.BusinessPartners)oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);// Instanciar objeto BusinessPartners
            try
            {
                bool bExiste = oBP.GetByKey(objBussinesPartner.CardCode); // Verificar si existe el item

                oBP.CardCode = objBussinesPartner.CardCode; //  Código del Socio de Negocio
                oBP.CardName = objBussinesPartner.CardName; // Nombre del Socio de Negocio
                oBP.FederalTaxID = objBussinesPartner.LicTradNum; // NIT
                oBP.CardType = objBussinesPartner.CardType == "C" ? BoCardTypes.cCustomer ://    Tipo de Socio de Negocio
                               objBussinesPartner.CardType == "S" ? BoCardTypes.cSupplier :BoCardTypes.cLid; // Tipo de Socio de Negocio
                oBP.GroupCode = objBussinesPartner.GroupCode;
                //oBP.UserFields.Fields.Item("U_C2410_P001").Value = objBussinesPartner.U_C2410_P001; // Como declarar campo de usuario
                if(objBussinesPartner.U_C2410_P001 != null && objBussinesPartner.U_C2410_P001 != "") oBP.UserFields.Fields.Item("U_C2410_P001").Value = objBussinesPartner.U_C2410_P001;
                //oBP.UserFields.Fields.Item("U_C2410_P002").Value = objBussinesPartner.U_C2410_P002; // Como declarar campo de usuario
                if (objBussinesPartner.U_C2410_P002 != null && objBussinesPartner.U_C2410_P002 != "") oBP.UserFields.Fields.Item("U_C2410_P002").Value = objBussinesPartner.U_C2410_P002; // validar si el campo es nulo o vacio

                foreach (csAddress objAddress in objBussinesPartner.listAddress) // Recorrer lista de direcciones
                {
                   
                    oBP.Addresses.AddressName = objAddress.Address;
                    if (oBP.Addresses.AddressName2 != null && oBP.Addresses.AddressName != "") oBP.Addresses.AddressName2 = objAddress.Address2; //siempre validar que el campo no vaya vacio o null
                    if (oBP.Addresses.Street != null && oBP.Addresses.Street != "") oBP.Addresses.Street = objAddress.Street;
                    if (oBP.Addresses.Block != null && oBP.Addresses.Block != "") oBP.Addresses.Block = objAddress.Block;
                    if (oBP.Addresses.City != null && oBP.Addresses.City != "") oBP.Addresses.City = objAddress.City;
                    if (oBP.Addresses.State != null && oBP.Addresses.State != "") oBP.Addresses.State = objAddress.State;
                    if (oBP.Addresses.Country != null && oBP.Addresses.Country != "") oBP.Addresses.Country = objAddress.Country;
                    oBP.Addresses.AddressType = objAddress.AdresType == "B" ? BoAddressType.bo_BillTo : BoAddressType.bo_ShipTo;
                    oBP.Addresses.Add(); // Agregar Dirección
                }

                foreach (csContacts objContacts in objBussinesPartner.listContacts) // Recorrer lista de contactos
                {
                    oBP.ContactEmployees.Name = objContacts.Name;
                    oBP.ContactEmployees.FirstName = objContacts.FirstName;
                    oBP.ContactEmployees.MiddleName = objContacts.MiddleName;
                    oBP.ContactEmployees.LastName = objContacts.LastName;
                    oBP.ContactEmployees.MobilePhone = objContacts.Cellolar;
                    oBP.ContactEmployees.Add(); // Agregar Contacto
                }

                iRet = oBP.Add();   // Si existe actualiza, sino agrega
                if (iRet == 0)
                {
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);// Obtener mensaje de error
                    throw new Exception(String.Concat(iErrCod, ":", sErrMsg)); // Lanzar excepción
                    throw new Exception(String.Concat(iRet, ":", sErrMsg)); // Lanzar excepción
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oBP);
            }
        }
        public bool GetBusinessPartners(ref CsBussinesPartner objBusinessPartners)
        {
            SAPbobsCOM.BusinessPartners oBP =
              (SAPbobsCOM.BusinessPartners)oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);
            try
            {
                if (oBP.GetByKey(objBusinessPartners.CardCode))
                {
                    objBusinessPartners.CardCode = oBP.CardCode;
                    objBusinessPartners.CardName = oBP.CardName;
                    objBusinessPartners.LicTradNum = oBP.FederalTaxID;
                    objBusinessPartners.CardType = oBP.CardType == BoCardTypes.cCustomer ? "C" :
                                                    oBP.CardType == BoCardTypes.cCustomer ? "S" : "L";
                    objBusinessPartners.GroupCode = oBP.GroupCode;
                    objBusinessPartners.U_C2410_P001 = oBP.UserFields.Fields.Item("U_C2410_P001").Value;
                    objBusinessPartners.U_C2410_P002 = oBP.UserFields.Fields.Item("U_C2410_P002").Value;


                    for (int i = 0; i < oBP.Addresses.Count; i++)
                    {
                        oBP.Addresses.SetCurrentLine(i);
                        if (oBP.Addresses.AddressName != "")
                        {
                            csAddress objAddress = new csAddress();
                            objAddress.Address = oBP.Addresses.AddressName;
                            objAddress.Address2 = oBP.Addresses.AddressName2;
                            objAddress.Street = oBP.Addresses.Street;
                            objAddress.Block = oBP.Addresses.Block;
                            objAddress.City = oBP.Addresses.City;
                            objAddress.State = oBP.Addresses.State;
                            objAddress.Country = oBP.Addresses.Country;
                            objAddress.AdresType = oBP.Addresses.AddressType == BoAddressType.bo_BillTo ? "B" : "S";
                            objBusinessPartners.listAddress.Add(objAddress);
                        }
                    }


                    for (int i = 0; i < oBP.ContactEmployees.Count; i++)
                    {
                        oBP.ContactEmployees.SetCurrentLine(i);
                        
                       if( oBP.ContactEmployees.InternalCode != -1)
                        {
                            csContacts objContacts = new csContacts();
                            objContacts.Name = oBP.ContactEmployees.Name;
                            objContacts.FirstName = oBP.ContactEmployees.FirstName;
                            objContacts.MiddleName = oBP.ContactEmployees.MiddleName;
                            objContacts.LastName = oBP.ContactEmployees.LastName;
                            objContacts.Cellolar = oBP.ContactEmployees.MobilePhone;
                            objBusinessPartners.listContacts.Add(objContacts);
                        }
                        
                    }


                    return true;


                }
                else
                {
                    throw new Exception("Socio de Negocio no existe en SAP");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oBP);
            }
        }
    }
}