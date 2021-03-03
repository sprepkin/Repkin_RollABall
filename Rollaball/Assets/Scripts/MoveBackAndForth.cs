using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 1f; //creates speed for collectibles

    Vector3 beginPos;
    Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 moveTo = new Vector3(Random.Range(-7, 7), Random.Range(3, 7), Random.Range(-7, 7)); //Creates a random spot for the collectible to move to
        beginPos = transform.position; //Gets the beginning position of collectible
        endPos = beginPos + moveTo; //Sets a value for the end position
    }

    // Update is called once per frame
    void Update()
    {
        //Progress value goes back and forth between 1 and 0 over time
        float progress = Mathf.PingPong(Time.time * speed, 1f);

        //Interpolates a line from the starting point to the random end point and moves the collectible between there
        transform.position = Vector3.Lerp(beginPos, endPos, progress);
    }
}
