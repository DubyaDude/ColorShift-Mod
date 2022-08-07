using System;
using MelonLoader;
using UnityEngine;

namespace ColorShift
{
	public class ColorShiftMod : MelonMod
	{
		#region Components
		private static Filter mainFilter;
		#endregion

		public override void OnApplicationStart()
		{
			Helper.SetupMonobehaviour();
			Config.Setup();
			OnPreferencesLoaded();
		}

		public override void OnPreferencesLoaded()
		{
			Filter.RGB[9] = Config.customs[0].Value;
			Filter.RGB[10] = Config.customs[1].Value;
			Filter.RGB[11] = Config.customs[2].Value;
			Filter.RGB[12] = Config.customs[3].Value;
			Filter.RGB[13] = Config.customs[4].Value;
			RefreshMainFilter();
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			if (mainFilter == null && Camera.main != null)
			{
				Config.Save();
				Helper.LoadAssetBundle();
				mainFilter = Camera.main.gameObject.AddComponent<Filter>();
				mainFilter.mode = Config.mainMode.Value;
				LoggerInstance.Msg("Filter Created");
			}
			RefreshMainFilter();
		}

		public override void OnLateUpdate()
		{
			if (mainFilter == null) return;

			if (Config.keybinds.Value)
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
			int total = Enum.GetNames(typeof(Mode)).Length;
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
			Config.mainMode.Value = mainFilter.mode;
			Config.mainMode.Save();
			Config.Save();
			//ResetCursed();
			LoggerInstance.Msg("Filter Mode: " + mainFilter.mode);
		}

		private void RefreshMainFilter()
		{
			if (mainFilter != null)
			{
				mainFilter.showDifference = Config.showDifference.Value;
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
