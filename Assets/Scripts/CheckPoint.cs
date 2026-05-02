using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent pass = new UnityEvent();
    bool passed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pass.Invoke();
            passed = true;
        }
    }
}
