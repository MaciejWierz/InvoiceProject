using Invoice_mw.DBConn;
using Invoice_mw.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Logika interakcji dla klasy AddInvoice.xaml
    /// </summary>
    public partial class AddInvoice : UserControl
    {
        public ExtendedInvoice invoice;
        MainWindow owner;
        public AddInvoice(MainWindow owner)
        {
            invoice = new ExtendedInvoice();
            this.owner = owner;
            InitializeComponent();
            SetComboboxes();
            SetDataGrid();
            
        }

      

        private void SetComboboxes()
        {
            DBGetSubjects db_subject = new DBGetSubjects();
            SubjectForComboBox.ItemsSource = db_subject.GetSubjectNames();
            SubjectFromComboBox.ItemsSource = db_subject.GetSubjectNames();

      

            DBGetItems db_items = new DBGetItems();
            Items.ItemsSource = db_items.GetItemsNames();
            Items.SelectedIndex = 0;

        }

        private void SetDataGrid()
        {
            var items = from it in invoice.items.Cast<Entity.ExtendedItem>().ToList()
                        select new
                        {
                            it.name,
                            it.item_type,
                            it.amount,
                            it.vat,
                            it.price_netto,
                            it.value_netto,
                            it.value_brutto
                        };
            if (items.Count() > 0)
            {
                items_grid_view.Visibility = Visibility.Visible;
                items_grid_view.ItemsSource = items;
            }else
            {
                items_grid_view.Visibility = Visibility.Hidden;
            }
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

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Int32.Parse(AmountUpdate.Text) > 0)
                {
                    DBGetItems db = new DBGetItems();
                    List<Entity.ExtendedItem> item_list = db.GetItems();

                    foreach (ExtendedItem i in item_list)   
                        if (i.name.Equals(Items.SelectedItem.ToString()))
                        {
                            i.amount = Int32.Parse(AmountUpdate.Text);
                            i.UpdateValues();
                            invoice.items.Add(i);
                        }
                    
                    SetDataGrid();
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void CancelItemBtn_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelInvoiceList();
        }

        private void CreateInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!FA_number.Text.Equals("")
                    && !Issue_date.Text.Equals("")
                    && !Due_date.Text.Equals("")
                    && !Payment_methode.Text.Equals("")
                    && !SubjectForComboBox.SelectedItem.ToString().Equals(""))
                {


                    DBGetSubjects db_subject = new DBGetSubjects();
                    invoice.subject_for = db_subject.GetSubjectByName(SubjectForComboBox.SelectedItem.ToString());
                    invoice.subject_from = db_subject.GetSubjectByName(SubjectFromComboBox.SelectedItem.ToString());
                    invoice.issue_date = Convert.ToDateTime((Issue_date.Text.Split('.')[0] + "/" + Issue_date.Text.Split('.')[1] + "/" + Issue_date.Text.Split('.')[2]));
                    invoice.due_date = Convert.ToDateTime((Due_date.Text.Split('.')[0] + "/" + Due_date.Text.Split('.')[1] + "/" + Due_date.Text.Split('.')[2]));
                    invoice.FA_Number = FA_number.Text;
                    invoice.Payment_Method = Payment_methode.Text;

               

                    DBAddInvoice db = new DBAddInvoice();
                    db.AddInvoice(invoice);

                    owner.ChangePanelInvoiceList();
                }
                else MessageBox.Show("Wypełnij wszystkie pola", "Błąd");
            }
            catch(Exception ex){
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Błędnie wprowadzone dane", "Błąd");
            }
        }

    
    }
}
