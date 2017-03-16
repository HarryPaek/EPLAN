public class RegisterScriptMenu
{
	[DeclareAction("MyScriptActionWithMenu")]
    public void MyFunctionAsAction()
    {
        MessageBox.Show("MyFunctionAsAction() was called!", "RegisterScriptMenu");
		
		String strAction = "FirstAction";
		
		ActionManager oAMnr= new ActionManager();
		Eplan.EplApi.ApplicationFramework.Action oAction= oAMnr.FindAction(strAction);
		
		if (oAction != null) {
			ActionCallingContext ctx = new ActionCallingContext();
			
            String strParamValue = "Param1 Value";
            ctx.AddParameter("Param1", strParamValue);

			bool bRet=oAction.Execute(ctx);
			
			if (bRet) {
				String strReturnValue = null;
				ctx.GetParameter("ReturnParam", ref strReturnValue);
				
				MessageBox.Show(string.Format("The Action {0} ended successfully with Return Value = [{1}]", strAction, strReturnValue), "MyFunctionAsAction");
			}
			else
				MessageBox.Show("The Action " + strAction + " ended with errors!", "MyFunctionAsAction");
        }
		else 
    		MessageBox.Show("The Action " + strAction + " not found!", "MyFunctionAsAction");

	    return;
    }
	
	[DeclareMenu]
	public void RegisterMenu()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("MyMenuText", "MyScriptActionWithMenu");
		oMenu.AddMenuItem("FirstAddinText", "FirstAction");
	}
}
