public class SimpleScriptAction
{
     [DeclareAction("MyScriptAction")]
     public void MyFunctionAsAction()
     {
           MessageBox.Show("MyFunctionAsAction() was called!", "SimpleScriptAction");

           return;
     }
}