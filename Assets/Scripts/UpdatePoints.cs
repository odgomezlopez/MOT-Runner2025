using TMPro;
using UnityEngine;

public class UpdatePoints : MonoBehaviour
{
    public PointsManager pointsManager;

    TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = $"You have obtained <color=\"blue\">{pointsManager.GetPointFormated()}</color> points";
    }



    //You have obtained <color="blue">XXX</color> points
}
