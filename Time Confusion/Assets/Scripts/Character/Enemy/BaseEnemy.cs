using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(EnemyStateMachine),typeof(EnemyData))]
public abstract class BaseEnemy : MonoBehaviour 
{
    StateIndicator<StateType, BaseEnemyState> stateIndicator;
    private Dictionary<StateType, BaseEnemyState> enemyStates;
    private EnemyStateMachine stateMachine;
    private Animator enemyAnimator;
    public Animator EnemyAnimator => enemyAnimator;
    public GameObject Target { get; set; }
    public EnemyStateMachine EnemyStateMachine => stateMachine;
    public EnemyGroundChecker EnemyGroundCheckerScript { get; private set; }
    public EnemyData EnemyDataScript { get; set; }
    [SerializeField]
    private float movSpeed;
    public float MovSpeed { get { return movSpeed; } protected set { value = movSpeed; } }

    public abstract bool IsInAttackRange { get; }
    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        EnemyDataScript = GetComponent<EnemyData>();
        EnemyGroundCheckerScript = GetComponentInChildren<EnemyGroundChecker>();
        InitializedEnemyStates();
        stateMachine.SwitchToNewState(StateType.Idle,this);      
     //   Debug.Log(enemyStates[StateType.Idle]);
    } 
    private void InitializedEnemyStates()
    {       
        stateMachine = GetComponent<EnemyStateMachine>();
        stateIndicator = new StateIndicator<StateType, BaseEnemyState>();
        enemyStates = new Dictionary<StateType, BaseEnemyState>();
        List<BaseEnemyState> enemyStateList=stateIndicator.InitializedEnemyStates();
        foreach (var state in enemyStateList)
        {           
            enemyStates.Add(state.stateType, state);
        }
        stateMachine.SetStates(enemyStates);
    }

    public virtual void EnemyMove()
    {
        transform.Translate(Vector2.right * MovSpeed * Time.deltaTime);
    }    

    public void SetMovSpeed(float movSpeed)
    {
        this.movSpeed = movSpeed;
    }

    public Vector2 FindTargetsDirection()
    {
        Vector2 direction = transform.position - Target.transform.position;

        return (direction.x < 0) ? Vector2.left : Vector2.right;
    }
    public void ChangeDirectionAccordingToTheTarget()
    {
        Debug.Log("Direction Changed");
        if (FindTargetsDirection()==Vector2.left && !EnemyDataScript.isCharacterFacingRight)
        {
            EnemyDataScript.ChangeCharacterDirection();
        }
        else if (FindTargetsDirection() == Vector2.right && EnemyDataScript.isCharacterFacingRight)
        {
            EnemyDataScript.ChangeCharacterDirection();
        }
    }

    public abstract StateType GetAttackType();

}
