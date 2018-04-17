using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    GameObject coin;

    // Use this for initialization
    void Start()
    {
        coin = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
}
