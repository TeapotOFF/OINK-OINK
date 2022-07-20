using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemy.GetComponent<EnemyLogic>().inAttackArea = true;
            _enemy.GetComponent<EnemyLogic>().isangry = true;
            _enemy.GetComponent<EnemyLogic>().ischill = false;
            _enemy.GetComponent<EnemyLogic>().goBack = false;
        }
        else if (collision.gameObject.tag == "Let")
        {
            _enemy.GetComponent<EnemyLogic>().isLet = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemy.GetComponent<EnemyLogic>().inAttackArea = false;
        }
    }
}
