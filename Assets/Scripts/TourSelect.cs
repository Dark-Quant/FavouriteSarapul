using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

public class TourSelect : MonoBehaviour
{
    public List<Tour> tours;
    public GameObject listContent;
    public GameObject descriptionPanel;
    public GameObject prefabTourElement;
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/tours.save";
        Load();
        ReloadTours(); 
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateDescription(string slug)
    {
        foreach (var tour in tours)
        {
            if (!tour.slug.Equals(slug)) continue;
            descriptionPanel.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = tour.description;
            descriptionPanel.transform.Find("RunScene").GetComponent<Button>().onClick
                .AddListener(delegate { SelectTour(tour.nameScene); });
            break;
        }
    }

    public void SelectTour(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        bf.Serialize(fileStream, tours);
        fileStream.Close();
    }

    public void Load()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        tours = (List<Tour>)bf.Deserialize(fs);
        fs.Close();
    }

    public void ReloadTours()
    {
        foreach (var tour in tours)
        {
            GameObject elem = Instantiate(prefabTourElement, new Vector3(0, 0), Quaternion.identity);
            elem.transform.SetParent(listContent.transform);
            elem.transform.Find("TourText").GetComponent<TextMeshProUGUI>().text = tour.title;
            elem.transform.Find("TourIcon").GetComponent<Image>().material.SetTexture("_MainTex", tour.image);
            elem.GetComponent<Button>().onClick.AddListener(delegate { UpdateDescription(tour.slug); });
        }
    }
}