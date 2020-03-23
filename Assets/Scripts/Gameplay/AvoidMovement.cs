using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvoidMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animPuerta;
    public AudioSource audioPuerta;
    public AudioClip doorClosing;
    public GameObject colliderNextLevel;
    public BoxCollider doorCollider;

    public Text textTime1;
    public Text textTime2;

    private bool timeIsTicking;
    private float timer;
    private bool end;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        timeIsTicking = false;
        timer = 3f;
        textTime1.enabled = false;
        textTime2.enabled = false;
        end = false;
        colliderNextLevel.SetActive(true);
        doorCollider.enabled = false;
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsTicking && timer > 0)
        {
            timer -= Time.deltaTime;
            textTime1.text = "" + timer.ToString("f0");
            textTime2.text = "" + timer.ToString("f0");
        }

        if (timer < 2 && !playerMovement.enabled)
        {
            playerMovement.enabled = true;
        }

        if (timer <= 0 && !end)
        {
            textTime1.enabled = false;
            textTime2.enabled = false;
            animPuerta.SetTrigger("close");
            audioPuerta.clip = doorClosing;
            audioPuerta.PlayDelayed(0.1f);
            colliderNextLevel.SetActive(false);
            doorCollider.enabled = true;
            end = true;
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2f);

        textTime1.enabled = true;
        textTime2.enabled = true;

        timeIsTicking = true;

    }
}
