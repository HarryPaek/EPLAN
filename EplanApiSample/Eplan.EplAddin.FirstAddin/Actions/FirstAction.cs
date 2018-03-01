using System;
using Eplan.EplApi.ApplicationFramework;

namespace Eplan.EplAddin.FirstAddin.Actions
{

    /// <summary>
    /// This class implements a EPLAN action.  The Action will register the Addins in that  <seealso cref="IEplAddIn.OnRegister"/> Registerst.
    /// <seealso cref="Eplan::EplApi::ApplicationFramework::IEplAction"/> 
    /// </summary>
    public class FirstAction : IEplAction, IEplActionEnable
    {
        #region IEplAction Members

        /// <summary>
        /// Execution of the Action.  
        /// </summary>
        /// <returns>True:  Execution of the Action was successful</returns>
        public bool Execute(ActionCallingContext ctx)
        {
            String strParamValue = null;
            ctx.GetParameter("Param1", ref strParamValue);

            // use string parameter ...
            // Add code
            System.Windows.Forms.MessageBox.Show("FirstAction was called!" );


            // fill parameter "ReturnParam" with value "return value".
            // the caller of this action can extract the parameter by ctx.getParameter("ReturnParam", ...)
            String strReturnValue = "Return Value";
            ctx.AddParameter("ReturnParam", strReturnValue);

            return true;
        }
        /// <summary>
        /// Function is called through the ApplicationFramework
        /// </summary>
        /// <param name="Name">Under this name, this Action in the system is registered</param>
        /// <param name="Ordinal">With this overload priority, this Action is registered</param>
        /// <returns>true: the return parameters are valid</returns>
        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "FirstAction";
            Ordinal = 20;
            return true;
        }

        /// <summary>
        /// Documentation function for the Action; is called of the system as required 
        /// Bescheibungstext delivers for the Action itself and if the Action String-parameters ("Kommandozeile")
        /// also name and description of the single parameters evaluates
        /// </summary>
        /// <param name="actionProperties"> This object must be filled with the information of the Action.</param>
        public void GetActionProperties(ref ActionProperties actionProperties)
        {
            // Description 1st parameter
            ActionParameterProperties firstParam = new ActionParameterProperties();
            firstParam.Set("1. Parameter for FirstAction");
            actionProperties.AddParameter(firstParam);

            // Description 2nd parameter
            ActionParameterProperties secondParam = new ActionParameterProperties();
            secondParam.Set("2. Parameter for FirstAction");
            actionProperties.AddParameter(secondParam);
        }

        #endregion

        #region IEplActionEnable Members

        public bool Enabled(string strActionName, ActionCallingContext actionContext)
        {
            if (strActionName == "TESTACTION")
                return false;
            else
                return true;
        }

        #endregion
    }
}
