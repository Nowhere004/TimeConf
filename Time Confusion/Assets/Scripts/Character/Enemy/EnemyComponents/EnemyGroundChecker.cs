using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float rayDistance;
    private BaseEnemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<BaseEnemy>();
    }
    public bool GroundCheck()
    {
        RaycastHit2D groundRayCheck = Physics2D.Raycast(transform.position,Vector2.down,rayDistance,whatIsGround);
        if (groundRayCheck.collider!=null)
        {
            return true;
        }
        return false;
    }
 
}
