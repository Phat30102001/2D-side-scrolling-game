using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using System.Linq;

public class ShootProjectile : ProjectilePooling
{
    private Transform playerTransform;
    private GameObject projectileHole;

    [SerializeField] private float movingSpeed;

    public override void OnAwake()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
    public override void OnStart()
    {
        projectileHole = ProjectileManager.instance.projectileHole;
        projectileHole.SetActive(true);
    }
    public override TaskStatus OnUpdate()
    {
        StartCoroutine(ActiveProjectile());



        return TaskStatus.Success;
    }
    public override IEnumerator  ActiveProjectile()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject p = ProjectileManager.instance.projectilePool.ElementAt(i);
            yield return new WaitForSeconds(spawnInterval*1.5f);
            p.SetActive(true);
            Vector3 pos = p.transform.position;
            pos = projectileHole.transform.position;
            //pos.x = randomx;
            //pos.y = spawnArea.bounds.min.y;
            p.transform.position = pos;
            p.GetComponent<Rigidbody2D>().gravityScale = 0;

            Vector3 shootDir= (projectileHole.transform.position - playerTransform.position).normalized;
            Shooting(p, shootDir);


            

            
        }




    }

    public void Shooting(GameObject projectile,Vector3 shootDir)
    {
        //Debug.Log("shoot");
        projectile.GetComponent<Rigidbody2D>().AddForce(-shootDir * movingSpeed, ForceMode2D.Impulse);
    }
}
