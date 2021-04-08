using System.Collections;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    private GameObject tygra;
    private GameObject monkianContainer;
    private GameObject refCannonball;

    [SerializeField]
    private GameObject projectile;
    private GameObject lastCannonball;
    private GameObject cannonball;
    
    [SerializeField]
    private float projectileFrequency = 3.0f;
    
    [SerializeField]
    float projectileSpeed = 8.0f;
    
    [SerializeField]
    int MaxDist = 10;
    
    [SerializeField]
    int MinDist = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.monkianContainer = gameObject;
        this.tygra = GameObject.Find("Tygra");
        this.refCannonball = transform.Find("Cannonball").gameObject;

        StartCoroutine(FireCannonball());
    }

    // Update is called once per frame
    void Update()
    {
        // CloseInOnTygra();
        MoveCannonball();
        if (lastCannonball != null)
        {
            FadeLastCannonball();
        }
    }

    void CloseInOnTygra()
    {
        monkianContainer.transform.LookAt(tygra.transform);

        if (Vector3.Distance(monkianContainer.transform.position, tygra.transform.position) >= MinDist)
        {
            monkianContainer.transform.position += monkianContainer.transform.forward * projectileSpeed * Time.deltaTime;

            if (Vector3.Distance(monkianContainer.transform.position, tygra.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }

    private IEnumerator FireCannonball()
    {
        if (cannonball != null)
        {
            lastCannonball = cannonball;
        }
        monkianContainer.transform.LookAt(tygra.transform);
        cannonball = Instantiate(projectile, Vector3.zero, Quaternion.identity);
        cannonball.transform.position = refCannonball.transform.position;
        
        yield return new WaitForSeconds(projectileFrequency);
        StartCoroutine(FireCannonball());
    }


    void MoveCannonball()
    {
        if (cannonball.transform.position.y >= 0.3f)
        {
            cannonball.transform.LookAt(tygra.transform);
            var position = cannonball.transform.position;
            position += cannonball.transform.forward * (projectileSpeed * Time.deltaTime);
            cannonball.transform.position = position;    
        }
    }

    void FadeLastCannonball()
    {
        var material = lastCannonball.GetComponent<MeshRenderer>().material;
        Color newColor = material.color;
        newColor.a -= Time.deltaTime;
        material.color = newColor;
        lastCannonball.GetComponent<MeshRenderer>().material = material;
        if (material.color.a <= 0.3)
        {
            Destroy(lastCannonball);
        }

    }
}
