using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp3
{
    class DataManager
    {
        public static List<C_Product> Product = new List<C_Product>();
        public static List<C_Sale> Sale = new List<C_Sale>();
        public static List<C_Employee> Employee = new List<C_Employee>();
        public static List<C_Work> Work = new List<C_Work>();

        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string productsOutput = File.ReadAllText(@"./Product.xml");
                XElement productsXElement = XElement.Parse(productsOutput);
                Product = (from item in productsXElement.Descendants("product")
                            select new C_Product()
                            {
                               Code =  item.Element("code").Value,
                               Name = item.Element("name").Value,
                               Count = int.Parse (item.Element("count").Value),
                               Price = int.Parse (item.Element("price").Value)
                            }).ToList<C_Product>();

                string salesOutput = File.ReadAllText(@"./Sale.xml");
                XElement salesXElement = XElement.Parse(salesOutput);
                Sale = (from item in salesXElement.Descendants("sales")
                            select new C_Sale()
                            {
                                Date = DateTime.Parse(item.Element("date").Value),
                                Sale = int.Parse(item.Element("sale").Value),
                                Y_Sale= int.Parse(item.Element("y_sale").Value),
                                M_Sale = int.Parse(item.Element("M_sale").Value)
                            }).ToList<C_Sale>();

                string employeeOutput = File.ReadAllText(@"./Employee.xml");
                XElement employeeXElement = XElement.Parse(employeeOutput);
                Employee = (from item in employeeXElement.Descendants("employee")
                         select new C_Employee()
                         {
                             Name = item.Element("name").Value,
                             H_Wage= int.Parse(item.Element("h_wage").Value),
                             W_Hour = int.Parse(item.Element("w_hour").Value),
                             Phone_num = item.Element("phone_num").Value
                         }).ToList<C_Employee>();

                string workOutput = File.ReadAllText(@"./Work.xml");
                XElement workXElement = XElement.Parse(workOutput);
                Work = (from item in workXElement.Descendants("work")
                             select new C_Work()
                             {
                                 Name = item.Element("name").Value,
                                 Working_H = int.Parse(item.Element("working_h").Value),
                                 IsWorked = item.Element("isworked").Value != "0"? true:false
                             }).ToList<C_Work>();
            }
            catch(FileLoadException exception)
            {
                Save();
            }
        }

        public static void Save()
        {
            //product xml
            string productsOutput = "";
            productsOutput += "<products>\n";
            foreach (var item in Product)
            {
                productsOutput += "<product>\n";
                productsOutput += "<code>" + item.Code + "</code>\n";
                productsOutput += "<name>" + item.Name + "</name>\n";
                productsOutput += "<count>" + item.Count+ "</count>\n";
                productsOutput += "<price>" + item.Price+ "</price>\n";
                productsOutput += "</product>\n";
            }
            productsOutput += "</products>";

            //sales xml
            string salesOutput = "";
            salesOutput += "<sales>\n";
            foreach (var item in Sale)
            {
                salesOutput += "<sale>\n";
                salesOutput += "<date>" + item.Date.ToLongDateString() + "</date>\n";
                salesOutput += "<sale>" + item.Sale + "</sale>\n";
                salesOutput += "<y_sale>" + item.Y_Sale+ "</y_sale>\n";
                salesOutput += "<m_sale>" + item.M_Sale + "</m_sale>\n";
                salesOutput += "</sale>\n";
            }
            salesOutput += "</sales>";

            //employee xml
            string employeeOutput = "";
            employeeOutput += "<employees>\n";
            foreach (var item in Employee)
            {
                employeeOutput += "<employees>\n";
                employeeOutput += "<name>" + item.Name + "</name>\n";
                employeeOutput += "<h_wage>" + item.H_Wage + "</h_wage>\n";
                employeeOutput += "<w_hour>" + item.W_Hour + "</w_hour>\n";
                employeeOutput += "<phone_num>" + item.Phone_num + "</phone_num>\n";
                employeeOutput += "</employees>\n";
            }
            employeeOutput += "</employees>";

            // work xml
            string worksOutput = "";
            worksOutput += "<works>\n";
            foreach (var item in Work)
            {
                worksOutput += "<works>\n";
                worksOutput += "<name>" + item.Name+ "</name>\n";
                worksOutput += "<working_h>" + item.Working_H+ "</working_h>\n";
                worksOutput += "<isworked>" + (item.IsWorked? 1 : 0) + "</isworked>\n";
                worksOutput += "</works>\n";
            }
            worksOutput += "</works>";

            //저장
            File.WriteAllText(@"./Product.xml", productsOutput);
            File.WriteAllText(@"./Sale.xml", salesOutput);
            File.WriteAllText(@"./Employee.xml", employeeOutput);
            File.WriteAllText(@"./Work.xml", worksOutput);
        }
    }
}
