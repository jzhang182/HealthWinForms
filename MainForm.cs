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
        List<DateTime> dateList = new List<DateTime>();
        public MainForm()
        {
            InitializeComponent();
        }
        public void MainGetValue(Employee employee, string option)
        {
            switch ( option )
            {
                case "Edit": data.AddNew(employee); break;
                case "Delete": data.Delete(employee); break;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Adding New Profile";
            SubForm editForm = new SubForm(this, null, "add");
            editForm.Show();
            RefreshButton_Click(sender, e);
            toolStripStatusLabel1.Text = "Ready";
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Searching";
            bool isGinLegal = int.TryParse(textBox1.Text, out int currentGin);
            if ( !isGinLegal ) MessageBox.Show("Invalid Gin");
            else
            {
                try
                {
                    Employee employee = data.DataDict[currentGin];
                    MessageBox.Show("Target employee found" + "\n" + employee.ToString());
                    SubForm editForm = new SubForm(this, employee, "Modify");
                    editForm.Show();
                    RefreshButton_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("No corresponding record");
                }
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
                try
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Dictionary<DateTime, DailyInformation> statusDict = new Dictionary<DateTime, DailyInformation>();
                    if ( data.DataDict.ContainsKey(int.Parse(values[0])) )
                    {
                        Employee currentEmployee = data.DataDict[int.Parse(values[0])];
                        currentEmployee.StatusRecordDict.Add(DateTime.Parse(values[5]), new DailyInformation(double.Parse(values[2]), bool.Parse(values[3]), bool.Parse(values[4])));
                    }
                    else
                    {
                        Employee newEmployee = new Employee(values[0], values[1], statusDict);
                        newEmployee.StatusRecordDict.Add(DateTime.Parse(values[5]), new DailyInformation(double.Parse(values[2]), bool.Parse(values[3]), bool.Parse(values[4])));
                        data.AddNew(newEmployee);
                    }
                }
                catch 
                {
                    MessageBox.Show("Invalid File. Please Check.");
                }
            }
            reader.Close();
            RefreshButton_Click(sender, e);
            toolStripStatusLabel1.Text = "Ready";
            List<string> nameList = new List<string>();
            //List<DateTime> dateList = new List<DateTime>();
            foreach (var currentGin in data.DataDict.Keys )
            {
                if ( !nameList.Contains(data.DataDict[currentGin].Name) )
                {
                    nameList.Add(data.DataDict[currentGin].Name);
                    treeView1.Nodes[1].Nodes.Add(data.DataDict[currentGin].Name);
                }
                foreach ( var currentDate in data.DataDict[currentGin].StatusRecordDict.Keys )
                {
                    if ( !dateList.Contains(currentDate) )
                    {
                        dateList.Add(currentDate);
                        treeView1.Nodes[0].Nodes.Add(currentDate.ToShortDateString());
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Saving";
            string path = "EmployeeData.csv";
            StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            foreach ( var employee in data.DataDict.Values )
            {
                foreach(var date in employee.StatusRecordDict.Keys)
                    writer.WriteLine(employee.Gin + "," + employee.Name + "," + employee.StatusRecordDict[date].ToString()+ "," + date.ToShortDateString());
            }
            writer.Flush();
            writer.Close();
            RefreshButton_Click(sender, e);
            MessageBox.Show("Data saved to csv file");
            toolStripStatusLabel1.Text = "Ready";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sortOption = ( radioButton1.Checked ) ? "Date" : "Name";
            switch ( sortOption )
            {
                case "Date": 
                    {
                        foreach ( var currentDate in dateList )
                        {
                            foreach ( var currentEmployee in data.DataDict.Values )
                            {
                                foreach ( var date in currentEmployee.StatusRecordDict.Keys )
                                {
                                    if (date == currentDate)
                                    {
                                        dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.StatusRecordDict[date].BodyTemperature.ToString(),
                                        currentEmployee.StatusRecordDict[date].HubeiTravelStatus.ToString(), currentEmployee.StatusRecordDict[date].UnderTheWeather.ToString()
                                        , date.ToShortDateString());
                                    } 
                                }
                            }
                        }
                        break; 
                    }
                case "Name":
                    {
                        foreach ( var currentEmployee in data.DataDict.Values )
                        {
                            foreach ( var date in currentEmployee.StatusRecordDict.Keys )
                            {
                                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.StatusRecordDict[date].BodyTemperature.ToString(),
                                currentEmployee.StatusRecordDict[date].HubeiTravelStatus.ToString(), currentEmployee.StatusRecordDict[date].UnderTheWeather.ToString()
                                , date.ToShortDateString());
                            }
                        }
                        break;
                    }
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
            foreach ( var currentDate in dateList )
            {
                foreach ( var currentEmployee in data.DataDict.Values )
                {
                    foreach ( var date in currentEmployee.StatusRecordDict.Keys )
                    {
                        if ( date == currentDate )
                        {
                            dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.StatusRecordDict[date].BodyTemperature.ToString(),
                            currentEmployee.StatusRecordDict[date].HubeiTravelStatus.ToString(), currentEmployee.StatusRecordDict[date].UnderTheWeather.ToString()
                            , date.ToShortDateString());
                        }
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach ( var currentEmployee in data.DataDict.Values )
            {
                foreach ( var date in currentEmployee.StatusRecordDict.Keys )
                {
                    dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.StatusRecordDict[date].BodyTemperature.ToString(),
                    currentEmployee.StatusRecordDict[date].HubeiTravelStatus.ToString(), currentEmployee.StatusRecordDict[date].UnderTheWeather.ToString()
                    , date.ToShortDateString());
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string child = treeView1.SelectedNode.Text;
            dataGridView1.Rows.Clear();
            foreach ( var currentEmployee in data.DataDict.Values )
            {
                foreach ( var date in currentEmployee.StatusRecordDict.Keys )
                {
                    if (currentEmployee.Name == child | date.ToShortDateString().Contains(child) ) 
                    {
                        dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.StatusRecordDict[date].BodyTemperature.ToString(),
                        currentEmployee.StatusRecordDict[date].HubeiTravelStatus.ToString(), currentEmployee.StatusRecordDict[date].UnderTheWeather.ToString()
                        , date.ToString());
                    }
                }
            }
        }

    }
}
