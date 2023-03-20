using System.IO;
using UnityEditor;

public class SceneBundleCreator 
{
    [MenuItem("Utilities/Assets")]
    static void CreateAsset()
    {
        string path = "./Builds/Assets";
        if (!Directory.Exists(Path.GetFullPath(path)))
        {
            Directory.CreateDirectory(Path.GetFullPath(path));
        } 
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
