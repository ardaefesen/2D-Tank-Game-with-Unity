using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Transform> FirePoints;
    public GameObject bullet;
    public Type actor;
    public enum Type { Player, Enemy };


    private GameObject goBoss;
    private bool enemiesLeft = true;

    void Start()
    {
        if (actor == Type.Enemy)
        {
            goBoss = GameObject.Find("Boss");
            goBoss.SetActive(false);

            StartCoroutine(ShootAtRandom());
        }
    }

    void Update()
    {
        if (actor == Type.Player)
        {
            ShootOnTrigger();
        }
    }
    void ShootOnTrigger()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // respawn bullet 
            Instantiate(bullet, FirePoints[0].position, FirePoints[0].rotation);
        }
    }

    IEnumerator ShootAtRandom()
    {
        //unless there is no enemy left continue
        while (enemiesLeft)
        {
            // randomly select enemy and time
            int enemyOnFire = (int)Random.Range(0f, 3f);
            float waitingDuration = Random.Range(0f, 10f);

            // wait for random time
            yield return new WaitForSeconds(waitingDuration);

            // if selected enemy is not dead respawn bullet 
            if (FirePoints[enemyOnFire] != null)
                Instantiate(bullet, FirePoints[enemyOnFire].position, FirePoints[enemyOnFire].rotation);

            // check if there are other enemies
            enemiesLeft = false;
            foreach (Transform t in FirePoints)
                if (t != null)
                    enemiesLeft = true;
        }

        //there is no enemy left then activate boss
        if (!enemiesLeft)
        {
            StartCoroutine(BossFight());
        }
    }


    IEnumerator BossFight()
    {
        //unless boss is alive
        while (goBoss != null)
        {
            goBoss.SetActive(true);
            Transform firePoint = goBoss.transform.Find("FirePoint");

            // wait for 1s time
            yield return new WaitForSeconds(1f);

            // if selected enemy is not dead respawn bullet 
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
