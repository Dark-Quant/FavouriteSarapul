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
    public GameObject listContent;
    public GameObject descriptionPanel;
<<<<<<< HEAD
    public GameObject prefabTourElement;
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/tours.save";
        Load();
        ReloadTours(); 
=======
    public List<Tour> tours;

    private void Awake()
    {
        foreach (Tour tour in tours)
        {
            GameObject elem = Instantiate(tour.prefabTourElement, new Vector3(0, 0), Quaternion.identity);
            elem.transform.SetParent(listContent.transform);
            elem.transform.Find("TourText").GetComponent<TextMeshProUGUI>().text = tour.title;
            elem.GetComponent<Button>().onClick.AddListener(delegate { SelectTour(tour.id); });
        }
>>>>>>> 3955204facf8408c8af623ae95f4b436a62d7d50
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

<<<<<<< HEAD
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
=======
    private void SelectTour(int id)
    {
        descriptionPanel.transform.Find("LocationButton").GetComponent<Button>().onClick.AddListener(delegate
        {
            SetLocation(tours[id].latitude, tours[id].longitude);
        });
        descriptionPanel.transform.Find("DescriptionImage").GetComponent<Image>().material
            .SetTexture("_MainTex", tours[id].image);
        descriptionPanel.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = tours[id].description;
    }

    void SetLocation(double latitude, double longitude)
    {
        String url = "geo:" + latitude + "," + longitude;
        Application.OpenURL(url);
    }

    [Serializable]
    public class Tour
    {
        public int id;
        public String title;
        public String description;
        public Texture image;
        public GameObject prefabTourElement;
        public double longitude;
        public double latitude;
        public Object model;
>>>>>>> 3955204facf8408c8af623ae95f4b436a62d7d50
    }
}