using Eplan.ConfigurationTools;
using Eplan.Framework.Common.Interfaces.DataAccess;
using Eplan.Framework.DataAccess.Excel;
using Eplan.Framework.DataAccess.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.EplAddin.ManagerApp
{
    public partial class formMainWindow : Form
    {
        public formMainWindow()
        {
            InitializeComponent();
            // Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            // Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            var ConnectionStrings = ConfiguratuionHelper.GetConfiguration(string.Empty).ConnectionStrings;

            if(ConnectionStrings != null && ConnectionStrings.ConnectionStrings["OracleConnection"] != null)
                MessageBox.Show(string.Format("Oracle Connection Definition = [{0}]", ConnectionStrings.ConnectionStrings["OracleConnection"].ConnectionString), "Oracle Connection Info");
            else
                MessageBox.Show("There is no Oracle connection information defined!", "Oracle Connection Info");
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            IDBAccessor db = new OracleDBAccessor("DBConnection");

            var result = db.ExecuteReader("select * from EMP");
        }

        private void btnLogging_Click(object sender, EventArgs e)
        {

        }

        private void formMainWindow_Load(object sender, EventArgs e)
        {
            Configuration configuration = ConfiguratuionHelper.GetConfiguration(string.Empty);
            ConfigurationSection oracleSection = configuration.GetSection("oracle.manageddataaccess.client");

            MessageBox.Show(string.Format("Config File Path = [{0}]", ConfiguratuionHelper.GetCustomConfigFilePath()), "Custom Configuration File Path");

            string configFileName = ConfiguratuionHelper.GetExecutingAssemblyConfigFileName();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            IDBAccessor db = new ExcelDBAccessor("ExcelConnection");

            var resultEmp = db.ExecuteReader("SELECT * FROM [EMP$]");
            var resultDept = db.ExecuteReader("select * from [DEPT$]");
            var resultEmpDept = db.ExecuteReader("SELECT e.*, d.DNAME, d.LOC FROM [EMP$] e INNER JOIN [DEPT$] d ON e.DEPTNO = d.DEPTNO");
        }
    }
}
