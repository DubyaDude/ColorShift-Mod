using UnityEngine;

namespace ColorShift
{
    public static class Helper
    {
        public static void SetupMonobehaviour() { }
        
        public static void LoadAssetBundle()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.assets);
            if (assetBundle == null) return;
            UnityEngine.Object[] allAssets = assetBundle.LoadAllAssets();
            Filter.ChannelMixerShader = (Shader)allAssets[0];
        }
    }
}