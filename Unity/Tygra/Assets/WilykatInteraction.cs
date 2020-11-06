using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilykatInteraction : MonoBehaviour
{

    private GameObject wilykat;
    private GameObject tygra;
    private bool interact;
    // Use this for initialization
    void Start()
    {
        this.wilykat = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.interact && Input.GetButtonDown("Submit")) {
            Debug.Log("talking to wilykit...");
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
