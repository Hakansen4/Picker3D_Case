using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using System;

public class CollectedBalls : MonoBehaviour
{
    private const string BallTag = "Ball";

    [SerializeField]
    private Vector3 _ThrowPower;

    private List<Rigidbody> CollectedBallList;
    private void Awake()
    {
        CollectedBallList = new List<Rigidbody>();
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
        foreach (var ball in CollectedBallList)
        {
            ball.AddForce(_ThrowPower);
        }
        CollectedBallList.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BallTag))
            CollectedBallList.Add(other.GetComponent<Rigidbody>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(BallTag))
            CollectedBallList.Remove(other.GetComponent<Rigidbody>());
    }
}
