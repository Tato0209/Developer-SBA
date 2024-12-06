using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csPayments
    {
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string TaxDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocType { get; set; }
        public string CounterRef { get; set; }
        public string Comments { get; set; }
        public string JrnlMemo { get; set; }
        public string DocCur { get; set; }
        public double DocRate { get; set; }
        public string CashAcct { get; set; }
        public double CashSum { get; set; }
        public string TrsfAcct { get; set; }
        public double TrfSum { get; set; }
        public string TrsfDate { get; set; }
        public string TrsfRef { get; set; }
        public int BPLId { get; set; }
        public string TipoDoc { get; set; } //Campo no SAP

        public List<csPaymentsDet> ListDets = new List<csPaymentsDet>();
        public List<csPaymentsChecks> LisChecks = new List<csPaymentsChecks>();
        public List<csPaymentsCCard> ListCCard = new List<csPaymentsCCard>();
    }

    public class csPaymentsCCard
    {
        public int CreditCard { get; set; }
        public string CreditAcct { get; set; }
        public string CrCardNum { get; set; }
        public string CardValid { get; set; }
        public string VoucherNum { get; set; }
        public string OwnerIdNum { get; set; }
        public string OwnerPhone { get; set; }
        public int CrTypeCode { get; set; }
        public int NumOfPmnts { get; set; }
        public double CreditSum { get; set; }
        public string CreditType { get; set; }
        public string FirstPaymentDue { get; set; }
    }

    public class csPaymentsChecks
    {
        public string DueDate { get; set; }
        public double CheckSum { get; set; }
        public double CheckSumFC { get; set; }
        public int CheckNum { get; set; }
        public string BankCode { get; set; }
        public string AcctNum { get; set; }
        public string Currency { get; set; }
        public string CheckAcct { get; set; }
        public string Trnsfrable { get; set; }
        public string CountryCod { get; set; }
    }

    public class csPaymentsDet
    {
        public double SumApplied { get; set; }
        public int InvoiceId { get; set; }
        public string InvType { get; set; }
        public string OcrCode { get; set; }
        public string OcrCode2 { get; set; }
        public string OcrCode3 { get; set; }
        public string OcrCode4 { get; set; }
        public string OcrCode5 { get; set; }
    }
}
