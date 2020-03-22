using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeKey : MonoBehaviour
{
    private AudioSource audioKey;
    
    // Start is called before the first frame update
    void Start()
    {
        audioKey = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            audioKey.Play();
            
        }
    }
}
