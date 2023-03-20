using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CameraControllPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform player;
    public CinemachineVirtualCamera cvc;
    public float sensitivity;
    public float minimumAngle;
    public float maximumAngle;
    
    private bool isPressed;
    private int fingerId;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once     per frame
    void Update()
    {
        if (isPressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == fingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        player.rotation *= Quaternion.AngleAxis(-touch.deltaPosition.y * sensitivity, Vector3.right);
                        player.rotation *= Quaternion.AngleAxis(touch.deltaPosition.x * sensitivity, Vector3.up);

                        float angleX = player.localEulerAngles.x;
                        if (angleX > 180 && angleX < maximumAngle)
                        {
                            angleX = maximumAngle;
                        } 
                        else if (angleX < 180 && angleX > minimumAngle)
                        {
                            angleX = minimumAngle;
                        }

                        player.localEulerAngles = new Vector3(angleX, player.localEulerAngles.y, 0);
                    }
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            isPressed = true;
            fingerId = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        cvc.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
        cvc.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
    }
}
