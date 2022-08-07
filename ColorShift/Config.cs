using MelonLoader;
using UnityEngine;

namespace ColorShift
{
	public static class Config
	{
		public static MelonPreferences_Category category;
		public static MelonPreferences_Entry<Mode> mainMode;
		public static MelonPreferences_Entry<bool> keybinds;
		public static MelonPreferences_Entry<bool> showDifference;
		public static MelonPreferences_Entry<Color[]>[] customs = new MelonPreferences_Entry<Color[]>[5];


		private static Color[] normalColor = new Color[3] { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };

		public static void Setup()
		{
			category = MelonPreferences.CreateCategory("ColorShift");
			mainMode = category.CreateEntry("MainCamMode", Mode.Normal);
			keybinds = category.CreateEntry("Keybinds", true);
			showDifference = category.CreateEntry("ShowDifference", false);

			customs[0] = category.CreateEntry("Custom1", normalColor);
			customs[1] = category.CreateEntry("Custom2", normalColor);
			customs[2] = category.CreateEntry("Custom3", normalColor);
			customs[3] = category.CreateEntry("Custom4", normalColor);
			customs[4] = category.CreateEntry("Custom5", normalColor);
		}

		public static void Save()
		{
			category.SaveToFile(false);
		}
	}
}
