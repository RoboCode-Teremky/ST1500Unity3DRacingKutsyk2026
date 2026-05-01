using UnityEngine;
using UnityEngine.Events;

namespace Test
{
    public class CheckPoint : MonoBehaviour
    {
        public UnityEvent pass = new UnityEvent();
        bool passed = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !passed)
            {
                passed = true;
                pass.Invoke();
            }
        }
    }
}