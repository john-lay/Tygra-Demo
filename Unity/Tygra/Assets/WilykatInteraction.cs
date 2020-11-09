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
    // Use this for initialization
    void Start()
    {
        this.wilykat = gameObject;
        GameObject textboxContainer = GameObject.Find("TextboxContainer");
        this.textboxManager = textboxContainer.GetComponent<TextboxManager>();
        this.currentPage = 0;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        this.tygra = other.gameObject;
        this.interact = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.interact = false;
    }
}
