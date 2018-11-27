public class HHIRegisterMenuScript
{
	[DeclareMenu]
	public void RegisterHHICustomMenu()
	{
		string actionCommandSetGraphicElement = "XGedStartInteractionAction /Name:XGedIaFormatGraphic /width:-16002 /color:30 /type:41 /patternlength:4mm /lineendstyle:0 /visible:1 /filled:0 /rounded:1 /radius:2mm";
		string actionCommandPutMacro = "XGedStartInteractionAction /Name:XMIaInsertMacro /filename:\"D:\\Temp\\HHIMacro\\Basic training macro.ema\" /variant:0";
		
		Eplan.EplApi.Gui.Menu.MainMenuName helpMenu = Eplan.EplApi.Gui.Menu.MainMenuName.eMainMenuHelp;
		Eplan.EplApi.Gui.Menu hhiMenu = new Eplan.EplApi.Gui.Menu();
		
		uint menuId = hhiMenu.AddMainMenu("[HHI]", helpMenu, "그래픽 요소 설정", actionCommandSetGraphicElement, "그래픽 요소의 형식 설정...", 1);
		menuId = hhiMenu.AddMenuItem("매크로 삽입", actionCommandPutMacro, "매크로 삽입...", menuId, 1,  false, false);
	}
}


