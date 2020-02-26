using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBGetItems : DBConn
    {


        public List<Entity.ExtendedItem> GetItems()
        {
            List<Entity.ExtendedItem> list = new List<Entity.ExtendedItem>();
            var items = from it in dbContext.Item
                           select new
                           {
                               it.Id,
                               it.Item_Type,
                               it.Name,
                               it.VAT,
                               it.Price_Netto

                           };

            foreach (var it in items)
                list.Add(new Entity.ExtendedItem(
                    it.Name,
                    it.Item_Type,
                    (int)it.VAT,
                    (double)it.Price_Netto,
                    0));

            return list;
        }

        public List<String> GetItemsNames()
        {
            List<Entity.ExtendedItem> subject_list = GetItems();
            List<String> names_list = new List<string>();

            foreach (Entity.ExtendedItem i in subject_list)
                names_list.Add(i.name);

            return names_list;
        }


    }
}
