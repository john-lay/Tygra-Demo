using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndOrbitPlayer : MonoBehaviour
{
    private GameObject _tygra;
    private GameObject _monkianContainer;
    private float _monkianWalkSpeed = 2f;
    private float _monkianStrafeSpeed = 10f;
    
    private Animator _animator;
    
    [SerializeField]
    private int CloseInRadius = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _monkianContainer = gameObject;
        _tygra = GameObject.Find("Tygra");
        _animator = transform.Find("monkian").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerEnemyDistance() >= CloseInRadius)
        {
            CloseInOnTygra();
        }
        else
        {
            OrbitTygra();
        }
    }
    
    float PlayerEnemyDistance()
    {
        return Vector3.Distance(_monkianContainer.transform.position, _tygra.transform.position);
    }

    void CloseInOnTygra()
    {
        _monkianContainer.transform.LookAt(_tygra.transform);
        _animator.SetBool("Strafing", false);
        _animator.SetBool("Walking", true);
        _monkianContainer.transform.position += _monkianContainer.transform.forward * (_monkianWalkSpeed * Time.deltaTime);
    }
    
    void OrbitTygra()
    {
        _monkianContainer.transform.LookAt(_tygra.transform);
        _animator.SetBool("Walking", false);
        _animator.SetBool("Strafing", true);
        transform.RotateAround(_tygra.transform.position, _tygra.transform.up, _monkianStrafeSpeed * Time.deltaTime);
    }
}
