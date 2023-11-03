using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ambrosia.EventBus;
using System;

public class BlockController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _RangeText;
    [SerializeField] private BlockCollectedBalls _CollectedBalls;
    [SerializeField] private BlockAnimationController _AnimationController;

    [SerializeField] private int BallRange;
    [SerializeField] private float WaitTime;
    private void Awake()
    {
        _RangeText.text = BallRange.ToString();
    }
    private void OnEnable()
    {
        EventBus<Event_CountBall>.AddListener(StartCount);
    }
    private void OnDisable()
    {
        EventBus<Event_CountBall>.RemoveListener(StartCount);
    }

    private void StartCount(object sender, Event_CountBall @event)
    {
        StartCoroutine(Count());
    }
    private IEnumerator Count()
    {
        yield return new WaitForSeconds(WaitTime);
        if(_CollectedBalls.GetBallCount() >= BallRange)
        {
            _AnimationController.StartAnimate();
        }
        else
        {
            EventBus<Event_LevelFailed>.Emit(this, new Event_LevelFailed());
        }
    }

}
