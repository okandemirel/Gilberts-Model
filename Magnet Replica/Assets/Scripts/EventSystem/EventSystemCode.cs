using System;
using UnityEngine;

public class EventSystemCode : MonoBehaviour
{
    public static EventSystemCode current;

    public void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
    }
    public event Action objectHitToHole;
    
    public void ObjectHitHole()
    {
        objectHitToHole?.Invoke();
    }
}
