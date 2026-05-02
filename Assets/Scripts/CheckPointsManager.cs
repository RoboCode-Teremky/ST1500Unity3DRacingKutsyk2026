using UnityEngine;
using TMPro;
public class CheckPointsManager : MonoBehaviour
{
    int checkPointCount;
    int currentCheckPointPassed=0;
    [SerializeField] TMP_Text checkPointLabel;
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
    }
}
