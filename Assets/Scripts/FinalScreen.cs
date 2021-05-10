using UnityEngine;
using System.Collections;

public class FinalScreen : MonoBehaviour
{
    public void RestartButton()
    {
        GameController.INSTANCE.RestartLevel();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
