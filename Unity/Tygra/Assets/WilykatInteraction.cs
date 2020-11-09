using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilykatInteraction : MonoBehaviour
{

    private GameObject wilykat;
    private GameObject tygra;
    private bool interact;

    private readonly string sceneAlias = "Wilykit Interaction";

    private TextboxManager textboxManager;

    private int currentPage;
    private Animator animator;

    private Vector3 targetPoint;
    private Quaternion targetRotation;
    // Use this for initialization
    void Start()
    {
        this.wilykat = gameObject;
        GameObject textboxContainer = GameObject.Find("TextboxContainer");
        this.textboxManager = textboxContainer.GetComponent<TextboxManager>();
        this.currentPage = 0;
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.interact && Input.GetButtonDown("Submit"))
        {
            if (this.textboxManager.ConversationExists(this.sceneAlias))
            {
                List<LinearConversation> conversations = this.textboxManager.GetConversation(this.sceneAlias);
                if (conversations.Count != 0)
                {
                    if (this.currentPage >= conversations.Count)
                    {
                        this.textboxManager.Close();
                        this.currentPage = 0;
                    }
                    else
                    {
                        this.textboxManager.PlayNextDialogue(conversations[this.currentPage]);
                        this.currentPage++;
                    }
                }
            }
        }

        // follow tygra around the room
        if (this.tygra != null)
        {
            targetPoint = new Vector3(tygra.transform.position.x, transform.position.y, tygra.transform.position.z) - transform.position;
            targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.tygra = other.gameObject;
        this.interact = true;
        this.animator.SetBool("Interacting", interact);
    }

    private void OnTriggerExit(Collider other)
    {
        this.interact = false;
        this.animator.SetBool("Interacting", false);
    }
}
