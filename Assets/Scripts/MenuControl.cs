using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tours;
    public GameObject settings;
    
    public void ToursButton()
    {
        mainMenu.SetActive(false);    
        tours.SetActive(true);
    }
}
