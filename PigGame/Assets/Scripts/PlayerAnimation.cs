using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving;
    [SerializeField] private GameObject _playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isMoving", IsMoving);
    }
    public void Jump()
    {
        _animator.SetTrigger("takeOff");
    }
    public void Attack()
    {
        _animator.SetTrigger("pigAttack");
    }
    public void AttackPoinDisable()
    {
        _playerAttack.SetActive(false);
    }
}
