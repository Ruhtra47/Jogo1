using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float moveSpeed;
    [SerializeField] private SpriteRenderer roboti;
    [SerializeField] private Animator animation;
    private Vector2 direction;
    public float vida;
    void Start()
    {
        
    }


    void Update()
    {
        Vector2 positionplayer = this.player.position;
        Vector2 yourposition = this.transform.position;
        direction = positionplayer - yourposition;
        direction = direction.normalized;

        this.rig.velocity = (this.moveSpeed) * direction;
        if(this.rig.velocity.x > 0)
        {
            this.roboti.flipX = false;
		    animation.SetBool("runing", true);
        }
        if(this.rig.velocity.x < 0)
        {
            this.roboti.flipX = true;
           	animation.SetBool("runing", true);
        }


        if(vida < 1)
        {
            Destroy(gameObject);
        }
    }
    public void tomoudano()
    {
        vida -= Player.instance.dano;
    }
}
