using UnityEngine;

public class SplashController : MonoBehaviour
{

    [SerializeField] private float splashDuration = 3f;

    void Start()
    {
        Invoke(nameof(LoadMenu), splashDuration);
    }

    private void LoadMenu()
    {
        GameManager.Instance.LoadMenu();
    }

}
