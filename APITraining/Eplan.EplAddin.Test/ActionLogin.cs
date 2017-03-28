using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.ApplicationFramework;
using System.Windows.Forms;

namespace Eplan.EplAddin.Test
{
    class ActionLogin : IEplAction
    {
        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            MessageBox.Show("Login Action");
            return true;
        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {
            // throw new NotImplementedException();
        }

        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "ActionLogin";
            Ordinal = 88;
            return true;
        }
    }
}
