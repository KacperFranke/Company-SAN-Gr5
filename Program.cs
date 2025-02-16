
using System.Reflection.PortableExecutable;
using System.Text;
using Company;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new Employee() { Name = "Przemysław Czosnek", Position = "CEO", Salary = 45000 });

        bool Correct = false;
        while (Correct == false)
        {
            Console.WriteLine("Application made by Jakub Podlaski, no. 123739 and Kacper Franke, no. 123727\n");
            int Menu = 0;
            Console.WriteLine("Menu\n1.Add employee\n2.Calculate salary\n3.Show list of employees\n4.Exit");
            Menu = int.Parse(Console.ReadLine());
            Console.Clear();
            if (Menu > 0 && Menu < 5)
            {
                Correct = true;
                switch (Menu)
                {
                    case 1:
                        {
                            bool CorrectData = false;
                            Console.WriteLine("Give full name of employee:");
                            string fullname = "";
                            while (CorrectData == false)
                            {
                                fullname = Console.ReadLine();
                                if (fullname != null)
                                {
                                    bool isExisting = false;
                                    foreach (Employee emp in employees)
                                    {
                                        if (emp.Name == fullname)
                                        {
                                            Console.WriteLine("Employee exists!\nGive different name");
                                            isExisting = true;
                                            break;
                                        }
                                    }
                                    if(isExisting == true)
                                    {
                                        CorrectData = false;
                                    }
                                    else
                                    {
                                        CorrectData = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Give correct name");
                                }
                            }
                            Console.WriteLine("Give position of employee (Clerk, Manager, Head Manager, CEO)");
                            CorrectData = false;
                            string position = "";
                            while (CorrectData == false)
                            {
                                position = Console.ReadLine();
                                string upperLetter = position[0].ToString().ToUpper();
                                position = upperLetter + position.Substring(1);
                                if (position == "Clerk" || position == "Manager" || position == "Head manager" || position == "CEO")
                                {
                                    CorrectData = true;
                                }
                                else
                                {
                                    Console.WriteLine("Give correct position");
                                }
                            }
                            CorrectData = false;
                            int salary = 0;
                            Console.WriteLine("Specify salary of the employee");
                            while (CorrectData == false)
                            {
                                salary = int.Parse(Console.ReadLine());
                                if(salary == 0)
                                {
                                    Console.WriteLine("Give correct amount");
                                }
                                else
                                {
                                    CorrectData = true;
                                }

                            }
                            employees.Add(new Employee() { Name = fullname, Position = position, Salary = salary });
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            CorrectData = false;
                            while(!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if(back == 1)
                                {
                                    Correct = false;
                                    CorrectData = true;
                                    Console.Clear();
                                }
                                if(back == 2)
                                {
                                    CorrectData = true;
                                }
                                else
                                {
                                    Console.WriteLine("Give correct number");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Give full name of employee");
                            string searchName = Console.ReadLine();
                            bool employeeFound = false;
                            foreach (Employee emp in employees) {
                                if (searchName == emp.Name)
                                {
                                    Console.WriteLine("Employee found!");
                                    int bonus = 0;
                                    Console.WriteLine("Specify percentage bonus amount, 0 means no bonus");
                                    bonus = int.Parse(Console.ReadLine());
                                    double salaryWithBonus = (double)(emp.Salary + (emp.Salary * bonus / 100));
                                    Console.WriteLine("Calculated salary: " + salaryWithBonus);
                                    employeeFound = true;
                                }
                            }
                            if(!employeeFound)
                            {
                                Console.WriteLine("Employee not found!");
                            }
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            bool CorrectData = false;
                            while (!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if (back == 1)
                                {
                                    Correct = false;
                                    CorrectData = true;
                                    Console.Clear();
                                }
                                if (back == 2)
                                {
                                    CorrectData = true;
                                }
                                else
                                {
                                    Console.WriteLine("Give correct number");
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach(Employee emp in employees)
                            {
                                Console.WriteLine(emp.Name+", position: "+emp.Position+", salary: "+emp.Salary);
                            }
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            bool CorrectData = false;
                            while (!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if (back == 1)
                                {
                                    Correct = false;
                                    CorrectData = true;
                                    Console.Clear();
                                }
                                if (back == 2)
                                {
                                    CorrectData = true;
                                }
                                else
                                {
                                    Console.WriteLine("Give correct number");
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                }
            }
            else
            {
                Console.Clear();   
            }
        }
        
    }
}