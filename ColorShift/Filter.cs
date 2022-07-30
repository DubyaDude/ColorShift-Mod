using System;
using UnityEngine;

namespace ColorShift
{
	public class Filter : MonoBehaviour
	{
		public static Shader ChannelMixerShader;

		public bool forceRefresh = true;

		private Mode _mode = Mode.Normal;
		public Mode mode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
				forceRefresh = true;
			}
		}


		public bool showDifference = false;

		private Material material;

		public static Color[][] RGB = new Color[14][]
		{
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			},
			new Color[] {
				new Color(0.56667f, 0.43333f, 0f),
				new Color(0.55833f, 0.44167f, 0f),
				new Color(0f, 0.24167f, 0.75833f)
			},
			new Color[] {
				new Color(0.81667f, 0.18333f, 0f),
				new Color(0.33333f, 0.66667f, 0f),
				new Color(0f, 0.125f, 0.875f)
			},
			new Color[] {
				new Color(0.625f, 0.375f, 0f),
				new Color(0.7f, 0.3f, 0f),
				new Color(0f, 0.3f, 0.7f)
			},
			new Color[] {
				new Color(0.8f, 0.2f, 0f),
				new Color(0.25833f, 0.74167f, 0f),
				new Color(0f, 0.14167f, 0.85833f)
			},
			new Color[] {
				new Color(0.95f, 0.05f, 0f),
				new Color(0f, 0.43333f, 0.56667f),
				new Color(0f, 0.475f, 0.525f)
			},
			new Color[] {
				new Color(0.96667f, 0.03333f, 0f),
				new Color(0f, 0.73333f, 0.26667f),
				new Color(0f, 0.18333f, 0.81667f)
			},
			new Color[] {
				new Color(0.299f, 0.587f, 0.114f),
				new Color(0.299f, 0.587f, 0.114f),
				new Color(0.299f, 0.587f, 0.114f)
			},
			new Color[] {
				new Color(0.618f, 0.32f, 0.062f),
				new Color(0.163f, 0.775f, 0.062f),
				new Color(0.163f, 0.32f, 0.516f)
			},
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			},
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			},
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			},
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			},
			new Color[] {
				new Color(1f, 0f, 0f),
				new Color(0f, 1f, 0f),
				new Color(0f, 0f, 1f)
			}
		};

#if !MONO
		public Filter(IntPtr obj0) : base(obj0) { }
#endif

		private void Start()
		{
			RefreshMaterial(true);
		}

		private void RefreshMaterial(bool refresh = false)
		{
			if (material == null)
			{
				material = new Material(ChannelMixerShader);
				material.hideFlags = HideFlags.HideAndDontSave;
				forceRefresh = true;
			}
			if (forceRefresh || refresh)
			{
				material.SetColor("_R", RGB[(int)mode][0]);
				material.SetColor("_G", RGB[(int)mode][1]);
				material.SetColor("_B", RGB[(int)mode][2]);
			}
			forceRefresh = false;
		}


		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (mode == Mode.Normal)
			{
				Graphics.Blit(source, destination);
			}
			else
			{
				/*
				if (source == null)
					Console.WriteLine("source is null");
				if (destination == null)
					Console.WriteLine("destination is null");
				*/

				RefreshMaterial();
				Graphics.Blit(source, destination, material, showDifference ? 1 : 0);
			}
		}
	}
}
