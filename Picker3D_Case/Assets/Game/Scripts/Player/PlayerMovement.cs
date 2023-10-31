using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Transform PlayerTransform;
    private Rigidbody PlayerRigidbody;
    private float SpeedValue;
    private float CurrentSpeed;

    public PlayerMovement(float SpeedValue, Rigidbody PlayerRigidbody, Transform PlayerTransform)
    {
        this.SpeedValue = SpeedValue;
        CurrentSpeed = SpeedValue;
        this.PlayerRigidbody = PlayerRigidbody;
        this.PlayerTransform = PlayerTransform;
    }

    public void Move()
    {
        PlayerRigidbody.MovePosition(PlayerTransform.position + new Vector3(0, 0, CurrentSpeed * Time.fixedDeltaTime));
    }
}
