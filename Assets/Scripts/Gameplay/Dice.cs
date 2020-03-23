using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    public GameObject key;

    private Rigidbody rb;

    public int number;

    public TextMeshProUGUI text;

    private bool check = false;
    private AudioSource audioDice;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        key.SetActive(false);
        audioDice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rb.IsSleeping() && check)
        {
            check = false;

            if (transform.up == Vector3.up)
                number = 2;

            else if (-transform.up == Vector3.up)
                number = 5;

            else if (transform.right == Vector3.up)
                number = 1;

            else if (-transform.right == Vector3.up)
                number = 6;

            else if (transform.forward == Vector3.up)
                number = 3;

            else if (-transform.forward == Vector3.up)
                number = 4;

            int rand = Random.Range(1, 6);

            while (rand == number)
                rand = Random.Range(1, 6);

            text.text = "Too bad, the number I was thinking was " + rand;
        }
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float dirx = Random.Range(0, 500);
            float diry = Random.Range(0, 500);
            float dirz = Random.Range(0, 500);

            //transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.identity;

            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirx, diry, dirz);

            check = true;
            audioDice.Play();

        }
        else if (Input.GetMouseButtonDown(1))
        {
            rb.AddForce(Vector3.up * 1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            text.text = "Okay, okay, easy, I was just kidding, here's the key";

            key.SetActive(true);
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}