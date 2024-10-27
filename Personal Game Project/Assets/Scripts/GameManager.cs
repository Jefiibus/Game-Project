using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int nuggets;
    public TextMeshProUGUI NuggetAmount;
    public bool gameActive;
    // Start is called before the first frame update
    void Start()
    {
        UpdateNuggets(0);
        gameActive = true;
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
}
