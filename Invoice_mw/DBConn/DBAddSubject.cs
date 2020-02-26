using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBAddSubject : DBConn
    {


        public void AddSubject(Entity.ExtendedSubject subject)
        {
            Subject toInsert = new Subject();
            toInsert.Id = GetFreeSubjectId();
            toInsert.Name = subject.Name;
            toInsert.Address = subject.Address;
            toInsert.NIP = subject.NIP;
            toInsert.Bank = subject.Bank;
            toInsert.Bank_Account = subject.Bank_Account;

            dbContext.Subject.InsertOnSubmit(toInsert);
            dbContext.SubmitChanges();

        } 

        public int GetFreeSubjectId()
        {
            var subject_list = from i in dbContext.Subject
                                   select new
                                   {
                                       i.Id
                                   };

           int? toReturn = null;

           foreach (var number in subject_list)
           {
               var difference = number.Id - toReturn;
               if (difference != null && difference > 1)
               {
                  return (int)toReturn + 1;
               }
                toReturn = number.Id;
           }


           return (int)toReturn + 1;
            
        }
    }
}
