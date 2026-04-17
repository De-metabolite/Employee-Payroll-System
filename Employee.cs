using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Payroll
{
    public abstract class Employee
    {
        public int Id { get; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public decimal BaseSalary { get; set; }
        protected Employee()
        {

        }

        public Employee(int id, string name, Department department, decimal baseSalary)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Please, the name can not be empty or null ");
            }

            if (baseSalary <= 0)
            {
                throw new ArgumentException(" The Base-salary can not be negative");
            }

            Id = id;
            Name = name;
            Department = department;
            BaseSalary = baseSalary;
        }

        public abstract decimal CalculateMonthlyPay();
        public virtual string GetEmployedInfo()
        {
            return $"The Id: {Id}" + $"The Name: {Name}" + $"The Department: {Department}";
        }

    }
    public class FullTimeEmployee : Employee, IBonusable
    {
        public FullTimeEmployee() { }
        public FullTimeEmployee(int id, string name, Department department, decimal baseSalary) : base(id, name, department, baseSalary)
        {

        }
        public override decimal CalculateMonthlyPay()
        {
            return BaseSalary;
        }
        public decimal  GetBonus(decimal performancescore)
        {

            if (performancescore < 0 || performancescore > 10) 
            {
                throw new InvalidPerformanceScoreException();
            }

            return BaseSalary * (performancescore / 10);
        }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public PartTimeEmployee() { }
        public PartTimeEmployee(decimal hourlyRate, int hoursWorked)
        {
            if (hoursWorked < 0 || hoursWorked > 300)
            {
                throw new ArgumentException("The work hour can only be between 0 and 300");
            }
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * HoursWorked;
        }


    }

    public class Contractor : Employee
    {
        public decimal ContractAmount { get; set; }
        public Contractor() { }
        public Contractor(decimal amount)
        {
            ContractAmount = amount;
        }
        public override decimal CalculateMonthlyPay()
        {
            return ContractAmount;
        }
    }

    public interface IBonusable
    {
        public decimal GetBonus(decimal performancescore);
    }

    public class InvalidPerformanceScoreException : Exception
    {
        public InvalidPerformanceScoreException() : base("Invalid Performance Score")
        {
        }
        public InvalidPerformanceScoreException(string message) : base(message)
        {
        }
    }

    public struct PaySlip
    { 
        public Employee Employee { get; set; }
        public decimal Grosspay { get; set; }
        public DateTime PayDate {  get; set; }
        public string PayPeriod {  get; set; }

        public PaySlip(Employee employee, decimal grosspay, DateTime paydate, string payPeriod)
        {
            Employee = employee;
            Grosspay = grosspay;
            PayDate = paydate;
            PayPeriod = payPeriod;
        }

        void PrintPaySlip()
        {
            Console.WriteLine(Employee);
            Console.WriteLine(Grosspay);
            Console.WriteLine(PayDate);
            Console.WriteLine(PayPeriod);
        }
    }
    public enum Department 
    { 
        IT,
        HR,
        Finance,
        Operations,
    }
}

