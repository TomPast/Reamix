using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer1 : MonoBehaviour
{
    public static float timer = 300;
    public int timerint;
    public Text timerText;
    public string textaffiche;
    public string nom_joueur = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerint = Mathf.RoundToInt(timer);
        
        
       // PlayerPrefs.SetString("Player1", "Tom "+ScoringSystem.theScore);
        if (timerint > 0)
        {
            timer -= Time.deltaTime;
            formatTimer(timer);
        }
        else if(timerint == 0)
        {
            Debug.Log("je suis la");
            List<string> scores = new List<string>();

            for (int i = 1; i < 6; i++)
            {
                scores.Add(PlayerPrefs.GetString(i.ToString()));
            }
            int j = 1;
            foreach (string item in scores)
            {
                string[] tmp = item.Split(' ');
                
                if (int.Parse(tmp[1]) < ScoringSystem.theScore)
                {
                    Debug.Log(j.ToString() + " "+ScoringSystem.theScore );
                    PlayerPrefs.SetString(j.ToString(), nom_joueur+" "+ScoringSystem.theScore);
                    decallage(j+1, j-1, scores);
                    break;
                    
                }
                j++;
            }
            SceneManager.LoadScene("Assets/testMenu/MenuTest.unity");
        }
    }
    public void decallage(int depart, int depart_liste,List<string> scores)
    {
        for(int i =depart;i < 5; i++)
        {
            PlayerPrefs.SetString(i.ToString(), scores[depart_liste]);
            depart_liste++;
        }
        SceneManager.LoadScene("Assets/testMenu/MenuTest.unity");
    }
    void formatTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }
        textaffiche = " Temps restant : " + minutes.ToString("00") + ":" + seconds.ToString("00");
        timerText.text = " Temps restant : " + minutes.ToString("00") + ":" + seconds.ToString("00");

    }
}
