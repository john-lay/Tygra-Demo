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

    public bool ConversationExists(int conversationId)
    {
        return this.sceneDialogue.conversations.Exists(con => con.id == conversationId);
    }

    public bool ConversationExists(string conversationAlias)
    {
        return this.sceneDialogue.conversations.Exists(con => con.alias == conversationAlias);
    }

    public List<LinearConversation> GetConversation(int conversationId)
    {
        if (this.ConversationExists(conversationId))
        {
            Conversation conversation =  this.sceneDialogue.conversations.Find(con => con.id == conversationId);
            return this.FlattenDialogue(conversation);
        }

        return new List<LinearConversation>();
    }

    public List<LinearConversation> GetConversation(string conversationAlias)
    {
        if (this.ConversationExists(conversationAlias))
        {
            Conversation conversation =  this.sceneDialogue.conversations.Find(con => con.alias == conversationAlias);
            return this.FlattenDialogue(conversation);
        }

        return new List<LinearConversation>();
    }

    public void PlayNextDialogue(LinearConversation conversation)
    {
        this.textboxBg.enabled = this.visible;

        switch (conversation.portrait)
        {
            case "WilykatPortrait":
                this.wilykatPortrait.enabled = this.visible;
                break;
            case "TygraPortrait":
                this.tygraPortrait.enabled = this.visible;
                break;
        }

        this.Title.text = conversation.title;
        this.Title.enabled = this.visible;

        this.Text.text = conversation.text;
        this.Text.enabled = this.visible;
        
        this.MoreIndicator.enabled = this.visible;
    }

    public void Close()
    {
        List<MaskableGraphic> uiElements = new List<MaskableGraphic>(this.textboxContainer.GetComponentsInChildren<MaskableGraphic>());
        foreach (var ui in uiElements)
        {
            ui.enabled = false;
        }
    }

    private List<LinearConversation> FlattenDialogue(Conversation conversation)
    {
        List<LinearConversation> result = new List<LinearConversation>();

        foreach (var dialogue in conversation.dialogue)
        {
            foreach (var text in dialogue.text)
            {
                result.Add(new LinearConversation { title = dialogue.title, portrait = dialogue.portrait, text = text });
            }
        }

        return result;
    }
}
