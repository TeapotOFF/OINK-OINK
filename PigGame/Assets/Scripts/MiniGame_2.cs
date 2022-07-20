using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_2 : MonoBehaviour
{
    [SerializeField] private Renderer _enemySprite;
    [SerializeField] private BoxCollider2D _enemyCollider;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    private bool _isAttack = true;
    private Color _color;
    public float _newColor = 0;
    public bool _playerOnTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        _color = _enemySprite.GetComponent<Renderer>().material.color;
        _color.a = _newColor;
        _enemySprite.GetComponent<Renderer>().material.color = _color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerOnTrigger)
        {
            _enemyCollider.enabled = true;
            OpacityUpdate();
            _animator.SetBool("isRun", true);
            Vector3 _playerPos = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _playerPos, 2f * Time.deltaTime);
        }
        else _animator.SetBool("isRun", false);
        //_color.a = _newColor;
        //_enemySprite.GetComponent<Renderer>().material.color = _color;
    }
    private void OpacityUpdate()
    {
        if (_color.a < 1)
        _color.a += 0.5f * Time.deltaTime;
        _enemySprite.material.color = _color;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isAttack)
        {
            _isAttack = false;
            StartCoroutine(takeDamage());
        }
    }
    IEnumerator takeDamage()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log($"{_isAttack}");
        _player.GetComponent<PlayerController>().TakeDamage();
        _isAttack = true;
    }

}
