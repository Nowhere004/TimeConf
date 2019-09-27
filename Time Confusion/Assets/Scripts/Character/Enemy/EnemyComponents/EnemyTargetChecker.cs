using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyTargetChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            GetComponentInParent<BaseEnemy>().Target = target.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            GetComponentInParent<BaseEnemy>().Target = null;
        }
    }
}
