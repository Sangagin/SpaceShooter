using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerteVie : MonoBehaviour
{



    public MovementEtTir MovementEtTir;
    public GameObject keur1;
    public GameObject keur2;
    public GameObject keur3;
    public enemy enemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {






        if (MovementEtTir.vie <= 2)
        {
            keur3.SetActive(false);
        }
        if (MovementEtTir.vie <= 1)
        {
            keur2.SetActive(false);
        }
        if (MovementEtTir.vie <= 0)
        {
            keur1.SetActive(false);
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {

            MovementEtTir.vie--;
            Debug.Log(MovementEtTir.vie);
            Destroy(collision.gameObject);
        }
    }
}
