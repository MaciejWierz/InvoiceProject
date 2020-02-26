using Invoice_mw.Entity;
using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBUpdateInvoice : DBConn
    {


        public void UpdateInvoice(Entity.ExtendedInvoice invoice)
        {
            // dbContext.Invoice.InsertOnSubmit();

            var invoiceToUpdate = dbContext.Invoice.SingleOrDefault(x => x.Id == invoice.Id);
            invoiceToUpdate.FA_Number = invoice.FA_Number;
            invoiceToUpdate.Issue_Date = invoice.issue_date;
            invoiceToUpdate.Due_Date = invoice.due_date;
            invoiceToUpdate.Payment_Method = invoice.Payment_Method;
            invoiceToUpdate.Subject_For_Id = invoice.subject_for.Id;
            invoiceToUpdate.Subject_From_Id = invoice.subject_from.Id;


            
            dbContext.SubmitChanges();
            



           // dbContext.SubmitChanges();
        }

        internal void UpdateItemList(ExtendedInvoice invoice, ExtendedItem item)
        {
            int itemId = GetItemId(item);
            int freeID = GetFreeItemInInvoiceId();
            SQLtoLINQ.Item_in_invoice iii = new SQLtoLINQ.Item_in_invoice();
            iii.Id = freeID;
            iii.Invoice_Id = invoice.Id;
            iii.Item_Id = itemId;
            iii.Amount = item.amount;
            dbContext.Item_in_invoice.InsertOnSubmit(iii);
            dbContext.SubmitChanges();
        }

        public int GetFreeItemInInvoiceId()
        {
           var item_in_invoice_list = from iii in dbContext.Item_in_invoice
                                      select new {
                                                    iii.Id
                                                 };

            int? toReturn = null;

            foreach(var number in item_in_invoice_list)
            {
                var difference = number.Id - toReturn;

                if (difference != null && difference > 1)
                {
                    return (int)toReturn + 1;
                }

                toReturn = number.Id;
            }


            return  (int)toReturn + 1;
        }

        public int GetItemId(Entity.ExtendedItem item)
        {

            var itemId = from it in dbContext.Item
                         where it.Name == item.name
                         select new
                         {
                             it.Id
                         };

            return itemId.First().Id;
        }

        internal void UpdateItemAmount(Entity.ExtendedInvoice invoice, String selectedItem, int amount)
        {
            DBGetInvoice db = new DBGetInvoice();
            String item_name = selectedItem.Split('|')[0];
            int item_in_invoice_id = db.GetItemInInvoicedId(invoice.Id, item_name);

            
            var item_in_invoice_update = dbContext.Item_in_invoice.SingleOrDefault(x => x.Id == item_in_invoice_id);
            item_in_invoice_update.Amount = amount;

            dbContext.SubmitChanges();
          

            invoice.items = db.GetItemList(invoice.Id);
        }


    }
}
