using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DZ_c_ch_employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("задача 1");

            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Name = "Georg", Department = "advertising", Salary = 31200, PositionLevel = "supervisor" });//
            list.Add(new Employee { Name = "Marc", Department = "production", Salary = 30800, PositionLevel = "supervisor" });
            list.Add(new Employee { Name = "Alica", Department = "purchase", Salary = 28000, PositionLevel = "supervisor" });
            list.Add(new Employee { Name = "Olga Glk", Department = "advertising", Salary = 37500, PositionLevel = "worker" });//
            list.Add(new Employee { Name = "Klod", Department = "purchase", Salary = 33000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Eva", Department = "purchase", Salary = 43000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Stephani", Department = "production", Salary = 45000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Donald", Department = "advertising", Salary = 37000, PositionLevel = "worker" });//
            list.Add(new Employee { Name = "Kevin", Department = "production", Salary = 36700, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Fausto", Department = "production", Salary = 31000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Eva Terr", Department = "purchase", Salary = 43000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Stephani Festo", Department = "production", Salary = 45000, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Donald Tpump", Department = "advertising", Salary = 37000, PositionLevel = "worker" });//
            list.Add(new Employee { Name = "Kevin Adg", Department = "production", Salary = 36700, PositionLevel = "worker" });
            list.Add(new Employee { Name = "Fausto Joyt", Department = "production", Salary = 35000, PositionLevel = "worker" });

            //Рассчитать среднюю зарплату для каждого отдела.
            IEnumerable<Employee> CountEmployeeToAdvertising = list.Where(p => p.Department == "advertising");
            var avSalaryToAdvertising = CountEmployeeToAdvertising.Sum(p => p.Salary) / CountEmployeeToAdvertising.Count();

            IEnumerable<Employee> CountEmployeeToProduction = list.Where(p => p.Department == "production");
            var avSalaryToProduction = CountEmployeeToProduction.Sum(p => p.Salary) / CountEmployeeToProduction.Count();

            IEnumerable<Employee> CountEmployeeToPurchase = list.Where(p => p.Department == "purchase");
            var avSalaryToPurchase = CountEmployeeToPurchase.Sum(p => p.Salary) / CountEmployeeToPurchase.Count();

            Console.WriteLine($"Advertising: {avSalaryToAdvertising}");
            Console.WriteLine($"Production: {avSalaryToProduction}");
            Console.WriteLine($"Purchase: {avSalaryToPurchase}");

            //Найти отдел с самой высокой средней зарплатой.
            Dictionary<decimal, Employee> keyValuePairs = new Dictionary<decimal, Employee>();
            keyValuePairs.Add(avSalaryToAdvertising, CountEmployeeToAdvertising.FirstOrDefault());
            keyValuePairs.Add(avSalaryToProduction, CountEmployeeToProduction.FirstOrDefault());
            keyValuePairs.Add(avSalaryToPurchase, CountEmployeeToPurchase.FirstOrDefault());
            var keyValuePair = keyValuePairs.OrderByDescending(s => s.Key);
            Console.WriteLine($"DepartmentMaxavSalary: {keyValuePair.FirstOrDefault().Value.Department}");


            //Найти всех работников с зарплатой выше средней по всем отделам.
            var EmplBigSalaryAdvertising = CountEmployeeToAdvertising.Where(a => a.Salary > avSalaryToAdvertising);
            var EmplBigSalaryProduction = CountEmployeeToProduction.Where(a => a.Salary > avSalaryToProduction);
            var EmplBigSalaryPurchase = CountEmployeeToPurchase.Where(a => a.Salary > avSalaryToPurchase);

            //Найти суммарную зарплату для каждого уровня должности.
            var PositionLevelSupervisor = list.Where(a => a.PositionLevel == "supervisor").Sum(s => s.Salary);
            var PositionLevelWorker = list.Where(a => a.PositionLevel == "worker").Sum(s => s.Salary);

            Console.WriteLine();
            Console.WriteLine("задача 2");
            Console.WriteLine();
            TransactionOperetion<Transaction> transactions = new TransactionOperetion<Transaction>();

            DateTime d1 = new DateTime(2021, 2, 14);//
            transactions.Add(new Transaction("145877545", 84512, d1));
            DateTime d2 = new DateTime(2020, 4, 24);
            transactions.Add(new Transaction("100572355", 34820, d2));
            DateTime d3 = new DateTime(2021, 1, 4);//
            transactions.Add(new Transaction("148942355", 24892, d3));
            DateTime d4 = new DateTime(2021, 12, 5);//
            transactions.Add(new Transaction("145872995", 64862, d4));
            DateTime d5 = new DateTime(2018, 5, 24);
            transactions.Add(new Transaction("164548724", 29822, d5));
            DateTime d6 = new DateTime(2014, 11, 6);
            transactions.Add(new Transaction("145454355", 84820, d6));
            DateTime d7 = new DateTime(2001, 12, 15);
            transactions.Add(new Transaction("145800075", 24122, d7));
            DateTime d8 = new DateTime(2023, 5, 30);
            transactions.Add(new Transaction("254648355", 24002, d8));
            DateTime d9 = new DateTime(2017, 3, 25);
            transactions.Add(new Transaction("145877005", 84452, d9));
            DateTime d10 = new DateTime(2021, 4, 18);//
            transactions.Add(new Transaction("100077245", 83212, d10));


            DateTime dataStart = new DateTime(2021, 1, 1);
            DateTime dataEnd = new DateTime(2021, 12, 30);

            var MidlSum = transactions.SrSummTransaction(dataStart, dataEnd);

            Console.WriteLine($"Средняя сумма транзакций за период : c {dataStart} по {dataEnd}  составляет - {MidlSum}  ");

            Console.WriteLine();
            Console.WriteLine("задача 3");
            Console.WriteLine("Не решена, задание не ясное");
            






        }



    }

}
