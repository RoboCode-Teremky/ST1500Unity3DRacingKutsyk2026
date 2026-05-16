using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class CheckPointsManager : MonoBehaviour
{
    int checkPointCount;
    int currentCheckPointPassed=0;
    [SerializeField] TMP_Text checkPointLabel;
    public UnityEvent finish = new UnityEvent();

    void Start()
    {
        CheckPoint[] checkPoints = 
            FindObjectsByType<CheckPoint>(FindObjectsSortMode.None);
        checkPointCount = checkPoints.Length;
        foreach(CheckPoint checkPoint in checkPoints)
        {
            checkPoint.pass.AddListener(OnPass);
        }
    }

    void OnPass()
    {
        currentCheckPointPassed++;
        checkPointLabel.text = $"{currentCheckPointPassed}/{checkPointCount}";
        if(currentCheckPointPassed == checkPointCount) finish.Invoke();
    }
}
