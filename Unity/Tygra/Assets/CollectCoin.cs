using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private GameObject coin;

    // Use this for initialization
    void Start()
    {
        coin = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        Destroy(coin);
    }
}
