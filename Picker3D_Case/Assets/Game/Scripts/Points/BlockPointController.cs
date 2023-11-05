using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Block;

namespace Point
{
    public class BlockPointController : MonoBehaviour, IPoint
    {
        [SerializeField] private BlockController _Controller;
        public void ReachedPoint()
        {
            EventBus<Event_CountBall>.Emit(this, new Event_CountBall());
            _Controller.StartCounting();
            gameObject.SetActive(false);
        }
    }
}