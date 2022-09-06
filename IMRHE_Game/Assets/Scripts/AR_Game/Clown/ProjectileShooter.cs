using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileShooter : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //Bullet Physics
    public float LaunchForce, UpwardForce;

    //Gun Stats
    public float ShotInterval, spread, ReloadTime,ShootingInterval;
    public bool allowHold;

    int AmmoRemaining, AmmoSpent;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public Text AmmunitionDisplay;

    //
    bool allowInvoke = true;

    private void Awake()
    {
        readyToShoot = true;
        AmmoSpent = 0;
    }

    private void Update()
    {
        bulletMechanics();
    }

    public void StartShooting()
    {
        shooting = true;
    }
    public void StopShooting()
    {
        shooting = false;
    }
    private void bulletMechanics()
    {
        if (readyToShoot && shooting && !reloading)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Debug.DrawRay(attackPoint.position, new Vector3(0.5f, 0.5f, 0), Color.green);
        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        //Raw Bullet Direction
        Vector3 DirectionWithoutSpread = targetPoint - attackPoint.position;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Spread + Direction
        Vector3 DirectionWithSpread = DirectionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate Bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotate to shoot in correct direction
        currentBullet.transform.forward = DirectionWithSpread.normalized;

        //Add Force
        currentBullet.GetComponent<Rigidbody>().AddForce(DirectionWithSpread.normalized * LaunchForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * UpwardForce, ForceMode.Impulse);

        AmmoSpent++;

        if (allowInvoke)
        {
            Invoke("ResetShot", ShootingInterval);
            allowInvoke = false;
        } 

        AmmunitionDisplay.text = AmmoSpent.ToString();

        StopShooting();
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    public int getBulletUsed()
    {
        return AmmoSpent;
    }

}
