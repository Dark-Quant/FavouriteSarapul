using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class TourSelect : MonoBehaviour
{
    public GameObject listContent;
    public GameObject descriptionPanel;
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
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

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
    }
}