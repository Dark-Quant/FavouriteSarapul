using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YandexMaps;

public class MapHandler : MonoBehaviour
{
    public RawImage image;
    public Map.TypeMap typeMap;
    public Map.TypeMapLayer typeMapLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadMap();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadMap()
    {
        Map.EnabledLayer = true;
        Map.Size = 4;
        Map.SetTypeMap = typeMap;
        Map.SetTypeMapLayer = typeMapLayer;
        Map.LoadMap();
        StartCoroutine(LoadTexture());
    }

    IEnumerator LoadTexture()
    {
        yield return new WaitForSeconds(1F);
        image.texture = Map.GetTexture;
    }
}
