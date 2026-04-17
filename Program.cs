
using Payroll;
using System.Transactions;
Employed();

void Employed()
{
    List<Employee> employees = new List<Employee>();
    int nextId = 1;
    Console.WriteLine("How many employees are you checking for? ");
    int Count = int.Parse(Console.ReadLine());
    for (int i = 0; i < Count; i++)
    {
        Console.WriteLine("Input your Job-Title:");
        Console.WriteLine("Enter 1, if your a full time employee.\n");
        Console.WriteLine("Enter 2, if your a part time employee.\n");
        Console.WriteLine("Enter 3, if your a contractor.\n");
        Console.WriteLine("Enter your full name:\n");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your Department(HR, IT, Finance , Operation:\n");
        Enum.TryParse(Console.ReadLine(), out Department dept);
        var option = int.TryParse(Console.ReadLine(), out int value);
        if (value < 1 || value > 3)
        {
            Console.WriteLine("This is within an invalid range. Select between 1-3.");
        }

        else
        {
            if (value == 1)
            {
                Console.WriteLine("Enter your Base- Salary:\n");
                decimal.TryParse(Console.ReadLine(), out decimal baseSalary);
                employees.Add(new FullTimeEmployee(nextId++, name, dept, baseSalary));
                Console.WriteLine($"{baseSalary} is your Base Salary.");
            }
            else if (value == 2)
            {
                Console.WriteLine("Enter your hourlyrate:\n");
                decimal.TryParse(Console.ReadLine(), out decimal hourlyrate);
                Console.WriteLine("Enter your hoursworked:\n");
                int.TryParse(Console.ReadLine(), out int hoursworked);

            }
        }
    }

}     

