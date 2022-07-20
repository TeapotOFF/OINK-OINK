using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int positionalOfPatrol;
    [SerializeField] private Transform point;
    [SerializeField] private Transform player;
    [SerializeField] private float stoppingDeistance;
    [SerializeField] private GameObject _petuhAttackPoint;
    [SerializeField] private AudioSource _hitAudio;
    private EnemyAnimation _animation;
    private bool facingRight = false;
    public bool ischill = false;
    public bool isangry = false;
    public bool goBack = false;
    public bool isLet = false;
    public bool inAttackArea = false;
    public bool isAttack = true;
    public int _health = 2;

    void Start()
    {
        _animation = GetComponentInChildren<EnemyAnimation>();
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionalOfPatrol && isangry == false)
        {
            ischill = true;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDeistance)
        {
            goBack = true;
            isangry = false;
        }
        if (ischill == true)
        {
            Chill();
        }
        else if (isangry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
        if (_health == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage()
    {
        _health -= 1;
    }
    private void Chill()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        if (transform.position.x > point.position.x + positionalOfPatrol)
        {
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = false;
            }
        }
        else if (transform.position.x < point.position.x - positionalOfPatrol)
        {
            if (!facingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight=true;
            }
        }
        else if (isLet)
        {
            if (!facingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = true;
                isLet = false;
            }
        }
    }
    private void Angry()
    {
        if (inAttackArea == true)
        {
            _animation.Move(false);
            if (isAttack)
            {
                isAttack = false;
                Attack();
            }
        }
        else
        {
            _animation.Move(true);
            if (transform.position.x > player.position.x)
            {
                if (facingRight)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingRight = false;
                }
            }
            else if (transform.position.x < player.position.x)
            {
                if (!facingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    facingRight = true;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        }
    }
    public void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);
    }
    private void Attack()
    {
        _hitAudio.Play();
        _animation.Attack();
    }
}