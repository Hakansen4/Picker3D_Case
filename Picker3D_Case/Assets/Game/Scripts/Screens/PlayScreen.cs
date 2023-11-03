using UnityEngine;
using Ambrosia.EventBus;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class PlayScreen : ScreenBaseState
{
    private const float BlockAnimScale = 1.2f;
    private const float BlockAnimTime = 0.2f;

    private Material greenColor;
    private GameObject playScreen;
    private Image[] blocks = new Image[3];
    private int Index = 0;
    public PlayScreen(GameObject screen, Image[] Blocks, Material GreenColor)
    {
        playScreen = screen;
        blocks = Blocks;
        greenColor = GreenColor;
    }
    public void SubEvents()
    {
        EventBus<Event_CountingEnded>.AddListener(BlockSucced);
    }
    public void UnSubEvents()
    {
        EventBus<Event_CountingEnded>.RemoveListener(BlockSucced);
    }

    private void BlockSucced(object sender, Event_CountingEnded @event)
    {
        blocks[Index].material = greenColor;
        blocks[Index].rectTransform.DOScale(BlockAnimScale, BlockAnimTime).OnComplete(RewindBlockAnim);
        Index ++;
    }
    private void RewindBlockAnim()
    {
        blocks[Index - 1].rectTransform.DOScale(1, BlockAnimTime);
    }

    public override void CloseScreen(ScreenStateManager screen)
    {
        playScreen.SetActive(false);
    }

    public override void OpenScreen(ScreenStateManager screen)
    {
        playScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {
    }
}
