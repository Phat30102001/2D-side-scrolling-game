using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_BossRoom : EnemyBehaviour
{
    public override void HandleDead()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
