using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

public class BlockPointController : MonoBehaviour, IPoint
{
    public void ReachedPoint()
    {
        EventBus<Event_CountBall>.Emit(this, new Event_CountBall());
        gameObject.SetActive(false);
    }
}
