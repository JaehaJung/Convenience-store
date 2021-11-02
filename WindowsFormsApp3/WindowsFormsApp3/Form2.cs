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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "매출관리";

            label4.Text = (DateTime.Now).ToString();
            dataGridView1.DataSource = DataManager.Sale;

            // 버튼 설정
            button1.Click += (sender, e) =>
            {
                // 추가 버튼
                try
                {
                    {
                        C_Sale sales = new C_Sale()
                        {
                            Date = DateTime.Now,
                            Sale = int.Parse(textBox2.Text),
                        };
                        DataManager.Sale.Add(sales);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Sale;
                        DataManager.Save();
                    }
                }
                catch (Exception exception)
                {

                }
            };
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
