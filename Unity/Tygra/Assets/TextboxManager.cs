using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    private GameObject textboxContainer;
    private Image textboxBg;
    private Image wilykatPortrait;
    private bool visible;
    // Use this for initialization
    void Start()
    {
        this.textboxContainer = gameObject;
        List<Image> images = new List<Image>(this.textboxContainer.GetComponentsInChildren<Image>());

        if (images.Exists(img => img.name == "TextboxBg"))
        {
            this.textboxBg = images.Find(img => img.name == "TextboxBg");
        }

        if (images.Exists(img => img.name == "WilykatPortrait"))
        {
            this.wilykatPortrait = images.Find(img => img.name == "WilykatPortrait");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")) this.ToggleVisibility();
    }

    void ToggleVisibility()
    {
        this.textboxBg.enabled = this.visible;
        this.wilykatPortrait.enabled = this.visible;
        this.visible = !this.visible;
    }
}
