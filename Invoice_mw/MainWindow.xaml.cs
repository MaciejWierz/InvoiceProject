using Invoice_mw.Controls;
using Invoice_mw.Entity;
using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace Invoice_mw
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            
            InitializeComponent();
            this.contentControl.Content = new InvoiceList(this);
           
        }

        public void ChangePanelShowInvoice(String invoice)
        {
            this.contentControl.Content = new ShowInvoice(invoice, this);
        }

        public void ChangePanelShowInvoice(Entity.ExtendedInvoice invoice)
        {
            this.contentControl.Content = new ShowInvoice(invoice, this);
            
        }

        public void ChangePanelInvoiceList()
        {
            this.contentControl.Content = new InvoiceList(this);
        }

        internal void ChangePanelEditInvoice(Entity.ExtendedInvoice invoice)
        {
            this.contentControl.Content = new EditInvoice(invoice, this);

        }

        internal void ChangePanelAddInvoice()
        {
            this.contentControl.Content = new AddInvoice(this);
        }

        internal void ChangePanelAddSubject()
        {
            this.contentControl.Content = new AddSubject(this);
        }

        internal void ChangePanelItems()
        {
            this.contentControl.Content = new AddItem(this);
        }
    }
}
