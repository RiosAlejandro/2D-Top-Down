using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float rotationSpedd = 10f;

    private Vector2 lastDirection = Vector2.down; //Guarda la ultima direccion valida- evita que la linterna vuelva a posicion de rotacion 0- Empieza apuntando hacia abajo


    void Update()
    {
        Vector2 movement = player.movement; // Obtenemos movimiento del player

        if (movement != Vector2.zero) // solo si el jugador se mueve
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) //determinar direccion cardinal- compara que eje domina (x - y)
            {
                lastDirection = movement.x > 0 ? Vector2.left : Vector2.right; // ternario para horizontal
            }
            else
            {
                lastDirection = movement.y > 0 ? Vector2.down : Vector2.up; //ternario para vertical
            }
        }

        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg + 90f; // atan2(devuelve el angulo en radianes) - rad2deg(multiplica para dar el resultado en grados)

        float smoothAngle = Mathf.LerpAngle(
            transform.eulerAngles.z,
            angle,
            Time.deltaTime * rotationSpedd
            ); // interpola entre angulo actual y angulo objetivo para que la rotacion no sea brusca e instantanea

        transform.rotation = Quaternion.Euler(0f, 0f, smoothAngle); //Aplica la rotacion
    }
}
