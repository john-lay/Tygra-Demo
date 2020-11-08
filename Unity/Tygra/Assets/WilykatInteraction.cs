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
    // Use this for initialization
    void Start()
    {
        this.wilykat = gameObject;
        GameObject textboxContainer = GameObject.Find("TextboxContainer");
        this.textboxManager = textboxContainer.GetComponent<TextboxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.interact && Input.GetButtonDown("Submit"))
        {
            if (this.textboxManager.SceneExists(this.sceneAlias))
            {
                int sceneId = this.textboxManager.GetSceneIdByAlias(this.sceneAlias);
                if (sceneId != -1)
                {
                    this.textboxManager.PlayDialogue(sceneId);
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
