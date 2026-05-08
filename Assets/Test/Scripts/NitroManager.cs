using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

namespace Test
{
    public class NitroManager : MonoBehaviour
    {
        [SerializeField] TMP_Text nitroLabel;
        int nitroAvailable = 0;
        public bool nitroActive;
        [SerializeField] float nitroDuration = 5.0f;
        void Start()
        {
            Nitro[] nitros = FindObjectsByType<Nitro>(FindObjectsSortMode.None);
            foreach (Nitro nitro in nitros)
            {
                nitro.collected.AddListener(OnNitroCollected);
            }
        }

        void OnNitroCollected()
        {
            nitroAvailable++;
            nitroLabel.text = $"Nitro: {nitroAvailable}";
        }

        public void OnNitroActivated(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started && nitroAvailable > 0)
            {
                nitroAvailable--;
                StartCoroutine(ActivateNitro());
                nitroLabel.text = $"Nitro: {nitroAvailable}";
            }
            
        }

        IEnumerator ActivateNitro()
        {
            nitroActive = true;
            nitroLabel.color = Color.blue;
            yield return new WaitForSeconds(5.0f);
            nitroActive = false;
            nitroLabel.color = Color.white;
        }
    }
}