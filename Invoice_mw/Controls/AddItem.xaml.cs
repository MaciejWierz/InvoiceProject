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
    /// <summary>
    /// Logika interakcji dla klasy AddItem.xaml
    /// </summary>
    public partial class AddItem : UserControl
    {
        MainWindow owner;
        public AddItem(MainWindow owner)
        {
            this.owner = owner;
            InitializeComponent();
        }

        private void CancelItemBtn_Click(object sender, RoutedEventArgs e)
        {
            this.owner.ChangePanelInvoiceList();

        }

        private void CreateItemBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (!Nametxt.Text.Equals("")
                        && !ItemTypetxt.Text.Equals("")
                        && !VATtxt.Text.Equals("")
                        && !Pricetxt.Text.Equals(""))
                {
                    Entity.ExtendedItem item = new ExtendedItem(Nametxt.Text, ItemTypetxt.Text, Int32.Parse(VATtxt.Text), Int32.Parse(Pricetxt.Text), -1);
                    DBAddItem db = new DBAddItem();
                    db.AddItem(item);
                    owner.ChangePanelInvoiceList();
                }
                else MessageBox.Show("Wypełnij wszystkie pola", "Błąd");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błędne wypełnienie pól", "Błąd");
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
