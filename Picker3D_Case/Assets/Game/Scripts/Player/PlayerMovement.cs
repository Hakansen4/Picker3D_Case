using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CurrentSpeed = SpeedValue;
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
}
