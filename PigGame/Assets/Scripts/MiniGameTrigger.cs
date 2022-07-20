using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public bool gameTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameTrigger = false;
    }
}
