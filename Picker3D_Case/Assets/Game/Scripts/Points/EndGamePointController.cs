using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

namespace Point
{
    public class EndGamePointController : MonoBehaviour, IPoint
    {
        public void ReachedPoint()
        {
            EventBus<Event_LevelPassed>.Emit(this, new Event_LevelPassed());
        }
    }
}