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
    /// Logika interakcji dla klasy AddSubject.xaml
    /// </summary>
    public partial class AddSubject : UserControl
    {
        MainWindow owner;
        public AddSubject(MainWindow owner)
        {
            this.owner = owner;
            InitializeComponent();
        }



        private void CreateSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Nametxt.Text.Equals("")
                        && !NIPtxt.Text.Equals("")
                        && !Banktxt.Text.Equals("")
                        && !Addresstxt.Text.Equals("")
                        && !BankAccounttxt.Text.Equals(""))
                {
                    ExtendedSubject subject = new ExtendedSubject(-1, Nametxt.Text, Addresstxt.Text, NIPtxt.Text, Banktxt.Text, BankAccounttxt.Text);
                    DBAddSubject db = new DBAddSubject();
                    db.AddSubject(subject);
                    owner.ChangePanelInvoiceList();
                }
                else MessageBox.Show("Wypełnij wszystkie pola", "Błąd");
            }
            catch(Exception ex)
                {
                MessageBox.Show("Błędne wypełnienie pól", "Błąd");
                Debug.WriteLine(ex.Message);
                }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            owner.ChangePanelInvoiceList();
        }
    }
}
