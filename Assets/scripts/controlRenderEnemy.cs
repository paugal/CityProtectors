using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlRenderEnemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distPlayer1 = Vector3.Distance(enemy.transform.position, player1.transform.position);
        float distPlayer2 = Vector3.Distance(enemy.transform.position, player2.transform.position);
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        if(distPlayer1 < 15 || distPlayer2 < 35){
            render.enabled = true;
        }else{
            render.enabled = false;
        }
        
        

    }
}
