namespace CIE_ALevel_2023_Q3
{
	internal class Program
	{
		static void Main()
		{
			string fileName = "./Employees.txt";
			Employee[] employees = new Employee[8];

			if (File.Exists(fileName))
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					while (!sr.EndOfStream)
					{
						for (int i = 0; i < 8; i++)
						{
							double hourlyPay = double.Parse(sr.ReadLine() ?? string.Empty);
							string employeeNumber = sr.ReadLine() ?? string.Empty;
							string bonusOrJobTitle = sr.ReadLine() ?? string.Empty;
							if (double.TryParse(bonusOrJobTitle, out double bonusValue))
							{
								string jobTitle = sr.ReadLine() ?? string.Empty;
								Manager manager = new Manager(bonusValue, hourlyPay, employeeNumber, jobTitle);
								employees[i] = manager;
							}
							else
							{
								Employee employee = new Employee(hourlyPay, employeeNumber, bonusOrJobTitle);
								employees[i] = employee;
							}
						}
					}
				}
			}
			else
			{
				Console.WriteLine($"File {fileName} not found.");
			}

			EnterHours(employees);
			foreach (Employee employee in employees)
			{
				Console.WriteLine($"Employee Number: {employee.GetEmployeeNumber()}, Total Pay: {employee.GetTotalPay():0:00}");
			}
			
		}

		private static void EnterHours(Employee[] employees)
		{
			string fileName = "./HoursWeek1.txt";

			if (File.Exists(fileName))
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					while (!sr.EndOfStream)
					{
						string employeeNumber = sr.ReadLine() ?? string.Empty;
						double hoursWorked = double.Parse(sr.ReadLine() ?? string.Empty);
						var employee = employees.FirstOrDefault(emp => emp.GetEmployeeNumber() == employeeNumber);
						if (employee != null)
						{
							employee.SetPay(0, hoursWorked);
						}
					}
				}
			}
			else
			{
				Console.WriteLine($"File {fileName} not found.");
			}
		}
	}
}