using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bonus : MonoBehaviour



{



    private MovementEtTir moveEtTir;


    public int boostType1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveEtTir = collision.gameObject.GetComponent<MovementEtTir>();
            if (gameObject.tag == "Bonus")
            {

                switch (boostType1)
                {

                    case 1:
                        moveEtTir.powerup = false;
                        moveEtTir.powerup2 = true;
                        break;
                    case 0:
                        moveEtTir.powerup = true;
                        moveEtTir.powerup2 = false;
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
