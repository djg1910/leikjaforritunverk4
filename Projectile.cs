using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //lætur hjólið fara áfram
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    //ræður í hvaða átt hjóli fer í
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);

    }

    //eyðileggur hjólið ef það kemur við eitthvað
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    //lagar vélmenni
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
