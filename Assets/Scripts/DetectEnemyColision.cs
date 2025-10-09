using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DetectEnemyColision : MonoBehaviour
{
    public UnityEvent OnColision;

    [Range(0f, 5f)] public float gameOverWaitSeconds = 1f;

    public UnityEvent OnGameOver;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Has chocado contra un enemigo");
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        //Colisión de GameOver Detectada
        OnColision.Invoke();

        //Espero 1 segundo
        yield return new WaitForSecondsRealtime(gameOverWaitSeconds);

        //Activo el GameOver
        OnGameOver.Invoke();

        yield return null;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //gameObject.SetActive(false);
        //TODO Morir y reiniciar
    }
}
