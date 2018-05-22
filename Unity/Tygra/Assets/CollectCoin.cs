using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private GameObject coin;
    private CoinCounter script;

    // Use this for initialization
    void Start()
    {
        coin = gameObject;
        var coinText = GameObject.Find("CoinText");
        script = coinText.GetComponent<CoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        script.UpdateCount();
        Destroy(coin);
    }
}
