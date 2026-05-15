using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Test
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] GameObject finishPanel;
        [SerializeField] TMP_Text currentTimeLabel;
        [SerializeField] TMP_Text recordTimeLabel;
        Timer timer;

        void Start()
        {
            timer = FindAnyObjectByType<Timer>();
            finishPanel.SetActive(false);
        }

        public void OnFinish()
        {
            finishPanel.SetActive(true);
            currentTimeLabel.text = "Current time: " + timer.Convert(timer.time);

            //record
            float record;
            if (PlayerPrefs.HasKey("Record"))
            {
                record = PlayerPrefs.GetFloat("Record");
            }
            else
            {
                record = timer.time;
            }

            if (record >= timer.time)
            {
                record = timer.time;
                PlayerPrefs.SetFloat("Record", record);
            }

            recordTimeLabel.text = "Record: " + timer.Convert(record);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
