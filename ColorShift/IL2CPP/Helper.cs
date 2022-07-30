using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace ColorShift
{
    public static class Helper
    {
        public static void SetupMonobehaviour()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Filter>();
        }
        
        public static void LoadAssetBundle()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromMemory_Internal(Properties.Resources.assets, 0u);
            Il2CppReferenceArray<UnityEngine.Object> il2CppReferenceArray = assetBundle.LoadAllAssets();
            Filter.ChannelMixerShader = ((Il2CppObjectBase)(object)il2CppReferenceArray[0]).Cast<Shader>();
        }
    }
}