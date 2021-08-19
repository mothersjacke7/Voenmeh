using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadscore : MonoBehaviour
{
    
    public int scorenew = 0;
    //public Text scoreloadText;
    public Text scorenewText;


    void Start()
    {
        PlayerPrefs.DeleteAll();     

    }


    void Update()
    {
        scorenew = PlayerPrefs.GetInt("score");
        scorenewText.text = "Предметов: " + scorenew.ToString();
        PlayerPrefs.SetInt("scorenew", scorenew);
        if (scorenew == 10)
        {
            SceneManager.LoadScene(7);
        }
    }
}
