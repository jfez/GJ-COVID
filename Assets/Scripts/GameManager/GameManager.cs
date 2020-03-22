using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pause = false;
        pauseCanvas.SetActive (false);
        Manager.levelIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }       
    }

    void Pause ()
    {
        if (pause)
        {
            Time.timeScale = 1f;
            pauseCanvas.SetActive (false);

            pause = false;
        }

        else
        {
            Time.timeScale = 0f;
            pauseCanvas.SetActive (true);

            pause = true;
        }
    }
    
    public void Restart()
    {
        Manager.levelIndex--;
        SceneManager.LoadScene("Load");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Init");
    }

}
