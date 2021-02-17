using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor {
    public class AssetBundleBuild : MonoBehaviour
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            string assetBundleDirectory = "Assets/AssetBundles";
            if(!Directory.Exists(assetBundleDirectory))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
