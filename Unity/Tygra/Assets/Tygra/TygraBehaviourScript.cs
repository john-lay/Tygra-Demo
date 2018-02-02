using UnityEngine;

public class TygraBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private bool isWalking;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("w pressed");
            if (isWalking)
            {
                anim.SetTrigger("idle-trigger");
            }
            else
            {
                anim.SetTrigger("walk-trigger");
            }

            isWalking = !isWalking;
        }
    }
}
