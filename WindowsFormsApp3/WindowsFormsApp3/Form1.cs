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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "상품관리";

            dataGridView1.DataSource = DataManager.Product;

            // 버튼 설정
            button1.Click += (sender, e) =>
            {
                // 추가 버튼
                try
                {
                    if (DataManager.Product.Exists((x) => x.Code == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 바코드입니다");
                    }
                    if (DataManager.Product.Exists((x) => x.Name== textBox2.Text))
                    {
                        MessageBox.Show("이미 존재하는 상품명이 있습니다");
                    }
                    else
                    {
                        C_Product products = new C_Product()
                        {
                            Code = textBox1.Text,
                            Name = textBox2.Text,
                            Count = int.Parse(textBox3.Text),
                            Price = int.Parse(textBox4.Text)
                        };
                        DataManager.Product.Add(products);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Product;
                        DataManager.Save();
                    }
                }
                catch (Exception exception)
                {

                }
            };

            button2.Click += (sender, e) =>
            {
                // 수정 버튼
                try
                {
                    C_Product products = DataManager.Product.Single((x) => x.Code== textBox1.Text);
                    products.Name = textBox2.Text;
                    products.Count = int.Parse(textBox3.Text);
                    products.Price = int.Parse(textBox4.Text);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Product;
                    DataManager.Save();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("존재하지 않는 상품입니다");
                }
            };

            button3.Click += (sender, e) =>
            {
                //  버튼
                try
                {
                    C_Product products = DataManager.Product.Single((x) => x.Code== textBox1.Text);
                    DataManager.Product.Remove(products);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Product;
                    DataManager.Save();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("존재하지 않는 상품입니다");
                }
            };
        }
       
        private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void 직원추가제거ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void 직원출근월급관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                C_Product product = dataGridView1.CurrentRow.DataBoundItem as C_Product;
                textBox1.Text = product.Code;
                textBox2.Text = product.Name;
                textBox3.Text = product.Count.ToString();
                textBox4.Text = product.Price.ToString();
            }
            catch (Exception exception)
            {

            }

}
    }
}
