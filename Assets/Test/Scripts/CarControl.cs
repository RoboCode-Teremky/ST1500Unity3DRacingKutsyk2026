using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace Test
{
    public class CarControl : MonoBehaviour
    {
        [SerializeField] float maxSpeed = 1.0f;
        [SerializeField] float nitroSpeed = 1.0f;
        [SerializeField] float maxSteerAngle = 45.0f;
        [SerializeField] float restartHigh = 2.0f;
        Vector2 direction;
        [SerializeField] WheelCollider[] frontWheels = new WheelCollider[2];
        [SerializeField] WheelCollider[] backWheels = new WheelCollider[2];
        [SerializeField] TMP_Text speedometer;
        [SerializeField] ParticleSystem[] particleSystems;
        Rigidbody rigidbody;
        NitroManager nitroManager;
        public void OnMove(InputAction.CallbackContext callbackContext)
        {
            direction = callbackContext.ReadValue<Vector2>();
            Vector3 localSpeed = transform.worldToLocalMatrix * rigidbody.linearVelocity;
            if (Mathf.Sign(direction.y) != Mathf.Sign(localSpeed.z))
            {
                foreach (ParticleSystem ps in particleSystems)
                {
                    ps.Play();
                }
            }
        }

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            nitroManager = GetComponent<NitroManager>();
        }

        void FixedUpdate()
        {
            foreach (WheelCollider frontWheel in frontWheels)
            {
                frontWheel.motorTorque = direction.y * maxSpeed + (nitroManager.nitroActive ? nitroSpeed : 0.0f);
                frontWheel.steerAngle = direction.x * maxSteerAngle;
            }
            foreach (WheelCollider backWheel in backWheels)
            {
                backWheel.motorTorque = direction.y * maxSpeed + (nitroManager.nitroActive ? nitroSpeed : 0.0f);
            }
        }

        void Update()
        {
            speedometer.text = $"Speed: {rigidbody.linearVelocity.magnitude:F0}";
        }

        public void OnRestart(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                transform.position = transform.position + Vector3.up * restartHigh;
                transform.localRotation = Quaternion.identity;
            }
        }
    }
}