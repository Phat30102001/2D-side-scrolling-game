using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

    public class FallingObject : Action
    {
        public static FallingObject instance;

        public List<GameObject> projectilePool=new List<GameObject>();

    [SerializeField] private GameObject projectile;
    //public Collider2D spawnArea;
    
    ////public GameObject parentObject;

    [SerializeField] private int spawnCount;
    //[SerializeField] private float spawnInterval;

    public override void OnStart()
    {
        instance= this;

        for(int i=0;i<spawnCount;i++)
        {
            SpawnOrb();
        }
    }

    //public override TaskStatus OnUpdate()
    //{
    //    var sequence = DOTween.Sequence();
    //    for (int i = 0; i < spawnCount; i++)
    //    {

    //        sequence.AppendCallback(SpawnOrb);

    //        sequence.AppendInterval(spawnInterval);
    //        Debug.Log(i);
    //    }
    //    return TaskStatus.Success;
    //}

    public void SpawnOrb()
    {
        //float randomx=Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x);
        GameObject projectileOrb=Object.Instantiate(projectile);
        projectile.SetActive(false);
        projectilePool.Add(projectileOrb);
        //projectileOrb.transform.SetParent(parentObject.transform);
        
    }
}


