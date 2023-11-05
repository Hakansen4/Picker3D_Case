using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class BallCustomGravity : MonoBehaviour
    {
        private const float newGravity = 3.0f;
        private const float globalGravity = -9.81f;

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
            Vector3 gravity = globalGravity * newGravity * Vector3.up;
            _Rigidbody.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}