using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        pauseCanvas.SetActive (false);
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

}
