using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPointHandler : MonoBehaviour
{
	public String title;
	public String description;
	public Texture image;
	public GameObject button;
	public GameObject panelDetail;

	private bool butIsHovered = false;
	private void Awake()
	{
		Events.onHover.AddListener(Use);
	}

	private void OnDestroy()
	{
		Events.onHover.RemoveListener(Use);
	}

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       button.SetActive(butIsHovered); 
    }

    
    
    void Use(GameObject gameObject)
    {
	    butIsHovered = true;
     	StopCoroutine(TimerForInactivate());
     	StartCoroutine(TimerForInactivate());
	    if (this.gameObject != gameObject && button.GetComponent<DetailButton>().ID == GetInstanceID())
        {
     		return;
     	}
	    button.GetComponent<DetailButton>().ID = GetInstanceID();
	    panelDetail.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title;
	    panelDetail.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description;
	    
    }
    
    IEnumerator TimerForInactivate()
    {
	    yield return new WaitForSecondsRealtime(0.5f);
	    butIsHovered = false;
    }
}
