using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int count;
    public Text countText;

    // Use this for initialization
    void Start()
    {
        count = 0;        
    }

    public void UpdateCount()
    {
        count++;
        countText.text = "Coins: " + count.ToString() + " / 5";

        if (count == 5)
        {
            var clawWrapper = GameObject.Find("RightClawWrapper");
            var clawScript = clawWrapper.GetComponent<RightClaw>();

            clawScript.Open();
        }
    }
}
