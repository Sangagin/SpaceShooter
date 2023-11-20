using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bonus : MonoBehaviour


{

    private MovementEtTir moveEtTir;


    public int boostType1;

    void Update()
    {
        //destruction des bonus s'ils passent sous le joueur
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }


    //amélioration des tirs ia les bonus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveEtTir = collision.gameObject.GetComponent<MovementEtTir>();
            if (gameObject.tag == "Bonus")
            {

                //changement de tir selon le type du bonus
                switch (boostType1)
                {
                    case 0:
                        moveEtTir.powerup = true;
                        moveEtTir.powerup2 = false;
                        break;

                    case 1:
                        moveEtTir.powerup = false;
                        moveEtTir.powerup2 = true;
                        break;
                }

            }
            else if (gameObject.tag == "Malus")
            {
                moveEtTir.powerup = false;
            }
            Destroy(gameObject);


        }
    }

}
