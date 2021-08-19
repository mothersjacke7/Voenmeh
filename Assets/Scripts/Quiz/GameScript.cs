using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour 
{
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    int score = 0;
    public Text scoreText;
    public GameObject headPanel;

    List<object> qList;
    QuestionList crntQ;
    int randQ;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        score = PlayerPrefs.GetInt("scorenew");
        scoreText.text = "Предметов:" + score.ToString();

    }

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        questionGenerate();
        if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        else headPanel.GetComponent<Animator>().SetTrigger("In");

    }

    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0,qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }

        }
        else
        {
            print("Вы отчислены!");

            SceneManager.LoadScene(6);
        }
        
    }


    public void AnswerBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0])
        {
            print("правильный");
            score++;
            scoreText.text = "Предметов: " + score.ToString();
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene(1);
        }
        else print("Неправильный");
        scoreText.text = "Предметов: " + score.ToString();
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene(1);
        qList.RemoveAt(randQ);
        questionGenerate();

    }


}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}


    
    //void Update()
    //{
   //     scoreText.text = score.ToString();
   // }