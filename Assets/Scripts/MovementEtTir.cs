using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;


    public float speed = 0.2f;

    public bool powerup = false;
    public bool powerup2 = false;

    public int score = 0;
    public int vie = 3;

    public AudioSource premierSon;
    public AudioSource deuxiemeSon;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {



            premierSon.Play();


            if (powerup)
            {
                GameObject myBullet = Instantiate(bullet, parent.position, parent.rotation);
                myBullet.GetComponent<Bullet>().moveEtTir = this;
                myBullet.transform.localScale = myBullet.transform.localScale * 10;

            }
            else if (powerup2)
            {
                Vector3 decalage = new Vector3(0.5f, 0,0);
                GameObject myBullet = Instantiate(bullet, (parent.position+decalage), parent.rotation);
                myBullet.GetComponent<Bullet>().moveEtTir = this;
                GameObject myBulletDouble = Instantiate(bullet, (parent.position - decalage), parent.rotation);
                myBulletDouble.GetComponent<Bullet>().moveEtTir = this;

            }
            else
            {
                GameObject myBullet = Instantiate(bullet, parent.position, parent.rotation);
                myBullet.GetComponent<Bullet>().moveEtTir = this;
            }
        }

        if(transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }
}
