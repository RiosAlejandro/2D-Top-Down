using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnergyCore : MonoBehaviour, IInteractable //vive en la escena y reacciona a la interaccion
{
    public static event Action OnLampTurnedOn; //Creo el evento

    [SerializeField] private Light2D lampLight;

    private bool isOn = false;

    public void Interact()
    {
        /*Debug.Log("Interacting");

        if (lampLight == null)
        {
            Debug.LogError("LampLight is NULL");
            return;
        }*/
        //Debug.Log("Interacting with lamp");
        //isOn = !isOn;
        //lampLight.enabled = isOn; //Activa o desactiva el componente Light2D del spot

        if (isOn) return;

        isOn = true;
        lampLight.enabled = true;

        OnLampTurnedOn?.Invoke(); //Invoco el evento para quien necesite escucharlo
    }
}
