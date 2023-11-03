using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCustomGravity : MonoBehaviour
{
    private const float NewGravity = 3.0f;
    private const float GlobalGravity = -9.81f;

    [SerializeField]
    private Rigidbody _Rigidbody;
    private void Awake()
    {
        _Rigidbody.useGravity = false;
    }
    private void FixedUpdate()
    {
        UseCustomGravity();
    }
    private void UseCustomGravity()
    {
        Vector3 gravity = GlobalGravity * NewGravity * Vector3.up;
        _Rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}
