using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool canMoveUp;
    private float firstFloor = 16.0f;//15.0f;
    private Collider player;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float _posY = transform.position.y;
        if (canMoveUp)
        {
            _posY+= 0.1f;
            Debug.Log(_posY);
            //transform.Translate(new Vector3(transform.position.x, _posY, transform.position.z));
            transform.position = new Vector3(transform.position.x, _posY, transform.position.z);
            player.transform.position = new Vector3(player.transform.position.x, _posY + 0.15f, player.transform.position.z);
        }

        if (_posY >= firstFloor)
        {
            canMoveUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other;
        canMoveUp = true;
        other.transform.SetParent(transform);
        //transform.SetParent(other.transform);
        Debug.Log(other.name);
    }
}