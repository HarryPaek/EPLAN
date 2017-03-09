public class RegisterScriptMenu
{
	[DeclareAction("MyScriptActionWithMenu")]
    public void MyFunctionAsAction()
    {
        MessageBox.Show("MyFunctionAsAction() was called!", "RegisterScriptMenu");

	    return;
    }
	
	[DeclareMenu]
	public void RegisterMenu()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("MyMenuText", "MyScriptActionWithMenu");
	}
}
