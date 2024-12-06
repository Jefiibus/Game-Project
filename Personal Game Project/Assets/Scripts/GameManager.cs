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
    public TextMeshProUGUI GetOutNotif;
    public AudioClip Nug;
    private AudioSource gameAudio;
    public GameObject TitleScreen;
    private GameObject screen;
    public Button startbutton;
    // Start is called before the first frame update
    void Awake()
    {
        gameAudio = GetComponent<AudioSource>();
        NuggetAmount.text = "Nuggets: 0/25";
        gameActive = false;
        damageable = GameObject.Find("Player").GetComponent<damageable>();
        screen = GameObject.Find("Square");
    }

    public void StartGame()
    {
        gameActive = true;
        NuggetAmount.gameObject.SetActive(true);
        PlayerHealth.gameObject.SetActive(true);
        TitleScreen.gameObject.SetActive(false);
        screen.gameObject.SetActive(false);
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

    private IEnumerator Notif()
    {
        yield return new WaitForSeconds(4);
        GetOutNotif.gameObject.SetActive(false);
    }

    public void UpdateNuggets(int nuggetsToAdd)
    {
        nuggets += nuggetsToAdd;
        NuggetAmount.text = "Nuggets: " + nuggets + "/25";
        gameAudio.PlayOneShot(Nug, 0.3f);
        if (nuggets == 25)
        {
            GetOutNotif.gameObject.SetActive(true);
            StartCoroutine(Notif());
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
