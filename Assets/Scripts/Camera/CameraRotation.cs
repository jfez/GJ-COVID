using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        float clampX = Mathf.Clamp(rotation.eulerAngles.x, 0, 65);
        //float clampY = Mathf.Clamp(rotation.eulerAngles.y, -10, 60);
        
        
        rotation.eulerAngles = new Vector3(clampX, 45, rotation.eulerAngles.z);

        transform.rotation = rotation;
        

        //transform.LookAt(player);
    }
}
