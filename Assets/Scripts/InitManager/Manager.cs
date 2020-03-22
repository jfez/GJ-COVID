using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static int levelIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        levelIndex = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Load");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
