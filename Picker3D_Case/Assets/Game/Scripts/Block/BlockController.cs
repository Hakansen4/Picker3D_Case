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

    [SerializeField] private int NeedBall;
    [SerializeField] private float WaitTime;
    private void Awake()
    {
        _RangeText.text = NeedBall.ToString();
    }

    public void StartCounting()
    {
        StartCoroutine(Count());
    }
    private IEnumerator Count()
    {
        yield return new WaitForSeconds(WaitTime);
        if(_CollectedBalls.GetBallCount() >= NeedBall)
        {
            _AnimationController.StartAnimate();
        }
        else
        {
            EventBus<Event_LevelFailed>.Emit(this, new Event_LevelFailed());
        }
    }

}
