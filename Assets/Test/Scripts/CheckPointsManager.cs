using UnityEngine;
using TMPro;

namespace Test
{
    public class CheckPointsManager : MonoBehaviour
    {
        [SerializeField] TMP_Text checkPointsLabel;
        int allCheckPoints;
        int currentPassedCheckPoints = 0;
        void Start()
        {
            CheckPoint[] checkPoints = FindObjectsByType<CheckPoint>(FindObjectsSortMode.None);
            foreach(CheckPoint checkPoint in checkPoints)
            {
                checkPoint.pass.AddListener(OnCheckPointCrossed);
            }
            allCheckPoints = checkPoints.Length;
            checkPointsLabel.text = $"0/{allCheckPoints}";
        }

        void OnCheckPointCrossed()
        {
            currentPassedCheckPoints++;
            checkPointsLabel.text = $"{currentPassedCheckPoints}/{allCheckPoints}";
        }
    }
}