using Eplan.ConfigurationTools;
using Eplan.Framework.Common.Interfaces.DataAccess;
using Eplan.Framework.DataAccess.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.EplAddin.ManagerApp
{
    public partial class formMainWindow : Form
    {
        public formMainWindow()
        {
            InitializeComponent();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            var oracleConnection = ConfigurationManager.ConnectionStrings["OracleConnection"];

            if (oracleConnection != null)
                MessageBox.Show(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString, "Oracle Connection Info");
            else
                MessageBox.Show("There is no Oracle connection information defined!", "Oracle Connection Info");
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            IDBAccessor db = new OracleDBAccessor();

            db.ExecuteReader("select * from EMP");
        }

        private void btnLogging_Click(object sender, EventArgs e)
        {

        }

        private void formMainWindow_Load(object sender, EventArgs e)
        {
            Configuration configuration = ConfiguratuionHelper.GetConfiguration(string.Empty);
            ConfigurationSection oracleSection = configuration.GetSection("oracle.manageddataaccess.client");

            Configuration managerConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MessageBox.Show(managerConfiguration.FilePath, "Manager Configuration");

            string configFileName = ConfiguratuionHelper.GetExecutingAssemblyConfigFileName();
        }
    }
}
