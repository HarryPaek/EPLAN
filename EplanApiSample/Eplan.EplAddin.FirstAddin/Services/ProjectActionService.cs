using Eplan.EplAddin.FirstAddin.Abstracts;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using System;
using System.Windows.Forms;

namespace Eplan.EplAddin.FirstAddin.Services
{
    public class ProjectActionService : IActionService
    {
        public ProjectActionService()
        {
        }

        #region IActionService Implementation

        public void Execute()
        {
            MessageBox.Show("ProjectActionService Execute() was called!");

            ProjectManager manager = new ProjectManager();
            Project project = manager.CurrentProject;

            if (project == null) {
                MessageBox.Show("No Currnet Project!");
                return;
            }

            string[] locations = project.GetLocations(Project.Hierarchy.Functional);
            Location[] locationObjects = project.GetLocationObjects(Project.Hierarchy.Functional);

            ProjectSettings projectSettings = new ProjectSettings(project);

            ProjectSchemeSetting projectSchemeSetting = new ProjectSchemeSetting();

            Settings settings = new Settings();

            String strGuiLanguage = settings.GetStringSetting("USER.SYSTEM.GUI.LANGUAGE", 0);
            MessageBox.Show("The user interface language is set to: " + strGuiLanguage);
        }

        #endregion
    }
}
