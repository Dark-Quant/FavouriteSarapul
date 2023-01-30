using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class TourSelect : MonoBehaviour
{
    public List<Tour> tours;
    public GameObject listContent;
    public GameObject descriptionPanel;
    private void Awake()
    {
        foreach (Tour tour in tours)
        {
            GameObject elem = Instantiate(tour.prefabTourElement, new Vector3(0, 0), Quaternion.identity);
            elem.transform.SetParent(listContent.transform);
            elem.transform.Find("TourText").GetComponent<TextMeshProUGUI>().text = tour.title;
            elem.transform.Find("TourIcon").GetComponent<Image>().material.SetTexture("_MainTex", tour.image); 
            elem.GetComponent<Button>().onClick.AddListener(delegate
            {
                SelectTour(tour.id);
            });
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

    public void SelectTour(int id)
    {
        descriptionPanel.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>().text = tours[id].description;
    }
    [Serializable]
    public class Tour
    {
        public int id;
        public String title;
        public String description;
        public Texture image;
        public GameObject prefabTourElement;
        public Object model;
    }
}