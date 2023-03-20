using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class AssetsLoad : MonoBehaviour
{
    public string host;
    public TourSelect tourSelect;
    public Texture defaultImage;
    [SerializeField] private Dictionary<string, Tour> scenes;
    private static DateTime lastUpdate = new DateTime(2000, 10, 10);


    private void Start()
    {
        StartCoroutine(GetListScene());
    }

    public void OnClick()
    {
        StartCoroutine(GetListScene());
    }

    private IEnumerator DownloadsScenes(string s)
    {
        Debug.Log("Downloads scenes");
        var dict = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(s);
        Debug.Log(dict.ToString());
        foreach (Dictionary<string, string> element in dict)
        {
            DateTime curUpdate = DateTime.ParseExact(element["last_update"].Split('.')[0], "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);
            if (DateTime.Compare(lastUpdate, curUpdate) < 0)
            {
                Debug.Log("Statr");
                yield return GetScene(element["slug"]);
                Debug.Log("Done");
            }
        }
    }

    IEnumerator GetScene(string slug)
    {
        var request = UnityWebRequest.Get(host + "/scene/" + slug + "/");
		Debug.Log(host + "/scene/" + slug + "/");
        yield return request.SendWebRequest();
		Debug.Log("Request done!");
        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.downloadHandler.text);
        request.Dispose();
        var www = UnityWebRequestAssetBundle.GetAssetBundle(host + dict["file"]);
        yield return www.SendWebRequest();
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(www);
        string nameScene = Path.GetFileNameWithoutExtension(assetBundle.GetAllScenePaths()[0]);
        Debug.Log(nameScene);
        tourSelect.tours.Add(new Tour(slug, int.Parse(dict["version"]), dict["name"], dict["description"],
            null, nameScene));
        tourSelect.ReloadTours();
        Debug.Log(tourSelect.tours.Count);
    }

    IEnumerator GetListScene()
    {
        string url = host + "/scenes/";
		Debug.Log("GetListScene " + url);
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (!request.isHttpError && !request.isNetworkError)
        {
            yield return DownloadsScenes(request.downloadHandler.text);
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
        }

        request.Dispose();
    }

    IEnumerator LoadScene()
    {
        while (!Caching.ready)
        {
            yield return null;
        }

        // var www = WWW.LoadFromCacheOrDownload(url, version);
        // yield return www;

        // if (!string.IsNullOrEmpty(www.error))
        // {
        // Debug.LogWarning(www.error);
        yield break;
        // }
    }
}
