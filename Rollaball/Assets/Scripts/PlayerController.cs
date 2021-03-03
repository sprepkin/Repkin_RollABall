using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //initial player speed
    public TextMeshProUGUI countText; //public variable for score counter
    public GameObject winTextObject; //public variable for check if won

    private Rigidbody rb; //rigidbody for player
    private int count; 

    private float movementX;
    private float movementY;

    public GameObject spawnablePickup; //set the spawnable pickup (collectible)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //give player rigidbody
        count = 0; //initial count

        SetCountText();
        winTextObject.SetActive(false);
    }

    //When player moves
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //movement direction

        movementX = movementVector.x; //movememnt for x
        movementY = movementVector.y; //movememnt for y
    }

    //Score counter
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //Set count text

        //Check if game is won
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    //for player movement
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //movement vector

        rb.AddForce(movement * speed); //makes player move
    }

    //When object triggers
    private void OnTriggerEnter(Collider other)
    {
        //pickup trigger
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); 
            count = count + 1; //increment count when collectible is picked up

            SetCountText(); //calls the count

            Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(4f, 6f), Random.Range(-5f, 5f)); //Random range of positions that new collectibles respwan at
            Instantiate(spawnablePickup, randomPosition, spawnablePickup.transform.rotation); //creates new collectible when one is collected at random point


        }

        //boost pad trigger
        if (other.gameObject.CompareTag("BoostPad"))
        {
            rb.AddForce(Vector3.up * 500f); //jumps player upwards
        }
    }
}
