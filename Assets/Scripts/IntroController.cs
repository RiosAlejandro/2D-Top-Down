using System.Collections;
using TMPro;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private string[] storyLines;
    [SerializeField] private float typingSpeed = 0.05f;

    private int currentLine = 0; //controla que texto se esta mostrando
    private bool isTyping = false;

    private void Start()
    {
        storyText.text = "";
        StartCoroutine(TypeLine(storyLines[currentLine]));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        currentLine++; //incrementa índice

        if(currentLine >= storyLines.Length) //si se termino carga siguiente nivel
        {
            GameManager.Instance.LoadLevel();
            return;
        }

        StartCoroutine(TypeLine(storyLines[currentLine])); //si no se termino muestra siguiente línea de texto
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true; // evita que el jugador cort el texto a la mitad

        storyText.text += "\n\n"; //Agrega espacio entre parrafos

        foreach (char c in line) //Efecto de escritura typewriter
        {
            storyText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
