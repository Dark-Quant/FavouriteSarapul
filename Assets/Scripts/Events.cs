using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public class OnHoverEvent : UnityEvent<GameObject>
    {
        
    }

    public static OnHoverEvent onHover = new OnHoverEvent();
}
