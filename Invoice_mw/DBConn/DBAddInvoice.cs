using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBAddInvoice : DBConn
    {



        public void AddInvoice(Entity.ExtendedInvoice invoice)
        {
            invoice.Id = GetFreeInvoiceId();
            Invoice inv = new Invoice();

            inv.Id = invoice.Id;
            inv.FA_Number = invoice.FA_Number;
            inv.Issue_Date = invoice.issue_date;
            inv.Due_Date = invoice.due_date;
            inv.Payment_Method = invoice.Payment_Method;
            inv.Subject_For_Id = invoice.subject_for.Id;
            inv.Subject_From_Id = invoice.subject_from.Id;

            
           
            dbContext.Invoice.InsertOnSubmit(inv);
            dbContext.SubmitChanges();

            InsertItemInInvoice(invoice);

        }

        public void InsertItemInInvoice(Entity.ExtendedInvoice invoice)
        {
            DBUpdateInvoice db = new DBUpdateInvoice();
           
            foreach(Entity.ExtendedItem i in invoice.items)
            {
                Item_in_invoice it = new Item_in_invoice();
                it.Id = db.GetFreeItemInInvoiceId();
                it.Item_Id = db.GetItemId(i);
                it.Invoice_Id = invoice.Id;
                it.Amount = i.amount;
                dbContext.Item_in_invoice.InsertOnSubmit(it);
                dbContext.SubmitChanges();
            }
        }


        public int GetFreeInvoiceId()
        {
            var invoice_list = from i in dbContext.Invoice
                                       select new
                                       {
                                           i.Id
                                       };

            int? toReturn = null;

            foreach (var number in invoice_list)
            {
                var difference = number.Id - toReturn;
               
                if (difference != null && difference > 1)
                {
                    return (int)toReturn + 1;
                }
                toReturn = number.Id;
            }


            return (int)toReturn + 1;
        }
    }
}
