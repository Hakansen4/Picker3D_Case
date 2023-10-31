using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedBalls : MonoBehaviour
{
    private const string BallTag = "Ball";

    private List<Rigidbody> CollectedBallList;
    private void Awake()
    {
        CollectedBallList = new List<Rigidbody>();
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
