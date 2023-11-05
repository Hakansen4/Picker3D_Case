using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class LimitBallHeight : MonoBehaviour
    {
        [SerializeField]
        private float _LimitValue;
        private void Update()
        {
            if (transform.position.y >= _LimitValue)
                transform.position = new Vector3(transform.position.x, _LimitValue, transform.position.z);

        }
    }
}