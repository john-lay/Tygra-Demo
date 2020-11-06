using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    private GameObject textboxContainer;
    private Image image;
    private bool visible;
    // Use this for initialization
    void Start()
    {
        this.textboxContainer = gameObject;
        this.image = this.textboxContainer.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")) this.ToggleVisibility();
    }

    void ToggleVisibility()
    {
        this.image.enabled = this.visible;
        this.visible = !this.visible;
    }
}
