namespace API_Error_Handling
{
    public class CustomException
    {
        public class InvalidSalaryException : Exception
        {
            public decimal RequestedSalary { get; private set; }

            public InvalidSalaryException() { }

            public InvalidSalaryException(decimal requestedSalary)
                : base($"Salary cannot be negative. You tried to assign: {requestedSalary}")
            {
                RequestedSalary = requestedSalary;
            }
        }
        //public class EmployeeNotFoundException : Exception
        //{
        //    public int RequestedEmployeeId { get; private set; }

        //    public EmployeeNotFoundException(int employeeId)
        //        : base($"Employee with ID {employeeId} not found.")
        //    {
        //        RequestedEmployeeId = employeeId;
        //    }
        //}

        public void UpdateEmployeeSalary(int employeeId, decimal newSalary)
        {
            if (newSalary < 0)
            {
                throw new InvalidSalaryException(newSalary);
            }
        }
    }
}
