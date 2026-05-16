using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TMP_Text timeLabel;
    float time = 0.0f;

    void Start()
    {
        timeLabel = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timeLabel.text = "Time: " + Convert(Time.timeSinceLevelLoad);
    }

    public static string Convert(float time)
    {
        float minutes = time / 60.0f;
        float seconds = time % 60.0f;
        return $"{minutes:00}:{seconds:00.00}";
    }
}
