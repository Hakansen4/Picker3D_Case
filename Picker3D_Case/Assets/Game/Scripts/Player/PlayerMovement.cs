using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using System;

public class PlayerMovement
{
    private const float MoveRange = 3.7f;

    private Transform PlayerTransform;
    private Rigidbody PlayerRigidbody;
    private float SpeedValue;
    private float CurrentSpeed;
    private Vector3 MovePosition;

    public PlayerMovement(float SpeedValue, Rigidbody PlayerRigidbody, Transform PlayerTransform)
    {
        this.SpeedValue = SpeedValue;
        CurrentSpeed = 0.0f;
        this.PlayerRigidbody = PlayerRigidbody;
        this.PlayerTransform = PlayerTransform;
    }

    public void Move()
    {
        MovePosition = PlayerTransform.position + new Vector3(CurrentSpeed * InputManager.GetHorizontalValue() * Time.fixedDeltaTime,
                                                            0, CurrentSpeed * Time.fixedDeltaTime);
        MovePosition.x = Mathf.Clamp(MovePosition.x, -MoveRange, MoveRange);

        PlayerRigidbody.MovePosition(MovePosition);
    }

    public void SubEvents()
    {
        EventBus<Event_CountBall>.AddListener(StopMovement);
        EventBus<Event_CountingEnded>.AddListener(ResumeMovement);
        EventBus<Event_StartGame>.AddListener(StartMovement);
    }
    public void UnSubEvents()
    {
        EventBus<Event_CountBall>.RemoveListener(StopMovement);
        EventBus<Event_CountingEnded>.RemoveListener(ResumeMovement);
        EventBus<Event_StartGame>.RemoveListener(StartMovement);
    }

    private void StartMovement(object sender, Event_StartGame @event)
    {
        CurrentSpeed = SpeedValue;
    }

    private void ResumeMovement(object sender, Event_CountingEnded @event)
    {
        CurrentSpeed = SpeedValue;
    }

    private void StopMovement(object sender, Event_CountBall @event)
    {
        CurrentSpeed = 0.0f;
    }
}
