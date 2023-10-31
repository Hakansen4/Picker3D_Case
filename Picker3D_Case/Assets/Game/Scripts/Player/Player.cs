using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Values")]
    [SerializeField]
    private float Speed;

    private PlayerMovement Movement;
    private void Awake()
    {
        Movement = new PlayerMovement(Speed, GetComponent<Rigidbody>(), transform);
    }
    private void OnEnable()
    {
        Movement.SubEvents();
    }
    private void OnDisable()
    {
        Movement.UnSubEvents();
    }
    private void FixedUpdate()
    {
        Movement?.Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        var Point = other.GetComponent<IPoint>();
        if (Point == null)
            return;

        Point.ReachedPoint();
    }
}
