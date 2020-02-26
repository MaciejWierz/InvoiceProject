using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.Entity
{
    public class ExtendedItem
    {
        public String name;
        public String item_type;
        public int vat;
        public double price_netto, value_brutto, value_netto;
        public int amount;

        public ExtendedItem(string name, string item_type, int vat, double price_netto, int amount)
        {
            this.name = name;
            this.item_type = item_type;
            this.vat = vat;
            this.price_netto = price_netto ;
            this.value_netto = price_netto * amount;
            this.value_brutto = (value_netto * vat / 100) + value_netto;
            this.amount = amount;
        }

        public override string ToString()
        {
            return "Item: " + name +
                " Type: " +  item_type +
                " Vat: " + vat +
                " Price: " + price_netto +
                " Amount: " + amount ;
        }

        public void UpdateValues()
        {
            this.value_netto = price_netto * amount;
            this.value_brutto = (value_netto * vat / 100) + value_netto;
        }
    }
}
