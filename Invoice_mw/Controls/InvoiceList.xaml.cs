using Invoice_mw.DBConn;
using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Logika interakcji dla klasy InvoiceList.xaml
    /// </summary>
    public partial class InvoiceList : UserControl
    {
        InvoiceLinqDataContext dbContext;
        MainWindow owner;
        public InvoiceList(MainWindow owner)
        {
            this.owner = owner;
            InitializeComponent();
            dbContext = new InvoiceLinqDataContext(Properties.Settings.Default.mw_invoce_dbConnectionString);
            if (dbContext.DatabaseExists())
                SetGridViewDataSource();
        }

        private void Invoice_grid_view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (invoice_grid_view.SelectedItem != null)   
                owner.ChangePanelShowInvoice(invoice_grid_view.SelectedItem.ToString());

        }

        private void Invoice_grid_view_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Id")) e.Column.Header = "Lp.";
            else if (e.PropertyName.Equals("Issue_Date")) e.Column.Header = "Data wydania";
            else if (e.PropertyName.Equals("Due_Date")) e.Column.Header = "Data realizacji";
            else if (e.PropertyName.Equals("FA_Number")) e.Column.Header = "Nr faktury";
            else if (e.PropertyName.Equals("Subject_For")) e.Column.Header = "Nabywca";
            else if (e.PropertyName.Equals("Subject_From")) e.Column.Header = "Sprzedawca";
            else if (e.PropertyName.Equals("Payment_Method")) e.Column.Header = "Sposób płatności";



        }


        private void SetGridViewDataSource()
        {
            var dataSource = (from i1 in dbContext.Invoice
                              join s1 in dbContext.Subject on i1.Subject_For_Id equals s1.Id
                              select new
                              {
                                  i1.Id,
                                  i1.FA_Number,
                                  s1.Name,
                                  i1.Issue_Date,
                                  i1.Due_Date,
                                  i1.Payment_Method
                              });

            var updatedDataSource = dataSource.Select(x =>
                       new
                       {
                           Id = x.Id,
                           Fa_Number = x.FA_Number,
                           Subject_For = x.Name,

                           Subject_From = (from i1 in dbContext.Invoice
                                    join s1 in dbContext.Subject on i1.Subject_From_Id equals s1.Id
                                    where i1.Id == x.Id
                                    select new
                                    {
                                        s1.Name
                                    }).First().Name,

                          Issue_Date = ((DateTime)x.Issue_Date).ToShortDateString(),
                           Due_Date = ((DateTime)x.Due_Date).ToShortDateString(),
                           Payment_Method = x.Payment_Method
                       });

            invoice_grid_view.ItemsSource = updatedDataSource;
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelAddInvoice();
        }

        private void ToSubjects_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelAddSubject();
        }

        private void DeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (invoice_grid_view.SelectedItem != null)
            {
                DBDeleteInvoice db_delete = new DBDeleteInvoice();
                DBGetInvoice db_get = new DBGetInvoice();
                Entity.ExtendedInvoice invoice = db_get.GetInvoice(Int16.Parse(GetInvoiceId(invoice_grid_view.SelectedItem.ToString())));
                db_delete.DeleteInvoice(invoice);
                SetGridViewDataSource();
            }
           

        }
        

        private void ToItems_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelItems();
        }

        private string GetInvoiceId(string invoice)
        {
            invoice = invoice.Split(',').First().Split('=').Last();
            return invoice;
        }
    }
}
