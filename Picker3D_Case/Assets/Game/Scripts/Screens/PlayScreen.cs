using UnityEngine;

public class PlayScreen : ScreenBaseState
{
    private GameObject playScreen;
    public PlayScreen(GameObject screen)
    {
        playScreen = screen;
    }

    public override void OpenScreen(ScreenStateManager screen)
    {
        playScreen.SetActive(true);
    }

    public override void UpdateScreen(ScreenStateManager screen)
    {
    }
}
