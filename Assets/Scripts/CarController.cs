using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float maxSteeringAngle = 45.0f;
    [SerializeField] WheelCollider[] frontWheels;
    [SerializeField] WheelCollider[] backWheels;
    Vector2 direction;
    Rigidbody rigidbody;
    [SerializeField] TMP_Text speedometer;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        direction = callbackContext.ReadValue<Vector2>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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

    void Update()
    {
        speedometer.text = $"Speed: {rigidbody.linearVelocity.magnitude:F1}";
    }

    int availableNitro = 0;
    bool isNitro = false;
    [SerializeField] float nitroSpeed = 1000.0f;
    [SerializeField] TMP_Text nitroLabel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nitro"))
        {
            other.gameObject.SetActive(false);
            availableNitro++;
            nitroLabel.text = $"Nitro: {availableNitro}";
        }
    }

    public void OnNitro(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.started && availableNitro > 0)
        {
            availableNitro--;
            rigidbody.AddForce(transform.forward*nitroSpeed, ForceMode.Impulse);
            nitroLabel.text = $"Nitro: {availableNitro}";
        }
    }

    [SerializeField] float restartHigh = 2.0f;
    public void OnRestart(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            transform.position = transform.position + Vector3.up*restartHigh;
            transform.localRotation = Quaternion.identity;
        }
    }
}
