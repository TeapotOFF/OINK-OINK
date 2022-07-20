using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpAudio;
    private bool _isMoving;
    [SerializeField] private float _maxSpeed = 6f;
    private Vector3 _input;
    [SerializeField] private float _jumpForce = 6f;
    private bool _isGrounded;
    [SerializeField] private Transform _groundCheck;
    private float _radiusCheck = 0.2f;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _canvas;
    private bool facingRight = true;
    private float timeToPress = 0;
    private char[] lang = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    [SerializeField] private MiniGame_2 _miniGame2;
    public char keycode = 'a';
    public int health = 3;

    private PlayerAnimation _animation;
    [SerializeField] private SpriteRenderer _playerSprite;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject _playerAttack;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animation = GetComponentInChildren<PlayerAnimation>();
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _radiusCheck, _whatIsGround);
        if (_miniGame2._playerOnTrigger)
        {
            QTimeEvent();
        }
    }
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (_miniGame2._playerOnTrigger)
        {
            MoveWithQTE();
        }
        else
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
                _animation.Jump();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _animation.Attack();
                _playerAttack.SetActive(true);
            }
        }
    }
    
    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        _input = new Vector2(movement, 0);
        transform.position += _input * _maxSpeed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
        if (movement > 0 && facingRight == false)
        {
            Flip();
        }
        else if (facingRight == true && movement < 0)
        {
            Flip();
        }
        _animation.IsMoving = _isMoving;
    }
    void Jump()
    {
        _jumpAudio.Play();
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void TakeDamage()
    {
        health -= 1;
        _canvas.GetComponent<UIManager>().HealthUpdate(health);
    }
    void QTimeEvent()
    {
        timeToPress += Time.fixedDeltaTime;
        if (timeToPress > 2)
        {
            int num = Random.Range(0, lang.Length);
            keycode = lang[num];
            _canvas.GetComponent<UIManager>().QTEUpdate(keycode);   
            timeToPress = 0;
        }
    }
    void MoveWithQTE()
    {
        if (Input.GetKeyDown($"{keycode}"))
        {
            timeToPress = 2;
            _input = new Vector2(0.8f, 0);
            if (facingRight == false)
            {
                Flip();
            }
            _animation.IsMoving = true;
            _rb.velocity = _input * _maxSpeed;
        }
        if (_rb.velocity == new Vector2(0,0))
        {
           _animation.IsMoving = false;    
        }
    }
}
