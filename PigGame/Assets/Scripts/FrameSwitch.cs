using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField] private GameObject activeFrame;
    [SerializeField] private bool exitFrame = true;
    [SerializeField] private bool enterFrame = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&exitFrame)
        {
            activeFrame.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&enterFrame)
        {
            activeFrame.SetActive(true);
        }
    }
}
