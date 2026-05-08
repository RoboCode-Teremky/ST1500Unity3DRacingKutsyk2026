using UnityEngine;
using UnityEngine.InputSystem;

namespace Test
{
    public class CarControl : MonoBehaviour
    {
        [SerializeField] float maxSpeed = 1.0f;
        [SerializeField] float maxSteerAngle = 45.0f;
        Vector2 direction;
        [SerializeField] WheelCollider[] frontWheels = new WheelCollider[2];
        [SerializeField] WheelCollider[] backWheels = new WheelCollider[2];
        [SerializeField] ParticleSystem[] particleSystems;
        Rigidbody rigidbody;
        public void OnMove(InputAction.CallbackContext callbackContext)
        {
            direction = callbackContext.ReadValue<Vector2>();
            Vector3 localSpeed=transform.worldToLocalMatrix * rigidbody.linearVelocity;
            if(Mathf.Sign(direction.y) != Mathf.Sign(localSpeed.z))
            {
                foreach(ParticleSystem ps in particleSystems)
                {
                    ps.Play();
                }
            }
        }

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            foreach (WheelCollider frontWheel in frontWheels)
            {
                frontWheel.motorTorque = direction.y * maxSpeed;
                frontWheel.steerAngle = direction.x * maxSteerAngle;
            }
            foreach (WheelCollider backWheel in backWheels)
            {
                backWheel.motorTorque = direction.y * maxSpeed;
            }
        }
    }
}