using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    abstract class DBConn
    {

         protected InvoiceLinqDataContext dbContext;

        public DBConn()
        {
            dbContext = new InvoiceLinqDataContext(Properties.Settings.Default.mw_invoce_dbConnectionString);
        }
    }
}
