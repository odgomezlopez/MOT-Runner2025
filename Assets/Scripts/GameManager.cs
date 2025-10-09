using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnInit;
    public UnityEvent OnGameStart;

    bool gameStarted;
    void Start()
    {
        gameStarted = false;
        OnInit.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        //Compruebo si el usuario pulsa SPACE para iniciar el juego
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            OnGameStart.Invoke();
        }
    }
}
