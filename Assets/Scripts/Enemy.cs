using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f; //created variable
    private Rigidbody enemyRb; //created game object component
    private GameObject player; //created game object
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); //calling the enemes rigid body element
        player = GameObject.Find("Player"); //finding the player 
}

    // Update is called once per frame
    void Update()
    {// telling the enemy object to find and follow player at a constant speed to not increase
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10) // if object goes past certain point it is destroyed
        {
            Destroy(gameObject);
        }
         
    }
}
