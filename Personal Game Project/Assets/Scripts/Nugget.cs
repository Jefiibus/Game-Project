using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : MonoBehaviour
{
    private CapsuleCollider2D Bc;
    private Rigidbody2D Rb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Bc = GetComponent<CapsuleCollider2D>();
        Rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            gameManager.UpdateNuggets(1);
        }

    }
}
