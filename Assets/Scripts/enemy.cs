using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.XR;
using Unity.VisualScripting;

public class enemy : MonoBehaviour
{

    public TextMeshProUGUI monUI;
    public GameObject circle;
    public GameObject malus;
    public MovementEtTir tiiiiir;
    private Bonus bonus;
    public Rigidbody2D monRB2D;

    public ParticleSystem partSystem;

    public int life;


    public SpriteRenderer spriteRenderer;
    public Sprite spriteBonus1;
    public Sprite spriteBonus2;

    public float sens = -1f;
    private bool attente = true;




    public GameObject bullet;
    public Transform parent;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());

    }

    // Update is called once per frame
    void Update()
    {






        //partie déplacement lattéral des ennemis
        //la partie déplacement verticale est réalisée via le rigidbody

        Vector3 vel = monRB2D.velocity;
        vel.x = -3 * sens;
        monRB2D.velocity = vel;


        //gestion des mouvements et des tirs du boss une fois qu'il est a porté
        if (gameObject.tag == "boss")
        {
            if (gameObject.transform.position.y < 4)
            {
                Vector3 vel2 = monRB2D.velocity;
                vel2.y = 0;
                vel2.x = -2 * sens;
                monRB2D.velocity = vel2;


                GameObject myBullet = Instantiate(bullet, parent.position, parent.rotation);
                myBullet.GetComponent<Bullet>().speed = myBullet.GetComponent<Bullet>().speed * (-1);



            }
        }



        if (attente)
        {
            StartCoroutine(Move());
        }



        //partie mort des ennemis
        if (life <= 0)
        {
            //son explosion
            tiiiiir.deuxiemeSon.Play();


            //possibiilité de bonus
            float randomNumber = Random.Range(0f, 200f);
            if (randomNumber < 80f && randomNumber > 60f)
            {

                spriteRenderer.sprite = spriteBonus1;
                Debug.Log("Type 1 Cree !");
                GameObject bonusCircle = Instantiate(circle, transform.position, transform.rotation);
                bonus = bonusCircle.GetComponent<Bonus>();
                bonus.boostType1 = 0;
            }
            else if (randomNumber < 60f && randomNumber > 40f)
            {
                Debug.Log("Type 2 Cree !");

                spriteRenderer.sprite = spriteBonus2;
                GameObject bonusCircle = Instantiate(circle, transform.position, transform.rotation);
                bonus = bonusCircle.GetComponent<Bonus>();
                bonus.boostType1 = 1;

            }

            else if (randomNumber > 160f)
            {
                GameObject bonusCircle = Instantiate(malus, transform.position, transform.rotation);

            }


            //partie des particules d'explosion
            partSystem = FindObjectOfType<ParticleSystem>();
            ParticleSystem partExplo = Instantiate(partSystem, transform.position, transform.rotation);
            Destroy(gameObject);
            tiiiiir.score++;

            monUI = FindObjectOfType<TextMeshProUGUI>();
            monUI.text = "score : " + tiiiiir.score;
        }
    }




    //co routine de déplacement
    IEnumerator Move()
    {
        attente = false;
        yield return new WaitForSeconds(3); ;

        if (sens == -1f)
        {
            sens = 1f;
        }
        else if (sens == 1f)
        {
            sens = -1f;
        }

        attente = true;
        Debug.Log(sens);


    }


}


