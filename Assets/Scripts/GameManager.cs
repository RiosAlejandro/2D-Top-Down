using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    //static-> Pertenece a la clase, no a una instancia(GameManager.Instance)- es global
    //GameManager -> permite el patron Singleton
    //El private en el set protege el singleton

    [SerializeField] private int lampsToWin = 4; //lamparas encedidas para ganar
    [SerializeField] private float winDelay = 2f; //tiempo delay despues de victoria

    private int currentLamps = 0; //lamparas encedidas inicialmente

    private void Awake()
    {
        if(Instance != null && Instance != this)//Destruye instancias si ya existe una, si no existe la convierte en instancia global
        {
            Destroy(gameObject);
            return;
        } 

        Instance = this;
        DontDestroyOnLoad(gameObject);
    } // esta instancia mantiene el estado global, controla el cambio de escenas y un conteo global
    //persistencia entre escenas

    private void OnEnable() //metodo de unity, se llama automaticamente cuando el gameObject se activa
    {
        EnergyCore.OnLampTurnedOn += HandleLampTurnedOn; //se suscribe al evento de las lamparas y ejecuta el método
        SceneManager.sceneLoaded += OnSceneLoaded; //SceneManager.sceneLoaded -> es un evento estatico //ejecutá el método OnSceneLoaded
    }

    private void OnDisable()//metodo de unity, se llama automaticamente cuando gameObject se desactiva, se destruye o la escena cambia
    {
        EnergyCore.OnLampTurnedOn -= HandleLampTurnedOn;// se desuscribe del evento(evita memory leaks)
        SceneManager.sceneLoaded -= OnSceneLoaded; //se desuscribe del evento
    }

    private void HandleLampTurnedOn() //Incrementa contador
    {
        currentLamps++;

        if(currentLamps >= lampsToWin) //si llega al limite, gana
        {
            StartCoroutine(WinDelay()); //Invocamos el coroutine
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //cada vez que se carga la escena resetea el contador de lamparas
    {
        if(scene.name == "Prueba2D")
        {
            currentLamps = 0;
        }
    }

    private IEnumerator WinDelay()//coroutine -> pausa la ejecución sin frenar el juego(no bloquea el hilo principal)
    {
        yield return new WaitForSeconds(winDelay); //espera los segundos establecidos
        LoadWin();// llama a la proxima escena
    }

    //Metodos navegacion

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Prueba2D");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
