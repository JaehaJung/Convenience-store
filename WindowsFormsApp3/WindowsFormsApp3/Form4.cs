using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Text = "출근관리";
            dataGridView1.DataSource = DataManager.Work;
            dataGridView2.DataSource = DataManager.Employee;

            
            button1.Click += (sender, e) =>
            {
                try
                {
                    {
                        C_Work work= new C_Work()
                        {
                            Name = textBox1.Text,
                            Working_H = int.Parse(textBox2.Text)
                        };
                        DataManager.Work.Add(work);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Work;
                        DataManager.Save();
                    }
                }
                catch (Exception exception)
                {

                }
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                C_Employee employee = dataGridView2.CurrentRow.DataBoundItem as C_Employee;
                textBox1.Text = employee.Name;
                textBox2.Text = employee.W_Hour.ToString();
            }catch (Exception ex)
            {

            }
        }
    }
}
