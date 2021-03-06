using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information_application_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ИнформационаяБазаEntities();

            while (true)
            {
                var listZ = db.Задания.ToList().Where(p => p.Оканчание < DateTime.Today).ToList();

                foreach (var z in listZ) 
                {
                    z.СтатусЗадание = 3;

                    var listBZ = db.СписокИсполнителей.ToList().Where(p => p.Задача == z.КодЗадание);

                    foreach(var s in listBZ)
                    {
                        s.ПодЗадачи.СтатусПодЗадание = 3;
                    }
                }

                db.SaveChanges();

                System.Threading.Thread.Sleep(86400000);
            }
        }
    }
}
