using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    public override bool IsDead => healthStat.CurrentVal <= 0;

    protected override void Start()
    {
        base.Start();      
    }

    public override void Death()
    {
        
    }

    public override IEnumerator TakeDamage()
    {
        yield return null;
    }
}
