using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string scenename;
    // Start is called before the first frame update
    public void ChangerScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
