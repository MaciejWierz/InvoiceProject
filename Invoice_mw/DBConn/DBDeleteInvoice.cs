using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBDeleteInvoice : DBConn
    {


        public void DeleteItemInInvoice(Entity.ExtendedInvoice invoice, String name)
        {
            DBGetInvoice db = new DBGetInvoice();
         
            int item_in_invoice_id = db.GetItemInInvoicedId(invoice.Id, name);

            Debug.WriteLine(item_in_invoice_id);
            var item_in_invoice_delete = dbContext.Item_in_invoice.SingleOrDefault(x => x.Id == item_in_invoice_id);

            dbContext.Item_in_invoice.DeleteOnSubmit(item_in_invoice_delete);

            dbContext.SubmitChanges();


            invoice.items = db.GetItemList(invoice.Id);
        }


        public void DeleteInvoice(Entity.ExtendedInvoice invoice)
        {
            var invoice_to_delete = dbContext.Invoice.Single(x => x.Id == invoice.Id);


            dbContext.Invoice.DeleteOnSubmit(invoice_to_delete);
            dbContext.SubmitChanges();

        }

        
    }
}
