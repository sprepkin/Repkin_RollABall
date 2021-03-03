using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 1f;

    Vector3 beginPos;
    Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 moveTo = new Vector3(Random.Range(-7, 7), Random.Range(3, 7), Random.Range(-7, 7));
        beginPos = transform.position;
        endPos = beginPos + moveTo;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = Mathf.PingPong(Time.time * speed, 1.2f);

        transform.position = Vector3.Lerp(beginPos, endPos, progress);
    }
}
