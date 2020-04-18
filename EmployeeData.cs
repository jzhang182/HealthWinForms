using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInfo
{
    public class EmployeeData
    {
        public SortedDictionary<int, Employee> DataDict { get; set; } = new SortedDictionary<int, Employee>();
        public void AddNew(Employee employee)
        {
            DataDict.Add(int.Parse(employee.Gin), employee); 
        }
        public void Edit(Employee employee)
        {
            DataDict.Remove(int.Parse(employee.Gin));
            DataDict.Add(int.Parse(employee.Gin), employee);
        }
    }
}
