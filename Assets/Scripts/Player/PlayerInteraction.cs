using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 1.5f;
    [SerializeField] private LayerMask interactableLayer; //las lamparas y el spot deben tener el mismo Layer que el script del player


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) //Al presionar E llama a la funcion
        {
            TryInteract();
        }        
    }

    private void TryInteract()
    {
        Collider2D hit = Physics2D.OverlapCircle( //busca un collider dentro de un radio y devuelve el primero que encuentra
            transform.position,
            interactionRadius,
            interactableLayer //filtra por Layer
        );

        if (hit != null) 
        { 
            IInteractable interactable = hit.GetComponent<IInteractable>(); // pregunta si este objeto implementa la interfaz(IInteractable)

            if (interactable != null) 
            { 
                interactable.Interact(); //ejecuta el contrato de la interfaz
            }
        }
    }
}
