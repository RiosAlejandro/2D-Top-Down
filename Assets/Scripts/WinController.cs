using UnityEngine;

public class WinController : MonoBehaviour
{
    [SerializeField] private float winDuration = 3f;

    void Start() 
    {
        Invoke(nameof(LoadMenu), winDuration);
    }

    private void LoadMenu() 
    {
        GameManager.Instance.LoadMenu();
    }
}
