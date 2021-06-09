using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlHelicoptero : MonoBehaviour
{
    
    public GameObject pointer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(transform.position.x, , transform.position.z);
        Vector3 target = new Vector3(pointer.transform.position.x, 15.9f, pointer.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, target, 25f);
    }
}
