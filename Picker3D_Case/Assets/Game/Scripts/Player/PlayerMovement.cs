using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using System;
using Manager;

namespace PlayerWorks
{
    public class PlayerMovement
    {
        private const float moveRange = 3.7f;

        private Transform playerTransform;
        private Rigidbody playerRigidbody;
        private float speedValue;
        private float currentSpeed;
        private Vector3 movePosition;

        public PlayerMovement(float SpeedValue, Rigidbody PlayerRigidbody, Transform PlayerTransform)
        {
            this.speedValue = SpeedValue;
            currentSpeed = 0.0f;
            this.playerRigidbody = PlayerRigidbody;
            this.playerTransform = PlayerTransform;
        }

        public void Move()
        {
            movePosition = playerTransform.position + new Vector3(currentSpeed * InputManager.GetHorizontalValue() * Time.fixedDeltaTime,
                                                                0, currentSpeed * Time.fixedDeltaTime);
            movePosition.x = Mathf.Clamp(movePosition.x, -moveRange, moveRange);

            playerRigidbody.MovePosition(movePosition);
        }

        public void SubEvents()
        {
            EventBus<Event_CountBall>.AddListener(StopMovement);
            EventBus<Event_CountingEnded>.AddListener(ResumeMovement);
            EventBus<Event_StartGame>.AddListener(StartMovement);
            EventBus<Event_LevelPassed>.AddListener(EndMovement);
        }
        public void UnSubEvents()
        {
            EventBus<Event_CountBall>.RemoveListener(StopMovement);
            EventBus<Event_CountingEnded>.RemoveListener(ResumeMovement);
            EventBus<Event_StartGame>.RemoveListener(StartMovement);
            EventBus<Event_LevelPassed>.RemoveListener(EndMovement);
        }

        private void EndMovement(object sender, Event_LevelPassed @event)
        {
            currentSpeed = 0.0f;
        }

        private void StartMovement(object sender, Event_StartGame @event)
        {
            currentSpeed = speedValue;
        }

        private void ResumeMovement(object sender, Event_CountingEnded @event)
        {
            currentSpeed = speedValue;
        }

        private void StopMovement(object sender, Event_CountBall @event)
        {
            currentSpeed = 0.0f;
        }
    }
}