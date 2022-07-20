using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollision : MonoBehaviour
{
    [SerializeField] private GameObject _gameBoard;
    [SerializeField] private MiniGame_1 _game;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lock")) {  Destroy(gameObject); MiniGame_1._gameScore += 1; }
        else if (collision.CompareTag("Back")) {Destroy(gameObject); MiniGame_1._gameScore -= 1; Debug.Log(MiniGame_1._gameScore); }
        //Debug.Log(gameObject);
        //_miniGame.DestroyObject(collision);
    }
}
