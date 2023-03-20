using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform target;

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Intel");
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.position = target.position;
        }
    }
}
