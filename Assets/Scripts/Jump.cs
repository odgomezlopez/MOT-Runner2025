using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    //Variables de salto
    public float force = 5f;
    private Rigidbody rb;
    private bool jumpKey;

    //Variables para detectar suelo
    LayerMask groundMask;
    public float groundDistance = 1f;
    public GameObject puntoSuelo;

    //Eventos
    public UnityEvent OnJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Comprobar elementos asociados
        if (!puntoSuelo) Debug.Log("PuntoSuelo no inicalizado");

        //Inicialización de variables
        groundMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody>();
        jumpKey = false;
    }

    //Update - Detectar si se puede saltar
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Has pulsado espacio");
            jumpKey = true; ;
        }
    }

    private void FixedUpdate()
    {
        if (jumpKey)
        {
            jumpKey = false;
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            OnJump.Invoke();
        }
    }

    //Detección de suelo mediante RayCast: https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Physics.Raycast.html
    private bool IsGrounded()
    {
        RaycastHit hit;



        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(puntoSuelo.transform.position, Vector3.down, out hit, groundDistance, groundMask))

        {
            Debug.DrawRay(puntoSuelo.transform.position, Vector3.down * hit.distance, Color.red,1f);
            Debug.Log("Did Hit");
            return true;
        }
        else
        {
            Debug.DrawRay(puntoSuelo.transform.position, Vector3.down * groundDistance, Color.blue,1f);
            Debug.Log("Did not Hit");
            return false;
        }
    }
}
