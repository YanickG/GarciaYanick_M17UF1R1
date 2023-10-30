using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;
    public float shootingSpeed = 1;

    private void Start()
    {
        StartCoroutine(routine: Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingSpeed);
            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        }
    }
}
