using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 lastPlayerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!player) Debug.Log("Camera: Player reference not setted");
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculo cuanto se ha movido el jugador
        float diff = player.transform.position.x - lastPlayerPosition.x;

        //Actualizo la ultima posición del jugador
        lastPlayerPosition = player.transform.position;

        //Creo un nuevo vector y le sumo la diferencia
        Vector3 newPosition = transform.position;
        newPosition.x += diff;

        //Aplico el movimiento
        transform.position = newPosition;
    }
}
