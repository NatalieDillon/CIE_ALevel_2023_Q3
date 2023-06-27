using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIE_ALevel_2023_Q3
{
	public class Employee
	{
		private double _hourlyPay;
		private string _employeeNumber;
		private string _jobTitle;
		private double[] _payYear2022;

		public Employee(double hourlyPay, string employeeNumber, string jobTitle) 
		{ 
			_hourlyPay = hourlyPay;
			_employeeNumber = employeeNumber;
			_jobTitle = jobTitle;
			_payYear2022 = new double[52];
		}

		public string GetEmployeeNumber() { return _employeeNumber; }

		public virtual void SetPay(int weekNumber, double numHours)
		{
			_payYear2022[weekNumber] = numHours*_hourlyPay;
		}

		public double GetTotalPay()
		{
			return _payYear2022.Sum();
		}
	}
}
