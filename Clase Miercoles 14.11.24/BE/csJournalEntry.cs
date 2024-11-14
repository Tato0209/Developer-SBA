using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csJournalEntry
    {
        public string RefDate { get; set; }
        public string DueDate { get; set; }
        public string TaxDate { get; set; }
        public string Memo { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Indicator { get; set; }
        public string Project { get; set; }
        public string TransCode { get; set; }

        public List<csJournalEntryLines>Lines = new List<csJournalEntryLines>();
    }
    public class csJournalEntryLines
    {
        public string Account { get; set; }
        public string ShortName { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double FCDebit { get; set; }
        public double FCCredit { get; set; }
        public string Project { get; set; }
        public string LineMemo { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string OcrCode1 { get; set; }
        public string OcrCode2 { get; set; }
        public string OcrCode3 { get; set; }
        public string OcrCode4 { get; set; }
        public string OcrCode5 { get; set; }
        public string FCCurrency { get; set; }
        public int BPLId { get; set; }
    }
}
