using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnPlayPressed()
    {
        GameManager.Instance.LoadIntro();
    }

    public void OnTutorialPressed()
    {
        GameManager.Instance.LoadTutorial();
    }

    public void OnQuitPressed()
    {
        GameManager.Instance.QuitGame();
    }
}
