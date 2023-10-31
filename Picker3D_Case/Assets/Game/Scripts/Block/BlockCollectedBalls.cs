using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockCollectedBalls : MonoBehaviour
{
    private const string BallTag = "Ball";

    [SerializeField]
    private TextMeshProUGUI _BallCountText;

    private int BallCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(BallTag))
        {
            BallCount++;
            _BallCountText.text = BallCount.ToString();
        }
    }

    public int GetBallCount()
    {
        return BallCount;
    }
}
