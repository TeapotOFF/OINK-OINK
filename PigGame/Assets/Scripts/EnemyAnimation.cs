using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving;
    [SerializeField] private GameObject _playerAttack;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
    public void AttackPoinDisable()
    {
        if (_enemy.GetComponent<EnemyLogic>().inAttackArea) _player.GetComponent<PlayerController>().TakeDamage();
        _enemy.GetComponent<EnemyLogic>().isAttack = true;
    }
    public void Move(bool isMove)
    { 
        _animator.SetBool("isMoving", isMove);
    }
}
