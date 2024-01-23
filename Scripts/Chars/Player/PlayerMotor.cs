using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    //Components
    [SerializeField] private NavMeshAgent _playerAgent;

    //Script Classes
    [SerializeField] private GameIAManager _inputActionsManager;
    [SerializeField] private Player _player;

    //Others
    [SerializeField] private float _baseMoveSpeed = 5f;
    [SerializeField] private float _finalMoveSpeed;
    
    private bool _isStunned = false;


    // Start is called before the first frame update
    void Start()
    {
        _finalMoveSpeed = _baseMoveSpeed;        
    }

    void FixedUpdate()
    {
        if(CanMove())
            Move();
    }

    private void Move()
    {
        Vector3 dir = _inputActionsManager.GetMovementDirection().normalized;

        _playerAgent.Move(dir * _finalMoveSpeed * Time.fixedDeltaTime);
    }

    private bool CanMove()
    {
        if(_isStunned)
            return false;
        return true;
    }

    public bool TryApplyMoveSpeed(float modifier)
    {
        if(_isStunned)
            return false;
        
        _finalMoveSpeed *= modifier;
        return true;
    }
}
