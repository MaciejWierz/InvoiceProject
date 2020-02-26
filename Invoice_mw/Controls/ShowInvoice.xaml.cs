using Invoice_mw.DBConn;
using Invoice_mw.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invoice_mw.Controls
{
    public partial class ShowInvoice : UserControl
    {
        ExtendedInvoice invoiceInstance;
        MainWindow owner;
        
        

        public ShowInvoice(String invoice, MainWindow owner)
        {
            this.owner = owner;

            InitializeComponent();

            DBGetInvoice db = new DBGetInvoice();
            invoiceInstance = db.GetInvoice(Int16.Parse(GetInvoiceId(invoice)));

            SetInvoiceInfo();
            SetSubjects();
            SetItems();
            
        }

        public ShowInvoice(ExtendedInvoice invoice, MainWindow owner)
        {
            this.invoiceInstance = invoice;
            this.owner = owner;
            InitializeComponent();
            SetInvoiceInfo();
            SetSubjects();
            SetItems();
        }

        private void SetInvoiceInfo()
        {
            invoiceInfo.Text = "Nr. " + invoiceInstance.FA_Number + "\n" +
                               "Data wystawienia: " + invoiceInstance.issue_date.ToShortDateString() + "\n" +
                               "Data wykonania / dostawy: " + invoiceInstance.due_date.ToShortDateString() + "\n" +
                               "Sposób płatności: " + invoiceInstance.Payment_Method;
        }

        private void SetSubjects()
        {
            subjectFrom.Text = "Sprzedawca \n" +
                 invoiceInstance.subject_from.Name + "  NIP: " +
                 invoiceInstance.subject_from.NIP + "\n" +
                 invoiceInstance.subject_from.Address + "\n" +
                 "Bank: " + invoiceInstance.subject_from.Bank + " Numer rachunku: " + invoiceInstance.subject_from.Bank_Account;

            subjectFor.Text = "Nabywca \n" +
                 invoiceInstance.subject_for.Name + "  NIP: " +
                 invoiceInstance.subject_for.NIP + "\n" +
                 invoiceInstance.subject_for.Address + "\n" +
                 "Bank: " + invoiceInstance.subject_for.Bank + " Numer rachunku: " + invoiceInstance.subject_for.Bank_Account;
        }

        private void SetItems()
        {
             var items = from it in invoiceInstance.items.Cast<Entity.ExtendedItem>().ToList()
                   select new {
                          it.name,
                          it.item_type,
                          it.amount,
                          it.vat,
                          it.price_netto,
                          it.value_netto,
                          it.value_brutto
                        };

            items_grid_view.ItemsSource = items;
            double sum_price_netto = 0;
            double sum_price_brutto = 0;
            foreach (ExtendedItem it in invoiceInstance.items)
            {
                sum_price_netto += it.value_netto;
                sum_price_brutto += it.value_brutto;
            }
            sum.Text = "Razem:   Wartość Netto: " + sum_price_netto + "   Wartość Brutto: " + sum_price_brutto;  
        }
        private string GetInvoiceId(string invoice)
        {
            invoice = invoice.Split(',').First().Split('=').Last();
            return invoice;
        }

        private void Items_grid_view_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("name")) e.Column.Header = "Nazwa";
            else if (e.PropertyName.Equals("item_type")) e.Column.Header = "Rodzaj";
            else if (e.PropertyName.Equals("amount")) e.Column.Header = "Ilość";
            else if (e.PropertyName.Equals("price_netto")) e.Column.Header = "Cena netto";
            else if (e.PropertyName.Equals("value_netto")) e.Column.Header = "Wartość netto";
            else if (e.PropertyName.Equals("vat")) e.Column.Header = "Stawka VAT";
            else if (e.PropertyName.Equals("value_brutto")) e.Column.Header = "Wartość brutto";
           
        }

        private void ToInvoiceList_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelInvoiceList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelEditInvoice(invoiceInstance);
        }
    }
}
