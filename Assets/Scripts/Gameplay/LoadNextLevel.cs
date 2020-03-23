using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private int numScenes;
    
    // Start is called before the first frame update
    void Start()
    {
        numScenes = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Manager.levelIndex > numScenes)
            {
                SceneManager.LoadScene("Init");
            }

            else
            {
                SceneManager.LoadScene("Load");
            }

            
        }
    }
}
