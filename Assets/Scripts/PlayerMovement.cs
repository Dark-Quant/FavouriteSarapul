using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public FixedJoystick fixedJoystick;

    private float horizontal;
    private float vertical;
    private Transform mainCamera;
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Mathf.Lerp(horizontal, fixedJoystick.Horizontal, Time.deltaTime * 3);
        // vertical = Mathf.Lerp(vertical, fixedJoystick.Vertical, Time.deltaTime * 3);

        float h = fixedJoystick.Horizontal, v = fixedJoystick.Vertical;

        Debug.Log("V " + v);
        Debug.Log("H " + h);
        
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0f;
        camR.y = 0f;

        Vector3 movingVector = h * camR.normalized + v * camF.normalized;

        rig.velocity = movingVector * speed;
    }
}
