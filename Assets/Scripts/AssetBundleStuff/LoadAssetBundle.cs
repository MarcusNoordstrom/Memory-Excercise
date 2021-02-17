using System.IO;
using UnityEngine;

namespace AssetBundleStuff {
    public class LoadAssetBundle : MonoBehaviour
    {
        public static GameObject Load (string fileName) {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine("Assets/AssetBundles", fileName));
        
            if (myLoadedAssetBundle == null) {
                Debug.Log("Failed to load AssetBundle!");
                return null;
            }
        
            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(fileName);
            return prefab;
        }
    }
}