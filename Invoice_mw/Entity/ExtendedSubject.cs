using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.Entity
{
    public class ExtendedSubject : SQLtoLINQ.Subject
    {
      /*  public int id;
       public String name;
        public String address;
        public String nip;
        public String bank;
        public String bank_account;*/

        public ArrayList items;

        public ExtendedSubject(int id, string name, string address, string nip, string bank, string bank_account)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.NIP = nip;
            this.Bank = bank;
            this.Bank_Account = bank_account;
            items = new ArrayList();
        }

        public void AddItem(ExtendedItem item)
        {
            items.Add(item);
        }

        public ArrayList GetItems()
        {
            return items;
        }

    }
}
