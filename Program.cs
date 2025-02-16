
using System.Reflection.PortableExecutable;
using System.Text;
using Company;

internal class Program
{
    private static void Main(string[] args)
    {
        bool Correct = false;
        // creating variable to manage logic of application
        bool CorrectData = false;
        // variable to check user input

        void backToMenu()
        {
            Correct = false;
            CorrectData = true;
            Console.Clear();
            // going back to menu
        }

        List<Employee> employees = new List<Employee>();
        // new list of employees
        employees.Add(new Employee() { Name = "Przemysław Czosnek", Position = "CEO", Salary = 45000 });
        // creation of CEO profile

        while (Correct == false)
        {
            Console.WriteLine("Application made by Jakub Podlaski, no. 123739 and Kacper Franke, no. 123727\n");
            int Menu = 0;
            // variable to manage selection of menu
            Console.WriteLine("Menu\n1.Add employee\n2.Remove employee\n3.Show list of employees\n4.Calculate salary\n5.Exit");
            Menu = int.Parse(Console.ReadLine());
            // reading selection from user
            Console.Clear();
            if (Menu > 0 && Menu < 6)
            {
                // checking if user picked correct number
                Correct = true;
                switch (Menu)
                {
                    case 1:
                        {
                            CorrectData = false;
                            Console.WriteLine("Give full name of employee:");
                            string fullname = "";
                            // variable for name of new profile
                            while (!CorrectData)
                            {
                                fullname = Console.ReadLine();
                                // reading name from user
                                if (fullname != null)
                                {
                                    // if username is not empty
                                    bool isExisting = false;
                                    // variable to check if user already exists
                                    foreach (Employee emp in employees)
                                    {
                                        if (emp.Name == fullname)
                                        {
                                            Console.WriteLine("Employee exists!\nGive different name");
                                            isExisting = true;
                                            break;
                                            // if at least once name picked by user is matching already existing profile, bool is changed to true
                                        }
                                    }
                                    if(isExisting == true)
                                    {
                                        CorrectData = false;
                                        // if profile already exists, app will ask again for name
                                    }
                                    else
                                    {
                                        CorrectData = true;
                                        // otherwise will continue
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
                            while (!CorrectData)
                            {
                                position = Console.ReadLine();
                                string upperLetter = position[0].ToString().ToUpper();
                                position = upperLetter + position.Substring(1);
                                // making sure that every position will have same format
                                if (position == "Clerk" || position == "Manager" || position == "Head manager" || position == "CEO")
                                {
                                    CorrectData = true;
                                    // checking if user wrote one of correct positions
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
                                    // user cannot specify 0 amount for salary
                                }
                                else
                                {
                                    CorrectData = true;
                                }

                            }
                            employees.Add(new Employee() { Name = fullname, Position = position, Salary = salary });
                            // adding new employee of given data
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            CorrectData = false;
                            while(!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if(back == 1)
                                {
                                    backToMenu();
                                    break;
                                }
                                if(back == 2)
                                {
                                    CorrectData = true;
                                    // exitting application
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
                            Console.WriteLine("Which employee would you like to remove? Give full name");
                            string toRemove = Console.ReadLine();
                            // user input, which profile to remove
                            bool ifFound = false;
                            // logic if profile is found
                            for (int i = employees.Count - 1; i >= 0; i--)
                            {
                                if (employees[i].Name == toRemove)
                                {
                                    // searching for matching name
                                    employees.RemoveAt(i);
                                    // removing profile at matching id
                                    ifFound = true;
                                    break;
                                }
                            }
                            if (!ifFound)
                            {
                                Console.WriteLine("Employee not found!");
                            }
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            CorrectData = false;
                            while (!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if (back == 1)
                                {
                                    backToMenu();
                                    break;
                                }
                                if (back == 2)
                                {
                                    CorrectData = true;
                                    // exitting application
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
                            CorrectData = false;
                            while (!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if (back == 1)
                                {
                                    backToMenu();
                                    break;
                                }
                                if (back == 2)
                                {
                                    CorrectData = true;
                                    // exitting application
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
                            Console.WriteLine("Give full name of employee");
                            string searchName = Console.ReadLine();
                            // user input of searched person
                            bool employeeFound = false;
                            // variable to store data if person is found
                            foreach (Employee emp in employees)
                            {
                                if (searchName == emp.Name)
                                {
                                    Console.WriteLine("Employee found!");
                                    int bonus = 0;
                                    Console.WriteLine("Specify percentage bonus amount, 0 means no bonus");
                                    bonus = int.Parse(Console.ReadLine());
                                    double salaryWithBonus = (double)(emp.Salary + (emp.Salary * bonus / 100));
                                    Console.WriteLine("Calculated salary: " + salaryWithBonus);
                                    employeeFound = true;
                                    // if person is found, the application gets salary amount and lets user add bonus
                                }
                            }
                            if (!employeeFound)
                            {
                                Console.WriteLine("Employee not found!");
                                // if employee is not found
                            }
                            Console.WriteLine("\nDo you want to return to menu?\n1.Yes\n2.No");
                            int back = 0;
                            CorrectData = false;
                            while (!CorrectData)
                            {
                                back = int.Parse(Console.ReadLine());
                                if (back == 1)
                                {
                                    backToMenu();
                                    break;
                                }
                                if (back == 2)
                                {
                                    CorrectData = true;
                                    // exitting application
                                }
                                else
                                {
                                    Console.WriteLine("Give correct number");
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            break;
                            // exitting application
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