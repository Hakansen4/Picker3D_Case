using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;

namespace Block
{
    public class BlockAnimationController : MonoBehaviour
    {
        private const float groundMovePositions = 0.0f;
        private Vector3 leftDoorRotate = new Vector3(0, 90, 90);
        private Vector3 rightDoorRotate = new Vector3(0, -90, -90);

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
            _Ground.DOMoveY(groundMovePositions, _AnimationTime).SetEase(Ease.OutBack).OnComplete(AnimateDoors);
        }
        private void AnimateDoors()
        {
            _LeftDoor.DORotate(leftDoorRotate, _AnimationTime);
            _RightDoor.DORotate(rightDoorRotate, _AnimationTime).OnComplete(AnimationEnded);
        }
        private void AnimationEnded()
        {
            EventBus<Event_CountingEnded>.Emit(this, new Event_CountingEnded());
        }
    }
}