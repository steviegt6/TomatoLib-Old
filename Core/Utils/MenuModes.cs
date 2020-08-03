namespace TomatoLib.Core.Utils
{
    public static class MenuModes
    {
		public enum MenuMode
		{
			//Vanilla
			None = -1,
			Main = 0,
			PlayerSelection = 1,
			PlayerCreation = 2,
			PlayerCreationCharacterName = 3,
			WorldSelection = 6,
			WorldLoading = 10,
			Settings = 11,
			Multiplayer = 12,
			EnterIPAddress = 13,
			StartingServer = 14,
			PlayerCreationHair = 17,
			PlayerCreationEyes = 18,
			PlayerCreationSkin = 19,
			PlayerCreationClothes = 20,
			PlayerCreationClothesShirt = 21,
			PlayerCreationClothesUndershirt = 22,
			PlayerCreationClothesPants = 23,
			PlayerCreationClothesShoes = 24,
			CursorColorSettings = 25,
			VolumeSettings = 26,
			ParallaxSetting = 28,
			MultiplayerHostAndPlayPassword = 30,
			ResolutionSetting = 111,
			GeneralSettings = 112,
			ENterServerPort = 131,
			PlayerCreationDifficulty = 222,
			CursorBorderColorSettings = 252,
			FancyUI = 888,
			MultiplayerHostAndPlaySettings = 889,
			VideoSettings = 1111,
			InterfaceSettings = 1112,
			CursorSettings = 1125,
			ControlsSettings = 1127,
			LanguageSettings = 1213,
			VideoEffectsSettings = 2008,

			//tModLoader
			Mods = 10000,
			ModSources = 10001,
			LoadingMods = 10002,
			BuildingMods = 10003,
			ErrorMessage = 10005,
			ReloadingMods = 10006,
			ModBrowser = 10007,
			ModInfo = 10008,
			DownloadMod = 10009,
			ModControls = 10010,
			ManagePublished = 10011,
			UpdateMessage = 10012,
			InfoMessage = 10013,
			EnterPassphraseMenu = 10015,
			ModPacks = 10016,
			TModLoaderSettings = 10017,
			EnterSteamIDMenu = 10018,
			ExtractMod = 10019,
			ModDownloadProgress = 10020,
			DeveloperModeHelp = 10022,
			Progress = 10023,
			ModConfig = 10024,
			CreateMod = 10025,
			Exit = 10026,
		}

		public static MenuMode GetMenuModeEnum(int menuMode) => (MenuMode)menuMode;
	}
}
