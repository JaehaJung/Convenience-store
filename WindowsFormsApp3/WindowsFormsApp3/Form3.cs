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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Text = "직원관리";
            dataGridView1.DataSource = DataManager.Employee;
            button1.Click += (sender, e) =>
            {
                // 추가 버튼
                try
                {
                    if (DataManager.Employee.Exists((x) => x.Phone_num == textBox4.Text))
                    {
                        MessageBox.Show("이미 존재하는 전화번호입니다");
                    }
                    
                    else
                    {
                        C_Employee employees = new C_Employee()
                        {
                            Name = textBox1.Text,
                            H_Wage = int.Parse(textBox2.Text),
                            W_Hour = int.Parse(textBox3.Text),
                            Phone_num = textBox4.Text
                        };
                        DataManager.Employee.Add(employees);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Employee;
                        DataManager.Save();
                    }
                }
                catch (Exception exception)
                {

                }
            };
            button3.Click += (sender, e) =>
            {
                //  삭제 버튼
                try
                {
                    C_Employee employees= DataManager.Employee.Single((x) => x.Name== textBox1.Text);
                    DataManager.Employee.Remove(employees);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Employee;
                    DataManager.Save();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("존재하지 않는 직원입니다");
                }
            };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                C_Employee employee = dataGridView1.CurrentRow.DataBoundItem as C_Employee;
                textBox4.Text = employee.Phone_num;
            }
            catch (Exception ex) { }

        }
    }
}
