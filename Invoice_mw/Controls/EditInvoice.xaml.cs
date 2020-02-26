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
using Invoice_mw.DBConn;
using Invoice_mw.Entity;

namespace Invoice_mw.Controls
{

    public partial class EditInvoice : UserControl
    {
        public ExtendedInvoice invoice;
        MainWindow owner;

        public EditInvoice(ExtendedInvoice invoice, MainWindow owner)
        {
            InitializeComponent();
            this.invoice = invoice;
            this.owner = owner;

            SetDefaultTextBoxValues();
            SetComboboxes();

            
        }

        private void SetComboboxes()
        {
            DBGetSubjects db_subject = new DBGetSubjects();
            SubjectForComboBox.ItemsSource = db_subject.GetSubjectNames();
            SubjectFromComboBox.ItemsSource = db_subject.GetSubjectNames();

            SubjectForComboBox.SelectedItem = invoice.subject_for.Name;
            SubjectFromComboBox.SelectedItem = invoice.subject_from.Name;

            DBGetItems db_items = new DBGetItems();
            AvaiableItems.ItemsSource = db_items.GetItemsNames();
            AvaiableItems.SelectedIndex = 0;


             SetComboboxItem();
            
        }

        private void SetComboboxItem()
        { 
            List<String> list = new List<String>();
            foreach (ExtendedItem i in invoice.items)
                list.Add(i.name + "|" + i.amount);
            Items.ItemsSource = list;
            Items.SelectedIndex = 0;
        }

        private void SetDefaultTextBoxValues()
        {
            FA_number.Text = invoice.FA_Number;
            Issue_date.Text = invoice.issue_date.ToShortDateString();
            Due_date.Text = invoice.due_date.ToShortDateString();
            Payment_methode.Text = invoice.Payment_Method;
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.owner.ChangePanelShowInvoice(invoice);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBUpdateInvoice db_update = new DBUpdateInvoice();
                DBGetSubjects db_subject = new DBGetSubjects();

                invoice.FA_Number = FA_number.Text;
                invoice.issue_date = DateTime.Parse(Issue_date.Text);
                invoice.due_date = DateTime.Parse(Due_date.Text);
                invoice.Payment_Method = Payment_methode.Text;

                invoice.subject_for = db_subject.GetSubjectByName(SubjectForComboBox.SelectedItem.ToString());
                invoice.subject_from = db_subject.GetSubjectByName(SubjectFromComboBox.SelectedItem.ToString());

                db_update.UpdateInvoice(invoice);

            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           
           this.owner.ChangePanelShowInvoice(invoice);
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (Int32.Parse(Amount.Text)>0)
                {

                    DBUpdateInvoice db_update = new DBUpdateInvoice();
                    DBGetItems db_items = new DBGetItems();

                    ExtendedItem chosen_item = null ;
                    List<Entity.ExtendedItem> items = db_items.GetItems();

                    foreach (ExtendedItem i in items)
                        if (i.name.Equals(AvaiableItems.SelectedItem))
                        {
                            chosen_item = i;
                            chosen_item.amount = Int32.Parse(Amount.Text);
                        }

                    if (chosen_item != null)
                    {
                        chosen_item.UpdateValues();
                        invoice.items.Add(chosen_item);
                    }
                    db_update.UpdateItemList(invoice, chosen_item);
                    SetComboboxItem();
                    Amount.Text = ""+ 0;
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void UpadateItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Int32.Parse(AmountUpdate.Text) > 0)
                {

                    DBUpdateInvoice db_update = new DBUpdateInvoice();
                    DBGetItems db_items = new DBGetItems();

                    
                    db_update.UpdateItemAmount(invoice, Items.SelectedItem.ToString(), Int32.Parse(AmountUpdate.Text));

                    SetComboboxItem();
                    AmountUpdate.Text = "" + 0;
                }
                else MessageBox.Show("Wypełnij wszystkie pola", "Błąd");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Błędne wypełnienie pól", "Błąd");
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    DBDeleteInvoice db_delete = new DBDeleteInvoice();
                    DBGetItems db_items = new DBGetItems();

                    db_delete.DeleteItemInInvoice(invoice, Items.SelectedItem.ToString());
                    SetComboboxItem();
  
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
