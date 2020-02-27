using Invoice_mw.Entity;
using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBGetInvoice : DBConn
    {
  
        public Entity.ExtendedInvoice GetInvoice(int id)
        {
                Entity.ExtendedSubject[] subjects = GetSubjects(id);
                

            var invoice = from inv in dbContext.Invoice
                          where inv.Id == id
                          select new
                          {
                              inv.Id,
                              inv.Issue_Date,
                              inv.Due_Date,
                              inv.FA_Number,
                              inv.Payment_Method
                          };

     

                return  new Entity.ExtendedInvoice(id,
                    invoice.First().FA_Number,
                    (DateTime)invoice.First().Issue_Date,
                    (DateTime)invoice.First().Due_Date,
                    invoice.First().Payment_Method,
                    subjects[0],
                    subjects[1],
                    GetItemList(id));
        }

        private Entity.ExtendedSubject[] GetSubjects(int id)
        {
            var ids = (from i1 in dbContext.Invoice
                       where i1.Id == id
                      select new
                      {
                          i1.Subject_For_Id,
                          i1.Subject_From_Id
                      }) ;

            var subjectFrom = from s1 in dbContext.Subject
                              where s1.Id == ids.First().Subject_From_Id
                              select new
                              {
                                  s1.Id,
                                  s1.Name,
                                  s1.Address,
                                  s1.NIP,
                                  s1.Bank,
                                  s1.Bank_Account
                              };
            var subjectFor = from s2 in dbContext.Subject
                              where s2.Id == ids.First().Subject_For_Id
                              select new
                              {
                                  s2.Id,
                                  s2.Name,
                                  s2.Address,
                                  s2.NIP,
                                  s2.Bank,
                                  s2.Bank_Account
                              };
            Entity.ExtendedSubject[] subjects = new Entity.ExtendedSubject[2];

            subjects[0] = new Entity.ExtendedSubject(
                subjectFrom.First().Id,
                subjectFrom.First().Name,
                subjectFrom.First().Address,
                subjectFrom.First().NIP,
                subjectFrom.First().Bank,
                subjectFrom.First().Bank_Account);

            subjects[1] = new Entity.ExtendedSubject(
                subjectFor.First().Id,
                subjectFor.First().Name,
                subjectFor.First().Address,
                subjectFor.First().NIP,
                subjectFor.First().Bank,
                subjectFor.First().Bank_Account);



          

            return subjects;
        }

        public  ArrayList GetItemList(int id)
        {
            ArrayList items = new ArrayList();
            var items_in_invoice = from i in dbContext.Item_in_invoice join it in dbContext.Item on i.Item_Id equals it.Id
                                   where i.Invoice_Id == id
                                   select new {
                                       it.Name,
                                       it.Item_Type,
                                       it.VAT,
                                       it.Price_Netto,
                                       i.Amount   
                                    };
            foreach(var item in items_in_invoice)
            {
                items.Add(new Entity.ExtendedItem(
                    item.Name,
                    item.Item_Type,
                    (int)item.VAT,
                    (double)item.Price_Netto,
                    (int)item.Amount
                    ));
            }




            return items;

        }

        public int GetItemInInvoicedId(int id, string selectedItem)
        {
            var toReturn = from i in dbContext.Item_in_invoice
                           join it in dbContext.Item on i.Item_Id equals it.Id
                           where i.Invoice_Id == id || it.Name == selectedItem
                           select new
                           {
                               i.Id
                           };
            return toReturn.First().Id;
        }


        
    }
}
