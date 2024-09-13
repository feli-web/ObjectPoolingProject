using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    PlayerMovement pm;
    void Start()
    {
        GameObject playerMovementObject = GameObject.Find("Player");
        pm = playerMovementObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, -speed * Time.deltaTime);
        if (transform.position.z  < -3)
        {
            this.gameObject.SetActive(false);
        }
        if (pm.isDead == true)
        {
            speed = 0;
        }
    }
    
}
