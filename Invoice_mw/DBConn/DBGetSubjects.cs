using Invoice_mw.SQLtoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_mw.DBConn
{
    class DBGetSubjects : DBConn
    {

        public List<Entity.ExtendedSubject> GetSubjects()
        {
            List<Entity.ExtendedSubject> list = new List<Entity.ExtendedSubject>();
            var subjects =  from sub in dbContext.Subject
                            select new {
                                sub.Id,
                                sub.Name,
                                sub.Address,
                                sub.NIP,
                                sub.Bank,
                                sub.Bank_Account
                            };
            
            foreach( var s in subjects)
                  list.Add( new Entity.ExtendedSubject(
                        s.Id,
                        s.Name,
                        s.Address,
                        s.NIP,
                        s.Bank,
                        s.Bank_Account));

            return list;
        }

        public List<String> GetSubjectNames()
        {
            List<Entity.ExtendedSubject> subject_list = GetSubjects();
            List<String> names_list = new List<string>();

            foreach (Entity.ExtendedSubject s in subject_list)
                names_list.Add(s.Name);

            return names_list;
        }

        public Entity.ExtendedSubject GetSubjectByName(String name)
        {
            Entity.ExtendedSubject toReturn = null;

            foreach(Entity.ExtendedSubject s in GetSubjects())
                if (s.Name.Equals(name))
                    toReturn = s;
                
            return toReturn;
        }
    }
}
