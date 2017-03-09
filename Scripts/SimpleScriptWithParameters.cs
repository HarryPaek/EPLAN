public class SimpleScriptWithParameters
{
    [Start]
    public bool FunctionWithParameters(string Param1, string Param2, string Param3)
    {
        MessageBox.Show(string.Format("{0}\n{1} {2}", Param1, Param2, Param3), "SimpleScriptWithParameters");

        return true;
    }
}
