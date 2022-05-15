using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseControl : MonoBehaviour
{
    GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            gameManager.LoseAction();
        }
    }
}
