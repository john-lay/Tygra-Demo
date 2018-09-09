using UnityEngine;

public class RightClaw : MonoBehaviour
{
    private GameObject rightClaw;
    private bool canMoveClaw;
    
    private float maxRotationDegrees = 15.0f;
    private float maxRotationRadians;

    // Use this for initialization
    void Start()
    {
        rightClaw = gameObject;
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
    }

    public void Open()
    {
        canMoveClaw = true;
    }
}
