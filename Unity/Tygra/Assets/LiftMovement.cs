using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    private bool canMoveUp;
    private bool canMoveDown;
    private float groundFloor = 5.1f;
    private float firstFloor = 15.0f;
    private GameObject player;
    private GameObject lift;

    // Use this for initialization
    void Start()
    {
        lift = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float _posY = transform.position.y;

        if (canMoveUp)
        {
            _posY += 0.1f;
            lift.transform.position = new Vector3(lift.transform.position.x, _posY, lift.transform.position.z);
            
            if (_posY >= firstFloor)
            {
                canMoveUp = false;                
            }
        }

        if (canMoveDown)
        {
            _posY -= 0.1f;
            lift.transform.position = new Vector3(lift.transform.position.x, _posY, lift.transform.position.z);

            if (_posY <= groundFloor)
            {
                canMoveDown = false;
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        canMoveUp = true;
        player.transform.parent = lift.transform;
        //Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        canMoveDown = true;
        player.transform.parent = null;
    }
}