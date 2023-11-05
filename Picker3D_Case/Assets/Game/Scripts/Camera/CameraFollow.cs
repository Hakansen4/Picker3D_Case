using UnityEngine;

namespace Camera
{
    [ExecuteInEditMode]
    public class CameraFollow : MonoBehaviour
    {
        private const float lockXAxis = 0;

        [Header("Camera Values")]
        [Header("Camera Follow")]
        [SerializeField]
        private Transform _FollowObject;
        [SerializeField]
        private Vector3 _Offset;

        private void LateUpdate()
        {
            Follow();
        }
        public void Follow()
        {
            transform.position = new Vector3(lockXAxis, _FollowObject.position.y + _Offset.y,
                                            _FollowObject.position.z + _Offset.z);
        }
    }
}