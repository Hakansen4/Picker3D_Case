using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;

public class BlockAnimationController : MonoBehaviour
{
    private const float GroundMovePositions = 0.0f;
    private Vector3 LeftDoorRotate = new Vector3(0, 90, 90);
    private Vector3 RightDoorRotate = new Vector3(0, -90, -90);

    [SerializeField]
    private Transform _Ground;
    [SerializeField]
    private Transform _LeftDoor;
    [SerializeField]
    private Transform _RightDoor;
    [SerializeField]
    private float _AnimationTime;
    public void StartAnimate()
    {
        _Ground.DOMoveY(GroundMovePositions, _AnimationTime).SetEase(Ease.OutBack).OnComplete(AnimateDoors);
    }
    private void AnimateDoors()
    {
        _LeftDoor.DORotate(LeftDoorRotate, _AnimationTime);
        _RightDoor.DORotate(RightDoorRotate, _AnimationTime).OnComplete(AnimationEnded);
    }
    private void AnimationEnded()
    {
        EventBus<Event_CountingEnded>.Emit(this, new Event_CountingEnded());
    }
}
