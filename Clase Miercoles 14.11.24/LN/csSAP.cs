using BE;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LN
{
    public class csSAP
    {
        public static Company oCompany;
        public static int iRet;
        public static string sErrMsg;
        public static int iErrCod;
        public static Recordset oRec = null;


        public bool LoginSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany == null || !oCompany.Connected)
                {
                    oCompany = new Company(); // Instanciar objeto Company
                    oCompany.Server = objCompany.ServerBD;// Servidor de la base de datos
                    oCompany.DbUserName = objCompany.UsuarioBD;// Usuario de la base de datos
                    oCompany.DbPassword = objCompany.PassBD;// Contraseña de la base de datos
                    if (objCompany.ServerLC != "") oCompany.LicenseServer = objCompany.ServerLC;// Servidor de licencias
                    oCompany.CompanyDB = objCompany.NameBD;
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PassSAP;
                    switch (objCompany.ServerType)
                    {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Release(object obj)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
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
                oItems.InventoryItem = objItems.InvntItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO; // Si es inventariable
                oItems.SalesItem = objItems.SellItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;// Si es de venta
                oItems.PurchaseItem = objItems.PrchseItem == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;// Si es de compra
                oItems.UserFields.Fields.Item("U_C2410_P001").Value = objItems.U_C2410_P001; // Como declarar campo de usuario 


                iRet = bExiste ? oItems.Update() : oItems.Add();   // Si existe actualiza, sino agrega
                if (iRet == 0)
                {// Si no hay error
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);// Obtener mensaje de error
                    throw new Exception(String.Concat(iErrCod, ":", sErrMsg));// Lanzar excepción
                    throw new Exception(String.Concat(iRet, ":", sErrMsg));// Lanzar excepción
                }
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
                               objBussinesPartner.CardType == "S" ? BoCardTypes.cSupplier : BoCardTypes.cLid; // Tipo de Socio de Negocio
                oBP.GroupCode = objBussinesPartner.GroupCode;
                //oBP.UserFields.Fields.Item("U_C2410_P001").Value = objBussinesPartner.U_C2410_P001; // Como declarar campo de usuario
                if (objBussinesPartner.U_C2410_P001 != null && objBussinesPartner.U_C2410_P001 != "") oBP.UserFields.Fields.Item("U_C2410_P001").Value = objBussinesPartner.U_C2410_P001;
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

                        if (oBP.ContactEmployees.InternalCode != -1)
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
        public bool DeleteBussinesPartner(string CardCode)
        {
            SAPbobsCOM.BusinessPartners oBP = //    Instanciar objeto BusinessPartners
                   (SAPbobsCOM.BusinessPartners)oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);// Instanciar objeto BusinessPartners
            try
            {
                if (oBP.GetByKey(CardCode))// GetByKey busca el BusinessPartner por el código // Unico Partner
                {
                    iRet = oBP.Remove(); // Eliminar bussinesPartner

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
                Release(oBP);// Liberar objeto BusinessPartners
            }
        }
        public bool UpdateBussinesPartner(string CardCode)
        {
            SAPbobsCOM.BusinessPartners oBP = //    Instanciar objeto BusinessPartners
                   (SAPbobsCOM.BusinessPartners)oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);// Instanciar objeto BusinessPartners
            try
            {
                if (oBP.GetByKey(CardCode))// GetByKey busca el BusinessPartner por el código // Unico Partner
                {
                    // oBP.CardName = "NUEVO NOMBRE"; // Nombre del Socio de Negocio //Declarar el campo que se va a actualizar

                    iRet = oBP.Update(); // Actualizar bussinesPartner
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
                Release(oBP);// Liberar objeto BusinessPartners
            }
        }
        public bool AddJournalEntries(csJournalEntry objJournalEntry, ref string sTransID) // Agregar asiento contable // Agregar JournalEntries //sTransID = ID de la transacción
        {
            SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)oCompany.GetBusinessObject(BoObjectTypes.oJournalEntries);
            try
            {
                oJE.ReferenceDate = GetFecha(objJournalEntry.RefDate); // Fecha de referencia
                oJE.DueDate = GetFecha(objJournalEntry.DueDate); // Fecha de vencimiento
                oJE.TaxDate = GetFecha(objJournalEntry.TaxDate);
                oJE.Memo = objJournalEntry.Memo;
                oJE.Reference = objJournalEntry.Ref1;
                oJE.Reference2 = objJournalEntry.Ref2;
                oJE.Reference3 = objJournalEntry.Ref3;
                if (objJournalEntry.Indicator != null && objJournalEntry.Indicator != "") oJE.Indicator = objJournalEntry.Indicator; // Indicador
                if (objJournalEntry.Project != null && objJournalEntry.Project != "") oJE.ProjectCode = objJournalEntry.Project; //proyecto
                if (objJournalEntry.TransCode != null && objJournalEntry.TransCode != "") oJE.TransactionCode = objJournalEntry.TransCode; // Código de transacción


                foreach (csJournalEntryLines objLine in objJournalEntry.Lines) // Recorrer lista de líneas  //
                {
                    if (objLine.Account != null && objLine.Account != "") oJE.Lines.AccountCode = objLine.Account;
                    if (objLine.ShortName != null && objLine.ShortName != "") oJE.Lines.ShortName = objLine.ShortName;
                    if (objLine.Debit != 0) oJE.Lines.Debit = objLine.Debit;
                    if (objLine.Credit != 0) oJE.Lines.Credit = objLine.Credit;
                    if (objLine.FCDebit != 0) oJE.Lines.FCDebit = objLine.FCDebit;
                    if (objLine.FCCredit != 0) oJE.Lines.FCCredit = objLine.FCCredit;
                    if (objLine.FCCurrency != null && objLine.FCCurrency != "") oJE.Lines.FCCurrency = objLine.FCCurrency;
                    if (objLine.Project != null && objLine.Project != "") oJE.Lines.ProjectCode = objLine.Project;
                    if (objLine.LineMemo != null && objLine.LineMemo != "") oJE.Lines.LineMemo = objLine.LineMemo;
                    if (objLine.Ref1 != null && objLine.Ref1 != "") oJE.Lines.Reference1 = objLine.Ref1;
                    if (objLine.Ref2 != null && objLine.Ref2 != "") oJE.Lines.Reference2 = objLine.Ref2;
                    if (objLine.Ref3 != null && objLine.Ref3 != "") oJE.Lines.AdditionalReference = objLine.Ref3;
                    if (objLine.OcrCode1 != null && objLine.OcrCode1 != "") oJE.Lines.CostingCode = objLine.OcrCode1;
                    if (objLine.OcrCode2 != null && objLine.OcrCode2 != "") oJE.Lines.CostingCode2 = objLine.OcrCode2;
                    if (objLine.OcrCode3 != null && objLine.OcrCode3 != "") oJE.Lines.CostingCode3 = objLine.OcrCode3;
                    if (objLine.OcrCode4 != null && objLine.OcrCode4 != "") oJE.Lines.CostingCode4 = objLine.OcrCode4;
                    if (objLine.OcrCode5 != null && objLine.OcrCode5 != "") oJE.Lines.CostingCode5 = objLine.OcrCode5;
                    if (objLine.BPLId != 0) oJE.Lines.BPLID = objLine.BPLId; // Branch //VALIDAR QUE EL CAMPO NO SEA 0


                    oJE.Lines.Add();
                }


                iRet = oJE.Add(); // Agregar JournalEntries


                if (iRet == 0)
                {
                    sTransID = oCompany.GetNewObjectKey(); // Obtener el ID de la transacción
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oJE);
            }
        }
        public bool CancelJournalEntries(int iTransId, ref string sTransIDCancel) // Cancelar asiento contable // Cancelar JournalEntries //sTransIDCancel = ID de la transacción cancelada
        {
            SAPbobsCOM.JournalEntries oJE = (SAPbobsCOM.JournalEntries)oCompany.GetBusinessObject(BoObjectTypes.oJournalEntries); // Instanciar objeto JournalEntries
            try
            {
                if (oJE.GetByKey(iTransId)) // GetByKey busca el JournalEntries por el ID // Unico JournalEntries
                {
                    iRet = oJE.Cancel();// Cancelar JournalEntries

                    if (iRet == 0)
                    {
                        sTransIDCancel = oCompany.GetNewObjectKey(); // Obtener el ID de la transacción
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
                }
                else
                {
                    throw new Exception("Registro no existe en SAP");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oJE);
            }
        }
        public bool AddMarketingDocument(csDocuments objDoc, ref string sDocEntry)
        {
            SAPbobsCOM.Documents oDocSAP = null;

            try
            {
                switch (objDoc.TipoDoc)
                {
                    case "OC": //Orden de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseOrders);
                        break;
                    case "EC": //Entrada de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
                        break;
                    case "DC": //Devolucion de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseReturns);
                        break;
                    case "FC": //Factura de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseInvoices);
                        break;
                    case "NC": //Nota de Credito de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseCreditNotes);
                        break;
                    //******* VENTAS ********
                    case "OV": //Orden de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oOrders);
                        break;
                    case "EV": //Entrada de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oDeliveryNotes);
                        break;
                    case "DV": //Devolucion de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oReturns);
                        break;
                    case "FV": //Factura de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInvoices);
                        break;
                    case "NV": //Nota de Credito de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oCreditNotes);
                        break;
                    //******* INVENTARIOS ********
                    case "EI": //Entrada de Inventario
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                        break;
                    case "SI": //Salida de Inventario
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                        break;
                }

                if (objDoc.CardCode != null && objDoc.CardCode != "") oDocSAP.CardCode = objDoc.CardCode;
                if (objDoc.CardName != null && objDoc.CardName != "") oDocSAP.CardName = objDoc.CardName;
                if (objDoc.DocDate != null && objDoc.DocDate != "") oDocSAP.DocDate = GetFecha(objDoc.DocDate);
                if (objDoc.DocDueDate != null && objDoc.DocDueDate != "") oDocSAP.DocDueDate = GetFecha(objDoc.DocDueDate);
                if (objDoc.TaxDate != null && objDoc.TaxDate != "") oDocSAP.TaxDate = GetFecha(objDoc.TaxDate);
                if (objDoc.NumAtCard != null && objDoc.NumAtCard != "") oDocSAP.NumAtCard = objDoc.NumAtCard;
                if (objDoc.GroupNum != null && objDoc.GroupNum != 0) oDocSAP.GroupNumber = objDoc.GroupNum;
                if (objDoc.SlpCode != null && objDoc.SlpCode != 0) oDocSAP.SalesPersonCode = objDoc.SlpCode;
                oDocSAP.Comments = objDoc.Comments;
                if (objDoc.Indicator != null && objDoc.Indicator != "") oDocSAP.Indicator = objDoc.Indicator;
                if (objDoc.DocType != null && objDoc.DocType != "") oDocSAP.DocType = objDoc.DocType == "I" ? BoDocumentTypes.dDocument_Items : BoDocumentTypes.dDocument_Service;
                if (objDoc.DocCurr != null && objDoc.DocCurr != "") oDocSAP.DocCurrency = objDoc.DocCurr;
                if (objDoc.BPLid != null && objDoc.BPLid != 0) oDocSAP.BPL_IDAssignedToInvoice = objDoc.BPLid;
                oDocSAP.UserFields.Fields.Item("U_U_C2410_P001").Value = objDoc.U_U_C2410_P001;
                oDocSAP.UserFields.Fields.Item("U_U_C2410_P002").Value = objDoc.U_U_C2410_P002;

                foreach (csDocumentLines objLine in objDoc.Lines)
                {
                    if (objLine.ItemCode != null && objLine.ItemCode != "") oDocSAP.Lines.ItemCode = objLine.ItemCode;
                    if (objLine.Dscrption != null && objLine.Dscrption != "") oDocSAP.Lines.ItemDescription = objLine.Dscrption;
                    if (objLine.Quantity != 0) oDocSAP.Lines.Quantity = objLine.Quantity;
                    if (objLine.WhsCode != null && objLine.WhsCode != "") oDocSAP.Lines.WarehouseCode = objLine.WhsCode;
                    if (objLine.AcctCode != null && objLine.AcctCode != "") oDocSAP.Lines.AccountCode = objLine.AcctCode;
                    oDocSAP.Lines.UnitPrice = objLine.UnitPrice;
                    if (objLine.DiscPrcnt != 0) oDocSAP.Lines.DiscountPercent = objLine.DiscPrcnt;
                    if (objLine.TaxCode != null && objLine.TaxCode != "") oDocSAP.Lines.TaxCode = objLine.TaxCode;
                    if (objLine.Project != null && objLine.Project != "") oDocSAP.Lines.ProjectCode = objLine.Project;
                    if (objLine.OcrCode1 != null && objLine.OcrCode1 != "") oDocSAP.Lines.CostingCode = objLine.OcrCode1;
                    if (objLine.OcrCode2 != null && objLine.OcrCode2 != "") oDocSAP.Lines.CostingCode2 = objLine.OcrCode2;
                    if (objLine.OcrCode3 != null && objLine.OcrCode3 != "") oDocSAP.Lines.CostingCode3 = objLine.OcrCode3;
                    if (objLine.OcrCode4 != null && objLine.OcrCode4 != "") oDocSAP.Lines.CostingCode4 = objLine.OcrCode4;
                    if (objLine.OcrCode5 != null && objLine.OcrCode5 != "") oDocSAP.Lines.CostingCode5 = objLine.OcrCode5;
                    if (objLine.BaseType != 0)
                    {
                        oDocSAP.Lines.BaseType = objLine.BaseType;
                        oDocSAP.Lines.BaseEntry = objLine.BaseEntry;
                        oDocSAP.Lines.BaseLine = objLine.BaseLine;
                    }

                    #region Lotes
                    foreach (csDocumentLinesBatch objBatch in objLine.LinesBatch)
                    {
                        oDocSAP.Lines.BatchNumbers.BatchNumber = objBatch.BatchNumber;
                        oDocSAP.Lines.BatchNumbers.Quantity = objBatch.Quantity;
                        if (objBatch.MnfSerial != null && objBatch.MnfSerial != "") oDocSAP.Lines.BatchNumbers.ManufacturerSerialNumber = objBatch.MnfSerial;
                        if (objBatch.LotNumber != null && objBatch.LotNumber != "") oDocSAP.Lines.BatchNumbers.InternalSerialNumber = objBatch.LotNumber;
                        if (objBatch.InDate != null && objBatch.InDate != "") oDocSAP.Lines.BatchNumbers.AddmisionDate = GetFecha(objBatch.InDate);
                        if (objBatch.MnfDate != null && objBatch.MnfDate != "") oDocSAP.Lines.BatchNumbers.ManufacturingDate = GetFecha(objBatch.MnfDate);
                        if (objBatch.ExpDate != null && objBatch.ExpDate != "") oDocSAP.Lines.BatchNumbers.ExpiryDate = GetFecha(objBatch.ExpDate);

                        oDocSAP.Lines.BatchNumbers.Add();
                    }
                    #endregion

                    #region Ubicaciones
                    foreach (csDocumentLinesBinAllocations objBin in objLine.LinesBinAllocations)
                    {
                        oDocSAP.Lines.BinAllocations.Quantity = objBin.Quantity;
                        if (objBin.BinAbsEntry != 0) oDocSAP.Lines.BinAllocations.BinAbsEntry = objBin.BinAbsEntry;
                        oDocSAP.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = objBin.SerialAndBatchNumbersBaseLine;

                        oDocSAP.Lines.BinAllocations.Add();
                    }
                    #endregion

                    oDocSAP.Lines.Add();
                }

                iRet = oDocSAP.Add();

                if (iRet == 0)
                {
                    sDocEntry = oCompany.GetNewObjectKey();
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);
            }
        }
        public bool AddStockTransfers(csDocuments objDoc, ref string sDocEntry)
        {
            SAPbobsCOM.StockTransfer oDocSAP = null;
            try
            {
                oDocSAP = (SAPbobsCOM.StockTransfer)oCompany.GetBusinessObject(BoObjectTypes.oStockTransfer);

                if (objDoc.CardCode != null && objDoc.CardCode != "") oDocSAP.CardCode = objDoc.CardCode;
                if (objDoc.CardName != null && objDoc.CardName != "") oDocSAP.CardName = objDoc.CardName;
                if (objDoc.DocDate != null && objDoc.DocDate != "") oDocSAP.DocDate = GetFecha(objDoc.DocDate);
                if (objDoc.TaxDate != null && objDoc.TaxDate != "") oDocSAP.TaxDate = GetFecha(objDoc.TaxDate);
                if (objDoc.SlpCode != null && objDoc.SlpCode != 0) oDocSAP.SalesPersonCode = objDoc.SlpCode;
                oDocSAP.Comments = objDoc.Comments;
                if (objDoc.Filler != null && objDoc.Filler != "") oDocSAP.FromWarehouse = objDoc.Filler;
                if (objDoc.ToWhsCode != null && objDoc.ToWhsCode != "") oDocSAP.ToWarehouse = objDoc.ToWhsCode;
              //  oDocSAP.UserFields.Fields.Item("U_C2410_P001").Value = objDoc.U_U_C2410_P001;
               // oDocSAP.UserFields.Fields.Item("U_C2410_P002").Value = objDoc.U_U_C2410_P002;

                foreach (csDocumentLines objLine in objDoc.Lines)
                {
                    if (objLine.ItemCode != null && objLine.ItemCode != "") oDocSAP.Lines.ItemCode = objLine.ItemCode;
                    if (objLine.Dscrption != null && objLine.Dscrption != "") oDocSAP.Lines.ItemDescription = objLine.Dscrption;
                    if (objLine.Quantity != 0) oDocSAP.Lines.Quantity = objLine.Quantity;
                    if (objLine.FromWhsCode != null && objLine.FromWhsCode != "") oDocSAP.Lines.FromWarehouseCode = objLine.FromWhsCode;
                    if (objLine.WhsCode != null && objLine.WhsCode != "") oDocSAP.Lines.WarehouseCode = objLine.WhsCode;
                    if (objLine.UnitPrice != 0) oDocSAP.Lines.UnitPrice = objLine.UnitPrice;
                    if (objLine.DiscPrcnt != 0) oDocSAP.Lines.DiscountPercent = objLine.DiscPrcnt;

                    if (objLine.Project != null && objLine.Project != "") oDocSAP.Lines.ProjectCode = objLine.Project;
                    if (objLine.OcrCode1 != null && objLine.OcrCode1 != "") oDocSAP.Lines.DistributionRule = objLine.OcrCode1;
                    if (objLine.OcrCode2 != null && objLine.OcrCode2 != "") oDocSAP.Lines.DistributionRule2 = objLine.OcrCode2;
                    if (objLine.OcrCode3 != null && objLine.OcrCode3 != "") oDocSAP.Lines.DistributionRule3 = objLine.OcrCode3;
                    if (objLine.OcrCode4 != null && objLine.OcrCode4 != "") oDocSAP.Lines.DistributionRule4 = objLine.OcrCode4;
                    if (objLine.OcrCode5 != null && objLine.OcrCode5 != "") oDocSAP.Lines.DistributionRule5 = objLine.OcrCode5;
                    if (objLine.BaseType != 0)
                    {
                        //oDocSAP.Lines.BaseType = objLine.BaseType;
                        oDocSAP.Lines.BaseEntry = objLine.BaseEntry;
                        oDocSAP.Lines.BaseLine = objLine.BaseLine;
                    }

                    #region Lotes
                    foreach (csDocumentLinesBatch objBatch in objLine.LinesBatch)
                    {
                        oDocSAP.Lines.BatchNumbers.BatchNumber = objBatch.BatchNumber;
                        oDocSAP.Lines.BatchNumbers.Quantity = objBatch.Quantity;
                        if (objBatch.MnfSerial != null && objBatch.MnfSerial != "") oDocSAP.Lines.BatchNumbers.ManufacturerSerialNumber = objBatch.MnfSerial;
                        if (objBatch.LotNumber != null && objBatch.LotNumber != "") oDocSAP.Lines.BatchNumbers.InternalSerialNumber = objBatch.LotNumber;
                        if (objBatch.InDate != null && objBatch.InDate != "") oDocSAP.Lines.BatchNumbers.AddmisionDate = GetFecha(objBatch.InDate);
                        if (objBatch.MnfDate != null && objBatch.MnfDate != "") oDocSAP.Lines.BatchNumbers.ManufacturingDate = GetFecha(objBatch.MnfDate);
                        if (objBatch.ExpDate != null && objBatch.ExpDate != "") oDocSAP.Lines.BatchNumbers.ExpiryDate = GetFecha(objBatch.ExpDate);

                        oDocSAP.Lines.BatchNumbers.Add();
                    }
                    #endregion

                   /* #region Ubicaciones
                    foreach (csDocumentLinesBinAllocations objBin in objLine.LinesBinAllocations)
                    {
                        oDocSAP.Lines.BinAllocations.Quantity = objBin.Quantity;
                        if (objBin.BinAbsEntry != 0) oDocSAP.Lines.BinAllocations.BinAbsEntry = objBin.BinAbsEntry;
                        oDocSAP.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = objBin.SerialAndBatchNumbersBaseLine;
                        oDocSAP.Lines.BinAllocations.BinActionType =
                                objBin.Direction == 1 ? BinActionTypeEnum.batToWarehouse : BinActionTypeEnum.batFromWarehouse;
                        oDocSAP.Lines.BinAllocations.Add();
                    }
                    #endregion*/

                    oDocSAP.Lines.Add();
                }

                iRet = oDocSAP.Add();

                if (iRet == 0)
                {
                    sDocEntry = oCompany.GetNewObjectKey();
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);
            }
        }
        public bool CloseMarketingDocument(string TipoDoc, int sDocEntry)
        {
            SAPbobsCOM.Documents oDocSAP = null;

            try
            {
                switch (TipoDoc)
                {
                    case "OC": //Orden de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseOrders);
                        break;
                    case "EC": //Entrada de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
                        break;
                    case "DC": //Devolucion de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseReturns);
                        break;
                    //******* VENTAS ********
                    case "OV": //Orden de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oOrders);
                        break;
                    case "EV": //Entrada de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oDeliveryNotes);
                        break;
                    case "DV": //Devolucion de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oReturns);
                        break;
                }

                if (oDocSAP.GetByKey(sDocEntry))
                {
                    oDocSAP.SpecifiedClosingDate = GetFecha("20241126");
                    oDocSAP.ClosingDate = GetFecha("20241126");

                    iRet = oDocSAP.Update();


                    iRet = oDocSAP.Close();

                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
                }
                else
                {
                    throw new Exception("Registro no encontrado en SAP");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);

            }
        }
        public bool CancelMarketingDocument(string TipoDoc, int sDocEntry, ref string sCancelDocEntry)
        {
            SAPbobsCOM.Documents oDocSAP = null;

            try
            {
                switch (TipoDoc)
                {
                    case "OC": //Orden de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseOrders);
                        break;
                    case "EC": //Entrada de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
                        break;
                    case "DC": //Devolucion de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseReturns);
                        break;
                    case "FC": //Factura de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseInvoices);
                        break;
                    case "NC": //Nota de Credito de Compra
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseCreditNotes);
                        break;
                    //******* VENTAS ********
                    case "OV": //Orden de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oOrders);
                        break;
                    case "EV": //Entrada de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oDeliveryNotes);
                        break;
                    case "DV": //Devolucion de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oReturns);
                        break;
                    case "FV": //Factura de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInvoices);
                        break;
                    case "NV": //Nota de Credito de Venta
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oCreditNotes);
                        break;
                    //******* INVENTARIOS ********
                    case "EI": //Entrada de Inventario
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                        break;
                    case "SI": //Salida de Inventario
                        oDocSAP = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                        break;
                }


                if (TipoDoc == "OC" || TipoDoc == "OV")
                {
                    if (oDocSAP.GetByKey(sDocEntry))
                    {
                        iRet = oDocSAP.Cancel();

                        if (iRet == 0)
                        {
                            sCancelDocEntry = sDocEntry.ToString();
                            return true;
                        }
                        else
                        {
                            oCompany.GetLastError(out iErrCod, out sErrMsg);
                            throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                        }
                    }
                    else
                    {
                        throw new Exception("Registro no encontrado en SAP");
                    }
                }
                else
                {
                    if (oDocSAP.GetByKey(sDocEntry))
                    {
                        SAPbobsCOM.Documents oCancelDoc = oCancelDoc = oDocSAP.CreateCancellationDocument();
                        oCancelDoc.DocDate = DateTime.Now;

                        iRet = oCancelDoc.Add();

                        Release(oCancelDoc);

                        if (iRet == 0)
                        {
                            sCancelDocEntry = oCompany.GetNewObjectKey();
                            return true;
                        }
                        else
                        {
                            oCompany.GetLastError(out iErrCod, out sErrMsg);
                            throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                        }
                    }
                    else
                    {
                        throw new Exception("Registro no encontrado en SAP");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);

            }
        }
        public bool AddPayments(csPayments objPay, ref string sDocEntry)
        {
            SAPbobsCOM.Payments oDocSAP = null;

            try
            {
                switch (objPay.TipoDoc)
                {
                    case "PR": //Pago Recibido
                        oDocSAP = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);
                        break;
                    case "PE": //Pago Efectuado
                        oDocSAP = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);
                        break;
                }

                if (objPay.DocDate != null && objPay.DocDate != "") oDocSAP.DocDate = GetFecha(objPay.DocDate);
                if (objPay.DocDueDate != null && objPay.DocDueDate != "") oDocSAP.DueDate = GetFecha(objPay.DocDueDate);
                if (objPay.TaxDate != null && objPay.TaxDate != "") oDocSAP.TaxDate = GetFecha(objPay.TaxDate);
                if (objPay.CardCode != null && objPay.CardCode != "") oDocSAP.CardCode = objPay.CardCode;
                if (objPay.CardName != null && objPay.CardName != "") oDocSAP.CardName = objPay.CardName;
                oDocSAP.DocType = objPay.DocType == "C" ? BoRcptTypes.rCustomer :
                                  objPay.DocType == "S" ? BoRcptTypes.rSupplier : BoRcptTypes.rAccount;
                if (objPay.CounterRef != null && objPay.CounterRef != "") oDocSAP.CounterReference = objPay.CounterRef;
                if (objPay.Comments != null && objPay.Comments != "") oDocSAP.Remarks = objPay.Comments;
                if (objPay.JrnlMemo != null && objPay.JrnlMemo != "") oDocSAP.JournalRemarks = objPay.JrnlMemo;
                if (objPay.DocCur != null && objPay.DocCur != "") oDocSAP.DocCurrency = objPay.DocCur;
                if (objPay.DocRate != 0) oDocSAP.DocRate = objPay.DocRate;
                if (objPay.CashAcct != null && objPay.CashAcct != "") oDocSAP.CashAccount = objPay.CashAcct;
                if (objPay.CashSum != 0) oDocSAP.CashSum = objPay.CashSum;
                if (objPay.TrsfAcct != null && objPay.TrsfAcct != "") oDocSAP.TransferAccount = objPay.TrsfAcct;
                if (objPay.TrfSum != 0) oDocSAP.TransferSum = objPay.TrfSum;
                if (objPay.TrsfDate != null && objPay.TrsfDate != "") oDocSAP.TransferDate = GetFecha(objPay.TrsfDate);
                if (objPay.TrsfRef != null && objPay.TrsfRef != "") oDocSAP.TransferReference = objPay.TrsfRef;
                if (objPay.DocCur != null && objPay.DocCur != "") oDocSAP.DocCurrency = objPay.DocCur;
                if (objPay.BPLId != 0) oDocSAP.BPLID = objPay.BPLId;

                foreach (csPaymentsCCard objCCard in objPay.ListCCard)
                {
                    if (objCCard.CreditCard != 0) oDocSAP.CreditCards.CreditCard = objCCard.CreditCard;
                    if (objCCard.CreditAcct != null && objCCard.CreditAcct != "") oDocSAP.CreditCards.CreditAcct = objCCard.CreditAcct;
                    if (objCCard.CrCardNum != null && objCCard.CrCardNum != "") oDocSAP.CreditCards.CreditCardNumber = objCCard.CrCardNum;
                    if (objCCard.CardValid != null && objCCard.CardValid != "") oDocSAP.CreditCards.CardValidUntil = GetFecha(objCCard.CardValid);
                    if (objCCard.VoucherNum != null && objCCard.VoucherNum != "") oDocSAP.CreditCards.VoucherNum = objCCard.VoucherNum;
                    if (objCCard.OwnerIdNum != null && objCCard.OwnerIdNum != "") oDocSAP.CreditCards.OwnerIdNum = objCCard.OwnerIdNum;
                    if (objCCard.OwnerPhone != null && objCCard.OwnerPhone != "") oDocSAP.CreditCards.OwnerPhone = objCCard.OwnerPhone;
                    if (objCCard.NumOfPmnts != 0) oDocSAP.CreditCards.NumOfCreditPayments = objCCard.NumOfPmnts;
                    if (objCCard.CreditSum != 0) oDocSAP.CreditCards.CreditSum = objCCard.CreditSum;
                    if (objCCard.CreditType != null && objCCard.CreditType != "")
                    {
                        oDocSAP.CreditCards.CreditType = objCCard.CreditType == "U" ? BoRcptCredTypes.cr_Telephone :
                                                         objCCard.CreditType == "S" ? BoRcptCredTypes.cr_Regular : BoRcptCredTypes.cr_InternetTransaction;
                    }
                    if (objCCard.FirstPaymentDue != null && objCCard.FirstPaymentDue != "") oDocSAP.CreditCards.FirstPaymentDue = GetFecha(objCCard.FirstPaymentDue);
                    oDocSAP.CreditCards.Add();
                }

                foreach (csPaymentsDet objDet in objPay.ListDets)
                {
                    if (objDet.SumApplied != 0) oDocSAP.Invoices.SumApplied = objDet.SumApplied;
                    if (objDet.OcrCode != null && objDet.OcrCode != "") oDocSAP.Invoices.DistributionRule = objDet.OcrCode;
                    if (objDet.OcrCode2 != null && objDet.OcrCode2 != "") oDocSAP.Invoices.DistributionRule2 = objDet.OcrCode2;
                    if (objDet.OcrCode3 != null && objDet.OcrCode3 != "") oDocSAP.Invoices.DistributionRule3 = objDet.OcrCode3;
                    if (objDet.OcrCode4 != null && objDet.OcrCode4 != "") oDocSAP.Invoices.DistributionRule4 = objDet.OcrCode4;
                    if (objDet.OcrCode5 != null && objDet.OcrCode5 != "") oDocSAP.Invoices.DistributionRule5 = objDet.OcrCode5;
                    if (objDet.InvoiceId != 0) oDocSAP.Invoices.DocEntry = objDet.InvoiceId;
                    if (objDet.InvType != null && objDet.InvType != "")
                    {
                        switch (objDet.InvType)
                        {
                            case "30":
                                oDocSAP.Invoices.InvoiceType = BoRcptInvTypes.it_JournalEntry;
                                break;
                            case "13":
                                oDocSAP.Invoices.InvoiceType = BoRcptInvTypes.it_Invoice;
                                break;
                            case "14":
                                oDocSAP.Invoices.InvoiceType = BoRcptInvTypes.it_CredItnote;
                                break;
                            case "18":
                                oDocSAP.Invoices.InvoiceType = BoRcptInvTypes.it_PurchaseInvoice;
                                break;
                            case "19":
                                oDocSAP.Invoices.InvoiceType = BoRcptInvTypes.it_PurchaseCreditNote;
                                break;
                        }
                    }
                    oDocSAP.Invoices.Add();
                }

                foreach (csPaymentsChecks objChecks in objPay.LisChecks)
                {
                    if (objChecks.DueDate != null && objChecks.DueDate != "") oDocSAP.Checks.DueDate = GetFecha(objChecks.DueDate);
                    if (objChecks.CheckSum != 0) oDocSAP.Checks.CheckSum = objChecks.CheckSum;
                    if (objChecks.CheckNum != 0) oDocSAP.Checks.CheckNumber = objChecks.CheckNum;
                    if (objChecks.BankCode != null && objChecks.BankCode != "") oDocSAP.Checks.BankCode = objChecks.BankCode;
                    if (objChecks.AcctNum != null && objChecks.AcctNum != "") oDocSAP.Checks.AccounttNum = objChecks.AcctNum;
                    if (objChecks.CheckAcct != null && objChecks.CheckAcct != "") oDocSAP.Checks.CheckAccount = objChecks.CheckAcct;
                    if (objChecks.Trnsfrable != null && objChecks.Trnsfrable != "") oDocSAP.Checks.Trnsfrable = objChecks.Trnsfrable == "Y" ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                    if (objChecks.CountryCod != null && objChecks.CountryCod != "") oDocSAP.Checks.CountryCode = objChecks.CountryCod;
                    oDocSAP.Checks.Add();
                }


                iRet = oDocSAP.Add();

                if (iRet == 0)
                {
                    sDocEntry = oCompany.GetNewObjectKey();
                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);
            }
        }
        public bool CancelPayments(string TipoDoc, int sDocEntry)
        {
            SAPbobsCOM.Payments oDocSAP = null;

            try
            {
                switch (TipoDoc)
                {
                    case "PR": //Pago Recibido
                        oDocSAP = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);
                        break;
                    case "PE": //Pago Efectuado
                        oDocSAP = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);
                        break;
                }

                if (oDocSAP.GetByKey(sDocEntry))
                {
                    iRet = oDocSAP.Cancel();

                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
                }
                else
                {
                    throw new Exception("Registro no existe en SAP");
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Release(oDocSAP);
            }
        }
        public void ExecuteRecordSet(string Query)
        {
            try
            {
                oRec = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                oRec.DoQuery(Query);

                //while (!oRec.EoF)
                //{
                //    //Obtienes la información
                //    //string aa = oRec.Fields.Item("CAMPO").Value.ToString();
                //    oRec.MoveNext();
                //}

                //string xml = oRec.GetAsXML();

                //XDocument XDoc = XDocument.Parse(xml);
                //ordenesPendientes = (from q in XDoc.Descendants("row")
                //                     select Convert.ToInt32(q.Element("DocEntry").Value));



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime GetFecha(string sFecha)
        {
            return DateTime.Parse(sFecha.Substring(6, 2) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(0, 4)); // Convertir fecha // fecha en formato AAAAMMDD
        }
    }
}