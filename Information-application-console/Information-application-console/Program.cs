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

                    var listSI = db.СписокИсполнителей.ToList().Where(p => p.Задача == z.КодЗадание);

                    foreach (var s in listSI)
                    {
                        s.ПодЗадачи.СтатусПодЗадание = 3;
                    }
                }

                var listEmp = db.Сотрудники.ToList().Where(p => p.Занетость == true);

                foreach (var emp in listEmp)
                {
                    var listSI = emp.СписокИсполнителей;

                    bool stas = false;

                    foreach (var s in listSI)
                    {
                        if (s.Задания.СтатусЗадание != 1)
                            stas = true;
                    }

                    emp.Занетость = stas;
                }


                db.SaveChanges();

                System.Threading.Thread.Sleep(86400000);
            }
        }
    }
}
