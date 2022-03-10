using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;// variable for Rigidbody
    private GameObject focalPoint; //creatd game object
    private float powerUpStrength = 15; //created inital strength of object varuiable
    public float speed = 5.0f; // Variable  speed for player
    public bool hasPowerUp = false; // created bool telling when powerup is obtained
    public GameObject powerupIndicator; //created game object



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); //assigning game rigidbody to game object
        focalPoint = GameObject.Find("Focal Point"); //assiging game object to focal point
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // getting the input to move player

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed); // applying the force and speed to the player rigidbody

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // calling power up position to spawn 
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp")) //if player has powerup
        {
            hasPowerUp = true; 
            powerupIndicator.gameObject.SetActive(true); // powerup is active
            Destroy(other.gameObject); // when collected power up disappears from game field
            StartCoroutine(PowerupCountdownRoutine()); //having power up disappear after a certain time

        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // once player has powerup it will last 7 seconds
        hasPowerUp = false; // when powerup equals false
        powerupIndicator.gameObject.SetActive(false); // after time has passed set bool back to false
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp) // if player has powerup and collides with enemy
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); //assigning rigid body to enemy and calling collision method
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; // when collision happens with enemy while player has powerup

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse); //enemy will be deflected  away from player at a greater force while player has power up
            Debug.Log("Collided with: " + collision.gameObject.name + " with PowerUp set to " + hasPowerUp);
            // hen player collides with power up and collides with enemy statment is printd to console
        }
    }
}
