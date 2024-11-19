using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csDocuments
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string TaxDate { get; set; }
        public string NumAtCard { get; set; }
        public int GroupNum { get; set; }
        public int SlpCode { get; set; }
        public string Comments { get; set; }
        public string Indicator { get; set; }
        public string DocType { get; set; }
        public string DocCurr { get; set; }
        public int BPLid { get; set; }
        public string U_U_C2410_P001 { get; set; }
        public string U_U_C2410_P002 { get; set; }

        public List<csDocumentLines> Lines = new List<csDocumentLines>();
       
        
    }
    public class csDocumentLines
    {
        public string ItemCode { get; set; }
        public string Dscrption { get; set; }
        public string AcctCode { get; set; }
        public double Quantity { get; set; }
        public string WhsCode { get; set; }
        public double UnitPrice { get; set; }
        public double DiscPrcnt { get; set; }
        public string Project { get; set; }
        public string OcrCode1 { get; set; }
        public string OcrCode2 { get; set; }
        public string OcrCode3 { get; set; }
        public string OcrCode4 { get; set; }
        public string OcrCode5 { get; set; }
        public int BaseType { get; set; }
        public int BaseEntry { get; set; }
        public int BaseLine { get; set; }

         public List<csDocumentLinesBatch> LinesBatch = new List<csDocumentLinesBatch>();
        public List<csDocumentLinesBinAllocations> LinesBinAllocations = new List<csDocumentLinesBinAllocations>();
    }

    public class csDocumentLinesBatch
    {
        public string BatchNumber { get; set; }
        public double Quantity { get; set; }
        public string MnfSerial { get; set; }
        public string LotNumber { get; set; }
        public string InDate { get; set; }
        public string MnfDate { get; set; }
        public string ExpDate { get; set; }
    }

    public class csDocumentLinesBinAllocations
    {
        public int BinAbsEntry { get; set; }
        public double Quantity { get; set; }
        public int SerialAndBatchNumbersBaseLine { get; set; }

    }
}
