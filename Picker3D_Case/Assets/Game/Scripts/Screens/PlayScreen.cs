using UnityEngine;
using Ambrosia.EventBus;
using DG.Tweening;
using System;
using UnityEngine.UI;
using TMPro;

namespace ScreenWorks
{
    public class PlayScreen : ScreenBaseState
    {
        private const string levelPlayerPref = "Level";
        private const float blockAnimScale = 1.2f;
        private const float blockAnimTime = 0.2f;

        private TextMeshProUGUI levelText;
        private TextMeshProUGUI nextLevelText;
        private Material greenColor;
        private GameObject playScreen;
        private Image[] blocks = new Image[3];
        private int index = 0;
        public PlayScreen(GameObject screen, Image[] Blocks, Material GreenColor, TextMeshProUGUI levelText, TextMeshProUGUI nextLevelText)
        {
            playScreen = screen;
            blocks = Blocks;
            greenColor = GreenColor;
            this.nextLevelText = nextLevelText;
            this.levelText = levelText;
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
            blocks[index].material = greenColor;
            blocks[index].rectTransform.DOScale(blockAnimScale, blockAnimTime).OnComplete(RewindBlockAnim);
            index++;
        }
        private void RewindBlockAnim()
        {
            blocks[index - 1].rectTransform.DOScale(1, blockAnimTime);
        }

        public override void CloseScreen(ScreenStateManager screen)
        {
            playScreen.SetActive(false);
        }

        public override void OpenScreen(ScreenStateManager screen)
        {
            playScreen.SetActive(true);
            int value = PlayerPrefs.GetInt(levelPlayerPref); value++;
            levelText.text = value.ToString(); value++;
            nextLevelText.text = value.ToString();
        }

        public override void UpdateScreen(ScreenStateManager screen)
        {
        }
    }
}