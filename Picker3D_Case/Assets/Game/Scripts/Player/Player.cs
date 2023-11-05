using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerWorks
{
    public class Player : MonoBehaviour
    {
        [Header("Player Values")]
        [SerializeField]
        private float _Speed;

        private PlayerMovement movement;
        private void Awake()
        {
            movement = new PlayerMovement(_Speed, GetComponent<Rigidbody>(), transform);
        }
        private void OnEnable()
        {
            movement.SubEvents();
        }
        private void OnDisable()
        {
            movement.UnSubEvents();
        }
        private void FixedUpdate()
        {
            movement?.Move();
        }
        private void OnTriggerEnter(Collider other)
        {
            var Point = other.GetComponent<IPoint>();
            if (Point == null)
                return;

            Point.ReachedPoint();
        }
    }
}