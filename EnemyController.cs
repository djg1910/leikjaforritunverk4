using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
       //ræður hraða á óvinum
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    //leyfir mér að breyta reiknum
    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    //gerir rigidbody og animatorinn virkann
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    //lætur vélmenni snúa sér
    void update()
    {
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;
       

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }


    void FixedUpdate()
    {
        if(!broken)
        {
            return;
        }
        //ræður hreyfingu á óvinum
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    //lætur ruby missa líf ef hún snertir ólagað vélmenni
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    //stoppar reyk sem kemur frá vélmenninu
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        smokeEffect.Stop();
    }
}
