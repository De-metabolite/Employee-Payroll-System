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
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }
        protected Employee()
        {

        }

        public Employee(int id, string name, string department, decimal baseSalary)
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
        public FullTimeEmployee(int id, string name, string department, decimal baseSalary) : base(id, name, department, baseSalary)
        {

        }
        public override decimal CalculateMonthlyPay()
        {
            return BaseSalary;
        }
        public void Bonus()
        {
            return BaseSalary * (performancescore / 10);
        }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
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
        void Bonus();
    }
}

