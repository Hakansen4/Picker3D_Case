using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    private const float LockXAxis = 0;
    
    [Header("Camera Values")]
    [Header("Camera Follow")]
    [SerializeField]
    private Transform FollowObject;
    [SerializeField]
    private Vector3 Offset;

    private void LateUpdate()
    {
        Follow();
    }
    public void Follow()
    {
        transform.position = new Vector3(LockXAxis, FollowObject.position.y + Offset.y,
                                        FollowObject.position.z + Offset.z);
    }
}
