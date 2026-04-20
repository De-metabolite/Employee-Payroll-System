
using Payroll;
using System.Transactions;
Employed();

 void Employed()
{
    List<Employee> employees = new List<Employee>();
    int nextId = 1;
    Console.WriteLine("WELCOME TO MY EMPLOYEE PAYROLL SYSTEM \n ");
    try
    {
        while (true)
        {
            Console.WriteLine("Enter 1 to continue or 0 to exit");
            int Count = int.Parse(Console.ReadLine());
            if (Count == 0)
            {
                Console.WriteLine("You have exited the system.");
                break;
            }

            if (Count != 1)
            {
                Console.WriteLine("Enter a valid input 1 0r 0");
                continue;

            }




            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("Input your Job-Title:");
                Console.WriteLine("Enter 1, if you are a full time employee.\n");
                Console.WriteLine("Enter 2, if you are a part time employee.\n");
                Console.WriteLine("Enter 3, if you are a contractor.\n");
                var option = int.TryParse(Console.ReadLine(), out int value);
                if (value < 1 || value > 3)
                {
                    Console.WriteLine("This is within an invalid range. Select between 1-3.");
                }
                else
                {
                    Console.WriteLine("Enter your full name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your Department(HR/IT/Finance/Operations):\n");

                    if (!Enum.TryParse(Console.ReadLine(), true, out Department dept))
                    {
                        Console.WriteLine("Invalid Department. Please enter a valid department (HR, IT, Finance, Operation).");
                        break;
                        dept = Department.HR;
                    }


                    if (value == 1)
                    {
                        Console.WriteLine("Enter your Base- Salary:\n");
                        decimal.TryParse(Console.ReadLine(), out decimal baseSalary);
                        employees.Add(new FullTimeEmployee(nextId++, name, dept, baseSalary));

                    }
                    else if (value == 2)
                    {
                        Console.WriteLine("Enter your hourlyrate:\n");
                        decimal.TryParse(Console.ReadLine(), out decimal hourlyrate);
                        Console.WriteLine("Enter your hoursworked:\n");
                        int.TryParse(Console.ReadLine(), out int hoursworked);
                        employees.Add(new PartTimeEmployee(nextId++, name, dept, hourlyrate, hoursworked));
                    }
                    else if (value == 3)
                    {
                        Console.WriteLine("Enter your Contract Amount:\n");
                        decimal.TryParse(Console.ReadLine(), out decimal amount);
                        employees.Add(new Contractor(nextId++, name, dept, amount));
                    }
                }
            }
            decimal totalpayroll = 0;
            foreach (var emp in employees)
            {
                decimal totalpay = emp.CalculateMonthlyPay();
                if (emp is IBonusable bonus)
                {
                    Console.WriteLine("Enter your Performance Score:\n");
                    decimal.TryParse(Console.ReadLine(), out decimal performancescore);
                    totalpay += bonus.GetBonus(performancescore);

                }
                totalpayroll += totalpay;
                DateTime pay = DateTime.Now;
                var payperiod = pay.ToString("MMMM,yyyy");
                PaySlip slip = new PaySlip(emp, totalpayroll, DateTime.Now, payperiod);
                slip.PrintPaySlip();

            }
            
            
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine("Technical Details:" + ex.Message);
    }



}     

