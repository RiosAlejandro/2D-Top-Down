using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public void OnMenuPressed()
    {
        GameManager.Instance.LoadMenu();
    }
}
