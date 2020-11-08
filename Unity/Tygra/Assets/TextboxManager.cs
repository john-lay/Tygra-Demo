using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    private GameObject textboxContainer;
    private Image textboxBg;
    private Image wilykatPortrait;
    private Image MoreIndicator;
    private Text Title;
    private Text Text;
    private bool visible;
    // Use this for initialization
    void Start()
    {
        string jsonString = System.IO.File.ReadAllText(Application.dataPath + "/GUI/dialogue.en.json");
        SceneDialogue sceneDialogue = JsonUtility.FromJson<SceneDialogue>(jsonString);
        // Debug.Log(sceneDialogue.conversations[0].dialogue[0].title);

        this.textboxContainer = gameObject;
        List<Image> images = new List<Image>(this.textboxContainer.GetComponentsInChildren<Image>());

        if (images.Exists(img => img.name == "TextboxBg"))
            this.textboxBg = images.Find(img => img.name == "TextboxBg");

        if (images.Exists(img => img.name == "WilykatPortrait"))
            this.wilykatPortrait = images.Find(img => img.name == "WilykatPortrait");

        if (images.Exists(img => img.name == "MoreIndicator"))
            this.MoreIndicator = images.Find(img => img.name == "MoreIndicator");

        List<Text> texts = new List<Text>(this.textboxContainer.GetComponentsInChildren<Text>());

        if (texts.Exists(txt => txt.name == "Title"))
            this.Title = texts.Find(txt => txt.name == "Title");

        if (texts.Exists(txt => txt.name == "Text"))
            this.Text = texts.Find(txt => txt.name == "Text");

        // hide text box
        this.ToggleVisibility();

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
        this.MoreIndicator.enabled = this.visible;
        this.Title.enabled = this.visible;
        this.Text.enabled = this.visible;

        this.visible = !this.visible;
    }
}
