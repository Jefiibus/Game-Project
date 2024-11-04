using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int nuggets;
    public TextMeshProUGUI NuggetAmount;
    public TextMeshProUGUI PlayerHealth;
    public bool gameActive;
    private damageable damageable;
    public TextMeshProUGUI gameOverText;
    public Button Restartbutton;
    // Start is called before the first frame update
    void Awake()
    {
        UpdateNuggets(0);
        gameActive = true;
        damageable = GameObject.Find("Player").GetComponent<damageable>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() 
    {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
        Restartbutton.gameObject.SetActive(true);
    }

    public void UpdateNuggets(int nuggetsToAdd)
    {
        nuggets += nuggetsToAdd;
        NuggetAmount.text = "Nuggets: " + nuggets + "/25";
        if (nuggets == 25)
        {
            Debug.Log("You can now get out!");
        }
    }
    public void FixedUpdate()
    {
        if (damageable.IsAlive == false) 
        {
            GameOver();
        }
            
        PlayerHealth.text = "Life: " + damageable.Health + "/3";
    }
}
