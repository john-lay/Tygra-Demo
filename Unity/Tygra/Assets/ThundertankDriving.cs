using UnityEngine;

public class ThundertankDriving : MonoBehaviour
{
    private Animator animator;
    private GameObject thundertank;
    private GameObject tygra;
    private bool canDrive;
    private bool isDriving;
    private float originalSpeed;

    // Use this for initialization
    void Start()
    {
        thundertank = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // prevent a jump in/out of tank in single update cycle
        bool hasUsedThundertank = false;

        // check if we're close to the thundertank and fire2 is pressed to get in the tank
        if (canDrive && !isDriving && !hasUsedThundertank && Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("getting into thundertank");

            // align tygra with thundertank and point him towards the tip of the tank
            tygra.transform.position = thundertank.transform.position;
            tygra.transform.position = new Vector3(tygra.transform.position.x, tygra.transform.position.y, tygra.transform.position.z - 0.1f); // prevent his head from falling through the chair
            GameObject thundertankTip = GameObject.Find("ThundertankTip");
            tygra.transform.LookAt(thundertankTip.transform);

            // parent the tank to tygra and set him to his driving animation
            thundertank.transform.parent = tygra.transform;
            animator.SetBool("Driving", true);
            isDriving = true;

            // double move speed
            tygra.GetComponent<RelativeMovement>().moveSpeed = 12.0f;

            hasUsedThundertank = true;
        }

        // check if we're driving and fire2 is pressed to  get out of the tank
        if (isDriving && !hasUsedThundertank && Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("getting out of thundertank");

            // unparent the tank and tygra and move tygra next to the left door
            thundertank.transform.parent = null;
            tygra.transform.position = new Vector3(tygra.transform.position.x - 3.0f,
                tygra.transform.position.y,
                tygra.transform.position.z);

            animator.SetBool("Driving", false);
            isDriving = !isDriving;

            // reset move speed
            tygra.GetComponent<RelativeMovement>().moveSpeed = originalSpeed;

            hasUsedThundertank = true;
        }

        hasUsedThundertank = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision with thundertank");

        if (other.gameObject.name == "Tygra")
        {
            tygra = other.gameObject;
            animator = tygra.GetComponent<Animator>();
            originalSpeed = tygra.GetComponent<RelativeMovement>().moveSpeed;

            canDrive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canDrive = false;
    }
}
