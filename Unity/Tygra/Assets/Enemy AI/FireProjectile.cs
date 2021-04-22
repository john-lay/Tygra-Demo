using System.Collections;
using System.Linq;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    private GameObject tygra;
    private GameObject monkianContainer;
    private GameObject refCannonball;

    [SerializeField]
    private GameObject projectile;
    private GameObject lastCannonball;
    private GameObject cannonball;
    
    // TODO: this should be linked to the SeekAndOrbitPlayer.cs script's CloseInRadius property
    [SerializeField]
    private int FiringRange = 10;
    
    [SerializeField]
    private float SecondsBetweenShots = 2.0f;
    
    [SerializeField]
    float projectileSpeed = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.monkianContainer = gameObject;
        this.tygra = GameObject.Find("Tygra");
        // Monkian's shield is attached to his mixamorig:LeftHand
        this.refCannonball = gameObject.transform
            .GetComponentsInChildren<Transform>(true)
            .FirstOrDefault(t => t.name == "Cannonball")
            ?.gameObject;

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
    
    float PlayerEnemyDistance()
    {
        return Vector3.Distance(monkianContainer.transform.position, tygra.transform.position);
    }

    private IEnumerator FireCannonball()
    {
        if (PlayerEnemyDistance() <= FiringRange)
        {
            if (cannonball != null)
            {
                lastCannonball = cannonball;
            }
            monkianContainer.transform.LookAt(tygra.transform);
            cannonball = Instantiate(projectile, Vector3.zero, Quaternion.identity);
            cannonball.transform.position = refCannonball.transform.position;
        
        }
        
        yield return new WaitForSeconds(SecondsBetweenShots);
        StartCoroutine(FireCannonball());
    }


    void MoveCannonball()
    {
        if (cannonball != null)
        {
            if (cannonball.transform.position.y >= 0.3f)
            {
                cannonball.transform.LookAt(tygra.transform);
                var position = cannonball.transform.position;
                position += cannonball.transform.forward * (projectileSpeed * Time.deltaTime);
                cannonball.transform.position = position;    
            }
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
