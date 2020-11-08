using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    private GameObject textboxContainer;
    private Image textboxBg;
    private Image wilykatPortrait;
    private Image tygraPortrait;
    private Image MoreIndicator;
    private Text Title;
    private Text Text;
    private bool visible;

    public SceneDialogue sceneDialogue;
    // Use this for initialization
    void Start()
    {
        string jsonString = System.IO.File.ReadAllText(Application.dataPath + "/GUI/dialogue.en.json");
        this.sceneDialogue = JsonUtility.FromJson<SceneDialogue>(jsonString);
        // Debug.Log(sceneDialogue.conversations[0].dialogue[0].title);

        this.textboxContainer = gameObject;
        List<Image> images = new List<Image>(this.textboxContainer.GetComponentsInChildren<Image>());

        if (images.Exists(img => img.name == "TextboxBg"))
            this.textboxBg = images.Find(img => img.name == "TextboxBg");

        if (images.Exists(img => img.name == "WilykatPortrait"))
            this.wilykatPortrait = images.Find(img => img.name == "WilykatPortrait");

        if (images.Exists(img => img.name == "TygraPortrait"))
            this.tygraPortrait = images.Find(img => img.name == "TygraPortrait");

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
        // if (Input.GetButtonDown("Submit")) this.ToggleVisibility();
    }

    private void ToggleVisibility()
    {
        this.textboxBg.enabled = this.visible;
        this.wilykatPortrait.enabled = this.visible;
        this.tygraPortrait.enabled = this.visible;
        this.MoreIndicator.enabled = this.visible;
        this.Title.enabled = this.visible;
        this.Text.enabled = this.visible;

        this.visible = !this.visible;
    }

    public bool SceneExists(int sceneId)
    {
        return this.sceneDialogue.conversations.Exists(con => con.id == sceneId);
    }

    public bool SceneExists(string sceneAlias)
    {
        return this.sceneDialogue.conversations.Exists(con => con.alias == sceneAlias);
    }

    public int GetSceneIdByAlias(string sceneAlias)
    {
        if (this.SceneExists(sceneAlias))
        {
            return this.sceneDialogue.conversations.Find(con => con.alias == sceneAlias).id;
        }

        return -1;
    }

    public void PlayDialogue(int sceneId)
    {
        if (this.sceneDialogue.conversations.Exists(con => con.id == sceneId))
        {
            Conversation conversation = this.sceneDialogue.conversations.Find(con => con.id == sceneId);
            List<LinearDialogue> flatDialogue = this.FlattenDialogue(conversation);
            this.PlayConversation(flatDialogue);
        }
    }

    private void PlayConversation(List<LinearDialogue> dialogue)
    {
        //Input.GetButtonDown("Submit")
        this.textboxBg.enabled = this.visible;

        switch (dialogue[0].portrait)
        {
            case "WilykatPortrait":
                this.wilykatPortrait.enabled = this.visible;
                break;
            case "TygraPortrait":
                this.tygraPortrait.enabled = this.visible;
                break;
        }

        this.Title.text = dialogue[0].title;
        this.Title.enabled = this.visible;

        this.Text.text = dialogue[0].text;
        this.Text.enabled = this.visible;
        
        this.MoreIndicator.enabled = this.visible;
    }

    private List<LinearDialogue> FlattenDialogue(Conversation conversation)
    {
        List<LinearDialogue> result = new List<LinearDialogue>();

        foreach (var dialogue in conversation.dialogue)
        {
            foreach (var text in dialogue.text)
            {
                result.Add(new LinearDialogue { title = dialogue.title, portrait = dialogue.portrait, text = text });
            }
        }

        return result;
    }
}
