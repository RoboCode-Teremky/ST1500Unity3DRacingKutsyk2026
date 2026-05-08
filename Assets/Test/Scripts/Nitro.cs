using UnityEngine;
using UnityEngine.Events;

namespace Test
{
    public class Nitro : MonoBehaviour
    {
        public UnityEvent collected = new UnityEvent();

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                collected.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}