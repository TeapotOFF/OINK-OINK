using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTirgger2 : MonoBehaviour
{
    [SerializeField] private GameObject _miniGame2;
    [SerializeField] private GameObject _miniGame2UI;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;
    [SerializeField] private AudioSource _audioSource3;
    public bool _isEnd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_isEnd)
        {
            _audioSource1.Stop();
            _audioSource2.Play();
            _miniGame2.gameObject.GetComponent<MiniGame_2>()._playerOnTrigger = true;
            _miniGame2UI.SetActive(true);
        }
        else if (collision.gameObject.tag == "Player" && _isEnd)
        {
            Time.timeScale = 0;
            _audioSource2.Stop();
            _audioSource3.Play();   
            _miniGame2.gameObject.GetComponent<MiniGame_2>()._playerOnTrigger = false;
            _miniGame2UI.SetActive(false);
            _endGameMenu.SetActive(true);
        }
    }
}
