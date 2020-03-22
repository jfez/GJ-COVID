using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private AudioSource audioManager;
    public AudioClip pickUpKeyClip;
    public GameObject colliderNextLevel;
    public GameObject puerta;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        colliderNextLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.clip = pickUpKeyClip;
            audioManager.Play();
            colliderNextLevel.SetActive(true);
            puerta.GetComponent<Animator>().SetTrigger("nextLevelEnabled");
            puerta.GetComponent<AudioSource>().Play();
            Destroy(transform.parent.gameObject);
        }
    }
}
