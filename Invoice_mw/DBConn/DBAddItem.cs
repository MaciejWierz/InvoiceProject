using Invoice_mw.Entity;
using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBAddItem : DBConn
    {



        internal void AddItem(Entity.ExtendedItem item)
        {
            
            SQLtoLINQ.Item toInsert = new SQLtoLINQ.Item();
            toInsert.Id = GetFreeItemId();
            toInsert.Name = item.name;
            toInsert.Item_Type = item.item_type;
            toInsert.VAT = item.vat;
            toInsert.Price_Netto = (decimal?)item.price_netto;

            dbContext.Item.InsertOnSubmit(toInsert);
            dbContext.SubmitChanges();
        }

        public int GetFreeItemId()
        {
            var item_list = from i in dbContext.Item
                               select new
                               {
                                   i.Id
                               };

            int? toReturn = null;

            foreach (var number in item_list)
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
