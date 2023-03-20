using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public float maxRayDistance = 10.0f;
    public LayerMask excludeLayers;
    private Ray ray;

    private void Awake()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
        {
            Events.onHover.Invoke(hit.transform.gameObject);
        } 
    }
}
