using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using System;

namespace PlayerWorks
{
    public class CollectedBalls : MonoBehaviour
    {
        private const string ballTag = "Ball";

        [SerializeField]
        private Vector3 _ThrowPower;

        private List<Rigidbody> collectedBallList;
        private void Awake()
        {
            collectedBallList = new List<Rigidbody>();
        }
        private void OnEnable()
        {
            EventBus<Event_CountBall>.AddListener(ThrowBalls);
        }
        private void OnDisable()
        {
            EventBus<Event_CountBall>.RemoveListener(ThrowBalls);
        }

        private void ThrowBalls(object sender, Event_CountBall @event)
        {
            foreach (var ball in collectedBallList)
            {
                ball.AddForce(_ThrowPower);
            }
            collectedBallList.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ballTag))
                collectedBallList.Add(other.GetComponent<Rigidbody>());
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(ballTag))
                collectedBallList.Remove(other.GetComponent<Rigidbody>());
        }
    }
}