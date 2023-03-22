using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 100;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // initially sets isShooting to false
        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        // mouse input is noticed, calls Shoot method
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();
        }
        
    }
    // Shoot method turns isShooting to True
    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            // Debug.Log("hit");

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
            }

        }
    }
}
