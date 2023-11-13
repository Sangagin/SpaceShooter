using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public MovementEtTir moveEtTir;
    private enemy enemy;



    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy") || collision.gameObject.tag == ("boss"))
        {
            enemy = collision.gameObject.GetComponent<enemy>();
            enemy.tiiiiir = moveEtTir;
            enemy.life--;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == ("Player") && tag==("tirBoss"))
        {

            Debug.Log("tapé par boss");
            moveEtTir = collision.gameObject.GetComponent<MovementEtTir>();
            moveEtTir.vie--;

            Destroy(gameObject);
        }


    }



    private void Update()
    {
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -7) { Destroy(gameObject); }
    }

}
