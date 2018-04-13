using UnityEngine;

public class ControlRoomButton : MonoBehaviour
{
    private GameObject button;
    private GameObject rightClaw;
    private bool canMoveButton;
    private bool canMoveClaw;
    
    private float maxRotationDegrees = 15.0f;
    private float maxRotationRadians;
    private float minButtonPosition = 0.45f;

    // Use this for initialization
    void Start()
    {
        button = gameObject;
        rightClaw = GameObject.Find("RightClawWrapper");
        maxRotationRadians = maxRotationDegrees * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        // animate right claw rotating
        float rotX = rightClaw.transform.rotation.x;

        if (canMoveClaw)
        {
            rotX += 0.1f;
            rightClaw.transform.Rotate(new Vector3(rotX, 0.0f, 0.0f));
            
            if (rotX >= maxRotationRadians)
            {
                canMoveClaw = false;
            }
        }

        // animate button press
        float posY = button.transform.position.y;

        if (canMoveButton)
        {
            posY -= 0.001f;
            button.transform.position = new Vector3(button.transform.position.x, posY, button.transform.position.z);

            if (posY <= minButtonPosition)
            {
                canMoveButton = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canMoveClaw = true;
        canMoveButton = true;
    }
}
