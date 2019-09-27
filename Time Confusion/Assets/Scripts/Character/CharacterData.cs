using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : MonoBehaviour
{
    public bool isCharacterFacingRight{ get; private set;}
    public abstract bool IsDead { get; }
    [SerializeField]
    protected Stat healthStat;

    protected virtual void Start()
    {
        isCharacterFacingRight = true;
        healthStat.Initialize();
    }
    public void ChangeCharacterDirection()
    {
        isCharacterFacingRight = !isCharacterFacingRight;
        transform.Rotate(0,180f,0);     
    }

   
    public abstract IEnumerator TakeDamage();
    public abstract void Death();
}
