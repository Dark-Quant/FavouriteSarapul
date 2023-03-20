using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject tours;

    private void Start()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        tours.SetActive(false);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        tours.SetActive(false);
    }

    public void OpenTours()
    {
        menu.SetActive(false);
        settings.SetActive(false);
        tours.SetActive(true);
    }
}