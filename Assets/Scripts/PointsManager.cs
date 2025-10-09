using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    //Variables
    public float points = 0;
    public bool counting = true;

    // Elementos de UI
    TextMeshProUGUI textUI;

    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        UpdatePoints(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(counting) UpdatePoints(points + Time.deltaTime);
    }

    public void EnableCounting() { counting = true; }
    public void DisableCounting() {counting = false; }


    public float GetPoint()
    {
        return points;
    }

    public string GetPointFormated()
    {
        return ((int)points).ToString("D3");
    }

    void UpdatePoints(float newPoints)
    {
        points = newPoints;
        textUI.text = ((int)points).ToString("D3");
    }

    //Opcional
    void AddPoints(float newPoints)
    {
        points += newPoints;
        textUI.text = ((int)points).ToString("D3");
    }
}
