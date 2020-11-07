using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string portrait;
    public string title;
    public List<string> text;
}

[System.Serializable]
public class Conversation
{
    public string id;

    public string alias;
    public List<Dialogue> dialogue;
}

[System.Serializable]
public class SceneDialogue
{
    public List<Conversation> conversations;
}
