using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace ColorShift
{
	public class ColorShiftMod : MelonMod
	{
		#region Components
		private static Filter mainFilter;
		#endregion

		#region Consts
		private static int total = Enum.GetNames(typeof(Mode)).Length;
		private static Color[] normalColor = new Color[3] { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };
		#endregion

		#region Prefs
		private static MelonPreferences_Category category;
		private static MelonPreferences_Entry<Mode> mainMode;
		private static MelonPreferences_Entry<bool> keybinds;
		private static MelonPreferences_Entry<bool> showDifference;
		private static MelonPreferences_Entry<Color[]>[] customs = new MelonPreferences_Entry<Color[]>[5];
		#endregion

		public override void OnApplicationStart()
		{
			ClassInjector.RegisterTypeInIl2Cpp<Filter>();
			category = MelonPreferences.CreateCategory("ColorShift");
			mainMode = category.CreateEntry("MainCamMode", Mode.Normal);
			keybinds = category.CreateEntry("Keybinds", true);
			showDifference = category.CreateEntry("ShowDifference", false);

			customs[0] = category.CreateEntry("Custom1", normalColor);
			customs[1] = category.CreateEntry("Custom2", normalColor);
			customs[2] = category.CreateEntry("Custom3", normalColor);
			customs[3] = category.CreateEntry("Custom4", normalColor);
			customs[4] = category.CreateEntry("Custom5", normalColor);
			category.SaveToFile();
			OnPreferencesLoaded();
		}

		public override void OnPreferencesLoaded()
		{
			Filter.RGB[9] = customs[0].Value;
			Filter.RGB[10] = customs[1].Value;
			Filter.RGB[11] = customs[2].Value;
			Filter.RGB[12] = customs[3].Value;
			Filter.RGB[13] = customs[4].Value;
			RefreshMainFilter();
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			if (mainFilter == null && Camera.main != null)
			{
				AssetBundle assetBundle = AssetBundle.LoadFromMemory_Internal(Properties.Resources.assets, 0u);
				Il2CppReferenceArray<UnityEngine.Object> il2CppReferenceArray = assetBundle.LoadAllAssets();
				Filter.ChannelMixerShader = ((Il2CppObjectBase)(object)il2CppReferenceArray[0]).Cast<Shader>();
				mainFilter = Camera.main.gameObject.AddComponent<Filter>();
				mainFilter.mode = mainMode.Value;
				LoggerInstance.Msg("Filter Created");
			}
			RefreshMainFilter();
		}

		public override void OnLateUpdate()
		{
			if (keybinds.Value)
			{
				if (Input.GetKeyDown(KeyCode.M))
				{
					ChangeBy(1);
				}
				else if (Input.GetKeyDown(KeyCode.N))
				{
					ChangeBy(-1);
				}
			}
		}

		public void ChangeBy(int amount)
		{
			int num = (int)(mainFilter.mode + amount);
			if (num < 0)
			{
				num = total - 1;
			}
			else if (num > total - 1)
			{
				num = 0;
			}
			mainFilter.mode = (Mode)num;
			mainMode.Value = mainFilter.mode;
			mainMode.Save();
			category.SaveToFile();
			//ResetCursed();
			LoggerInstance.Msg("Filter Mode: " + mainFilter.mode);
		}

		private void RefreshMainFilter()
		{
			if (mainFilter != null)
			{
				mainFilter.showDifference = showDifference.Value;
				mainFilter.forceRefresh = true;
			}
		}


		// BPM 165
		// Each beat lasts 4/11 of a second (60/165)
		/*
		static float lengthOfBeat = (4f / 11f) * 2f;
		static float timeElapsed = 0f;
		static int colorArrayPos = 0;


		// Colors:
		public static Color[][] Cursed = new Color[3][]
		{
			new Color[] {
				new Color(0.7f,0f,0f),   new Color(0f,0.7f,0f), new Color(1f,1f,1f)
			},
			new Color[] {
				new Color(0.7f,0f,0f),   new Color(1f,1f,1f), new Color(0f,0f,0.7f)
			},
			new Color[] {
				new Color(1f,1f,1f),   new Color(0f,0.7f,0f), new Color(0f,0f,0.7f)
			},
		};

		//CurColor
		public static Color[] curColor = new Color[] { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };

		private static void ResetCursed()
		{
			timeElapsed = 0f;
			colorArrayPos = 0;
		}

		public override void OnUpdate()
		{
			if (mainMode.Value == Mode.Custom5)
			{
				if (timeElapsed < lengthOfBeat)
				{
					curColor[0] = Color.Lerp(curColor[0], Cursed[colorArrayPos][0], timeElapsed / lengthOfBeat);
					curColor[1] = Color.Lerp(curColor[1], Cursed[colorArrayPos][1], timeElapsed / lengthOfBeat);
					curColor[2] = Color.Lerp(curColor[2], Cursed[colorArrayPos][2], timeElapsed / lengthOfBeat);
					timeElapsed += Time.deltaTime;
				}
				else
				{
					timeElapsed = 0f;
					colorArrayPos++;
					if (colorArrayPos > Cursed.Length - 1)
					{
						colorArrayPos = 0;
					}
				}

				Filter.RGB[13] = curColor;
				RefreshMainFilter();

				timeElapsed += Time.deltaTime;
			}
		}
		*/
	}
}
