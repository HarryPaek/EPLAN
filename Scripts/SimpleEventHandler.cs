public class SimpleEventHandler
{
    [DeclareEventHandler("onMainStart")]
    public void OnMainStartEventHandlerFunction()
    {
        MessageBox.Show("OnMainStartEventHandlerFunction() was called!", "SimpleEventHandler");

        return;
    }
	
	[DeclareEventHandler("onActionStart.String.*")]
    public long OnActionStartStringEventHandlerFunction(IEventParameter iEventParameter)
    {
        try {
			EventParameterString eventParameterString = new EventParameterString(iEventParameter);
			string actionName = eventParameterString.String;
			
			MessageBox.Show("Action " + actionName + " was started!", "SimpleEventHandler");
		}
		catch (InvalidCastException  exc) {
			String strExc = exc.Message;
			
			MessageBox.Show("Parameter Error: " + strExc, "SimpleEventHandler");
		}

        return 0; 
    }
}
