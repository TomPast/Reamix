using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    string word = null;
    public Text name = null;

    public void PlayGame()
    {
        PlayerPrefs.SetString("nomJoueur", name.text);
        //SceneManager.LoadScene("Assets/Scenes/Levels/Level_1/Level_1_sans_vrtk.unity");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClickKey(string character)
    {
        Debug.Log("Vous avez cliqué sur " + this.word+" "+ name.text);
        word += character;
        Debug.Log("Vous avez cliqué sur " + this.word);
        name.text = word;
    }

}
