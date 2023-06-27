using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIE_ALevel_2023_Q3
{
	public class Manager : Employee
	{
		private double _bonusValue;

		public Manager(double bonusValue, double hourlyPay, string employeeNumber, string jobTitle) : base(hourlyPay, employeeNumber, jobTitle)
		{
			_bonusValue = bonusValue;
		}

		public override void SetPay(int weekNumber, double numHours)
		{
			numHours = numHours * (1 + _bonusValue / 100);
			base.SetPay(weekNumber, numHours);
		}
	}
}
