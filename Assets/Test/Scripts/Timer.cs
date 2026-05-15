using UnityEngine;
using TMPro;

namespace Test
{
    public class Timer : MonoBehaviour
    {
        TMP_Text timerLabel;
        public float time = 0.0f;
        void Start()
        {
            timerLabel = GetComponent<TMP_Text>();
        }

        void Update()
        {
            time += Time.deltaTime;

            timerLabel.text = "Time: " + Convert(time);
        }

        public string Convert(float time)
        {
            float minutes = time / 60.0f;
            float seconds = time % 60.0f;
            return $"{minutes:00}:{seconds:00.00}";
        }
    }
}
