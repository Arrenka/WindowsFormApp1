using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using ExcelDataReader;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private SqlDataAdapter adapter1 = null;
        private DataTable table = null;
        private string fileName = string.Empty;
        private DataTableCollection datatablecollection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=DesctopDatadb;Trusted_Connection=True;");
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM OrgUnits", sqlConnection);
            adapter1 = new SqlDataAdapter("SELECT emp.[Name], dep.[Name], bu.[Name] FROM [inventorydb].[dbo].[OrgUnits] emp JOIN OrgUnits dep ON dep.id = emp.DepartmentId JOIN OrgUnits bu ON bu.id = dep.BusinessUnitId WHERE emp.DepartmentId is not null", sqlConnection);
            
            table = new DataTable();

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();
            adapter1.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();
            string s = textBox1.Text;
            int x = Convert.ToInt32(s);
            var f = Repository.FuturiesByEmployee(x);
            dataGridView1.DataSource = f;
        } 

        private void toolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();
            string s = textBox2.Text;
            int x = Convert.ToInt32(s);
            var f = Repository.FuturiesByDepartament(x);
            dataGridView1.DataSource = f;
        }

        private void toolStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            table.Clear();
            string s = textBox3.Text;
            int x = Convert.ToInt32(s);
            var f = Repository.FuturiesByBusinessUnitId(x);
            dataGridView1.DataSource = f;
        }

        #region Не удалось преобразовать в Excel, потому что версия .net core не поддерживает Microsoft office excel
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Excel.Application exApp = new Excel.Application();

        //    exApp.Workbooks.Add();
        //    Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
        //    int i, j;
        //    for (i = 0; i <= dataGridView1.RowCount-2; i++)
        //    {
        //        for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
        //        {
        //            wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
        //        }
        //    }

        //    exApp.Visible = true;
        //}
        #endregion
    }
}
