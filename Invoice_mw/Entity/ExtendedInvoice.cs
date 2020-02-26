using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.Entity
{
    public class ExtendedInvoice : SQLtoLINQ.Invoice
    {
        /* public int id;
         public String fa_number;
         public String payment_methode; */
        public DateTime issue_date, due_date;
        public ExtendedSubject subject_from, subject_for;
        public ArrayList items;

        public ExtendedInvoice(int id, string fa_number, DateTime issue_date, DateTime due_date, string payment_methode, ExtendedSubject subject_from, ExtendedSubject subject_for, ArrayList items)
        {   
            this.Id = id;
            this.FA_Number = fa_number;
            this.issue_date = issue_date;
            this.due_date = due_date;
            this.Payment_Method = payment_methode;
            this.subject_from = subject_from;
            this.subject_for = subject_for;
            this.items = items;
        }
        public ExtendedInvoice()
        {
           // this.id = -1;
            this.FA_Number = "-1";
            this.issue_date = new DateTime(0);
            this.due_date = new DateTime(0);
            this.Payment_Method = "-1";
            this.subject_from = null;
            this.subject_for = null;
            this.items = new ArrayList();
        }
        public override string ToString()
        {
            return "Invoice: " + FA_Number +
                " Issue Date: " + Issue_Date +
                " Due Date: " + Due_Date +
                " Payment metode: " + Payment_Method;
        }
    }
}
