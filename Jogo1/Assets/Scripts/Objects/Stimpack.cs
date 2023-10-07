using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimpack : MonoBehaviour
{

	[SerializeField] private AudioSource sound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.instance.heal();
            sound.Play();
        }




    }
}
