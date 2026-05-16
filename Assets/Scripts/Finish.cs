using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    [SerializeField] TMP_Text currentTimeLabel;
    [SerializeField] TMP_Text recordTimeLabel;

    void Start()
    {
        finishPanel.SetActive(false);
    }

    public void OnFinish()
    {
        finishPanel.SetActive(true);
        currentTimeLabel.text = "Current time: " + Timer.Convert(Time.timeSinceLevelLoad);

        const string recordPrefName= "Record";
        float record;
        if (PlayerPrefs.HasKey(recordPrefName))
        {
            record = PlayerPrefs.GetFloat(recordPrefName);
        }
        else
        {
            record = Time.timeSinceLevelLoad;
        }

        if(record >= Time.timeSinceLevelLoad)
        {
            record = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat(recordPrefName, record);
        }

        recordTimeLabel.text = "Record: " + Timer.Convert(record);
    }
}
