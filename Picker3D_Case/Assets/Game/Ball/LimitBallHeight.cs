using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBallHeight : MonoBehaviour
{
    [SerializeField]
    private float LimitValue;

    private void Update()
    {
        if (transform.position.y >= LimitValue)
            transform.position = new Vector3(transform.position.x, LimitValue, transform.position.z);
    }
}
