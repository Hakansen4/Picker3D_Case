using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ambrosia.EventBus;

public class BlockController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _RangeText;


    [SerializeField] private int BallRange;
    [SerializeField] private float WaitTime;
    private void Awake()
    {
        _RangeText.text = BallRange.ToString();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
