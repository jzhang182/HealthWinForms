using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthInfo
{
    public partial class SubForm : Form
    {
        public MainForm subMainForm;
        public SubForm(MainForm mainForm, Employee employee, string option)
        {
            subMainForm = mainForm;
            InitializeComponent();
            switch ( option )
            {
                case "Add":
                    {
                        label1.Text = "Please enter new employee information";
                        label2.Text = "Gin";
                        label3.Text = "Name";
                        label4.Text = "Body Temperature";
                        label5.Text = "Been Hubei";
                        label6.Text = "Not Feeling Well";
                        break;
                    }
                case "Modify":
                    {
                        //label1.Text = "Please modify or delete";
                        //label2.Text = employee.Gin;
                        //label3.Text = "Name:" + employee.Name;
                        //label4.Text = "Temperature:" + employee.StatusRecordDict.ToString();
                        //label5.Text = "Been Hubei";
                        //label6.Text = "Not Feeling Well";
                        //BeenHubei.Checked = employee.HubeiTravelStatus;
                        //NotFeelingWell.Checked = employee.UnderTheWeather;
                        break;
                    }
            }
        }
        private void SaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<DateTime, DailyInformation> statusDict = new Dictionary<DateTime, DailyInformation>();
                Employee newEmployee = new Employee(textBox1.Text, textBox2.Text, statusDict);
                newEmployee.StatusRecordDict.Add(dateTimePicker1.Value, new DailyInformation(double.Parse(textBox3.Text), BeenHubei.Checked, NotFeelingWell.Checked));

                subMainForm.MainGetValue(newEmployee, "Edit");
                MessageBox.Show("Successfully Saved");
            }
            catch
            {
                MessageBox.Show("Wrong input format, please retry");
            }
            Close();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(label2.Text, label3.Text, new Dictionary<DateTime, DailyInformation>());
            MessageBoxButtons confirmButton = new MessageBoxButtons();
            MessageBoxButtons denyButton = new MessageBoxButtons();
            //MessageBox.Show("Do you want to delete all current records of this employee?", "", confirmButton, denyButton);
            subMainForm.MainGetValue(employee, "Delete");
            MessageBox.Show("Record Deleted" + "\n" + employee.ToString());
            Close();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
