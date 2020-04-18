using System;
using System.IO;
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
    public partial class MainForm : Form
    {
        EmployeeData data = new EmployeeData();
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            SubForm editForm = new SubForm(this, null, "add");
            toolStripStatusLabel1.Text = "Adding New Profile";
            editForm.Show();
            RefreshButton_Click(sender, e);
            toolStripStatusLabel1.Text = "Ready";
        }
        public void MainGetValue(Employee employee, string option)
        {
            switch ( option )
            {
                case "Edit": data.AddNew(employee); break;
                case "Delete": data.DataDict.Remove(int.Parse(employee.Gin)); break;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Searching";
            bool isGinLegal = int.TryParse(textBox1.Text, out int currentGin);
            if(!isGinLegal) MessageBox.Show("Invalid Gin");
            try 
            {
                Employee employee = data.DataDict[currentGin];
                MessageBox.Show("Target employee found" + "\n" + employee.ToString());
                SubForm editForm = new SubForm(this, employee, "Modify");
                editForm.Show();
                RefreshButton_Click(sender, e);
                toolStripStatusLabel1.Text = default;
            }
            catch 
            { 
                MessageBox.Show("No corresponding record"); 
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Loading";
            string path = "EmployeeData.csv";
            if ( !File.Exists(path) )
            {
                File.Create(path).Close();
            }
            StreamReader reader = new StreamReader(path);
            while ( !reader.EndOfStream )
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                try
                {
                    Employee newEmployee = new Employee(values[0], values[1], Convert.ToDouble(values[2]), Convert.ToBoolean(values[3]), Convert.ToBoolean(values[4]));
                    data.AddNew(newEmployee);
                }
                catch 
                {
                    MessageBox.Show("Data loaded");
                }
            }
            reader.Close();
            RefreshButton_Click(sender, e);
            toolStripStatusLabel1.Text = "Ready";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Saving";
            string path = "EmployeeData.csv";
            StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Gin" + "," + "Name" + "," + "Body Temperature" + "," + "Traveled to Hubei" + "," + "Having Symptoms");
            foreach ( var employee in data.DataDict.Values )
            {
                writer.WriteLine(employee.Gin + "," + employee.Name + "," + employee.BodyTemperature.ToString() + "," + employee.HubeiTravelStatus + "," + employee.UnderTheWeather);
            }
            writer.Flush();
            writer.Close();
            RefreshButton_Click(sender, e);
            MessageBox.Show("Data saved to csv file");
            toolStripStatusLabel1.Text = "Ready";
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach ( var currentEmployee in data.DataDict.Values )
            {
                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.BodyTemperature.ToString(), currentEmployee.HubeiTravelStatus.ToString(),currentEmployee.UnderTheWeather.ToString(), currentEmployee.Alert().ToString());
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadButton_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveButton_Click(sender, e);
        }

        private void addNewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddButton_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadButton_Click(sender, e);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveButton_Click(sender, e);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddButton_Click(sender, e);
        }

        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = (toolStrip1.Visible) ? false : true;
            showToolbarToolStripMenuItem.Checked = (toolStrip1.Visible) ? true : false;
        }

        private void showStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = (statusStrip1.Visible) ? false : true;
            showStatusToolStripMenuItem.Checked = (statusStrip1.Visible) ? true : false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var currentEmployee in data.DataDict.Values)
            {
                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.BodyTemperature.ToString(), currentEmployee.HubeiTravelStatus.ToString(), currentEmployee.UnderTheWeather.ToString(), currentEmployee.Alert().ToString());
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var currentEmployee in data.DataDict.Values)
            {
                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.BodyTemperature.ToString(), currentEmployee.HubeiTravelStatus.ToString(), currentEmployee.UnderTheWeather.ToString(), currentEmployee.Alert().ToString());
            }
        }
    }
}
