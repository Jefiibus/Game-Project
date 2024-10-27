using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    private BoxCollider2D Bc;
    private Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Bc = GetComponent<BoxCollider2D>();
        Rb = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && gameManager.nuggets >= 25)
        {
            gameManager.gameActive = false;
            Debug.Log("Game Over!");
        }
    }
}
