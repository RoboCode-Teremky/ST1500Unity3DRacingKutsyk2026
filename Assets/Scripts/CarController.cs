using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float maxSteeringAngle = 45.0f;
    [SerializeField] WheelCollider[] frontWheels;
    [SerializeField] WheelCollider[] backWheels;
    Vector2 direction;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        direction = callbackContext.ReadValue<Vector2>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        foreach(WheelCollider wheel in frontWheels)
        {
            wheel.motorTorque = direction.y * speed;
            wheel.steerAngle = direction.x * maxSteeringAngle;
        }
        foreach(WheelCollider wheel in backWheels)
        {
            wheel.motorTorque = direction.y * speed;
        }
    }
}
