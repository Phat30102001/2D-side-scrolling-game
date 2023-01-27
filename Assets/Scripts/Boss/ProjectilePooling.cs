using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class ProjectilePooling : Action
{
    public Collider2D spawnArea;

    //public GameObject parentObject;

    public float spawnInterval;

    public override TaskStatus OnUpdate()
    {
        StartCoroutine(ActiveProjectile());

        return TaskStatus.Success;
    }

    public virtual IEnumerator ActiveProjectile()
    {
        foreach (GameObject p in ProjectileManager.instance.projectilePool)
        {
            float randomx = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            p.SetActive(true);
            Vector3 pos = p.transform.position;
            pos.x = randomx;
            pos.y=spawnArea.bounds.min.y;
            p.transform.position = pos;
            p.GetComponent<Rigidbody2D>().gravityScale = 1;

            yield return new WaitForSeconds(spawnInterval);
        }

            


    }



}
