using UnityEngine;

// maintains position offset while orbiting around target
public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    public float mouseSensitivity = 100.0f;

    private float _rotX;
    private float _rotY;
    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        float mouseY = -Input.GetAxis("Mouse Y");
        float clampAngle = 30.0f;

        if (horInput != 0)
        {
            _rotY += horInput * rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        _rotX += mouseY * mouseSensitivity * Time.deltaTime;
        _rotX = Mathf.Clamp(_rotX, -clampAngle, clampAngle);

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}