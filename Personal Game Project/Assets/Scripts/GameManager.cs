using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int nuggets;
    public TextMeshProUGUI NuggetAmount;
    public TextMeshProUGUI PlayerHealth;
    public bool gameActive;
    private damageable damageable;
    // Start is called before the first frame update
    void Awake()
    {
        UpdateNuggets(0);
        gameActive = true;
        damageable = GameObject.Find("Player").GetComponent<damageable>();
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
        PlayerHealth.text = "Life: " + damageable.Health + "/3";
    }
}
