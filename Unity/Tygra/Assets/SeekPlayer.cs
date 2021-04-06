using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    private GameObject tygra;
    private GameObject monkianContainer;
    private GameObject cannonball;
    float MoveSpeed = 1f;
    int MaxDist = 10;
    int MinDist = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.monkianContainer = gameObject;
        this.tygra = GameObject.Find("Tygra");
        this.cannonball = transform.Find("Cannonball").gameObject;
        Debug.Log(cannonball);
    }

    // Update is called once per frame
    void Update()
    {
        // CloseInOnTygra();
        ShootCannonball();
    }

    void CloseInOnTygra()
    {
        monkianContainer.transform.LookAt(tygra.transform);

        if (Vector3.Distance(monkianContainer.transform.position, tygra.transform.position) >= MinDist)
        {
            monkianContainer.transform.position += monkianContainer.transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(monkianContainer.transform.position, tygra.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }


    void ShootCannonball()
    {
        monkianContainer.transform.LookAt(tygra.transform);

        cannonball.transform.position += cannonball.transform.forward * MoveSpeed * Time.deltaTime;
        
    }
}
