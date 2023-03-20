using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailButton : MonoBehaviour
{
    public GameObject panelDetail;
    
    private int Id = -1;
    public int ID
    {
        get
        {
            return Id;
        }

        set
        {
            Id = value;
        }
    }

    public void OpenDetail()
    {
    	panelDetail.SetActive(true);
    }

}
