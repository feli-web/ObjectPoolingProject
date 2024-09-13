using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    float counter = 0;
    public PlatformMove pm;
    public TimeAndScore timeAndScore;
    public GameObject mainSpawner;
    public GameOver gm;
    public bool isDead;

    void Start()
    {
        animator.SetBool("IsDead", false);
    }

    void Update()
    {
        // The player will move between -1.5, 0  and 1.5
        this.transform.position = new Vector3(counter,transform.position.y, transform.position.z);
        isDead = animator.GetBool("IsDead");

       if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (counter > -1.5f && isDead == false)
            {
                counter -= 1.5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (counter < 1.5f && isDead == false)
            {
                counter += 1.5f;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            timeAndScore.CoinUp();
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            pm.Stop();
            Destroy(mainSpawner);
            animator.SetBool("IsDead", true);
            timeAndScore.Stop();
            Invoke("GameOver", 2f);
            
        }
    }
    public void GameOver()
    {
        gm.GM();
    }
}
