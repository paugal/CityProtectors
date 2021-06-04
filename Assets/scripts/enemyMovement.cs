using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]

public class enemyMovement : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private LineRenderer myLineRender;
    private float timeLine = 0;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        if(this.CompareTag("enemy")){
        myLineRender = GetComponent<LineRenderer>();
        myLineRender.startWidth = 0.15f;
        myLineRender.endWidth = 0.15f;
        myLineRender.positionCount = 0;
        }
        GotoNextPoint();
    }


    void GotoNextPoint() {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f){
            GotoNextPoint();
            
            
        }

        /*
        if(timeLine > 0){
            timeLine =Time.deltaTime - timeLine;
            DrawPath();
        }else{
            //myLineRender.positionCount = 0;
        }
        */
        
        
         
    }

    void DrawPath(){
        myLineRender.positionCount = agent.path.corners.Length;
        myLineRender.SetPosition(0, transform.position);

        if(agent.path.corners.Length < 2){
            return;
        }

        for(int i=1; i < agent.path.corners.Length; i++){
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y+50, agent.path.corners[i].z);
            myLineRender.SetPosition(i, pointPosition);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player2")){
            if(this.CompareTag("enemy")){
                timeLine = 5 + Time.deltaTime;
                DrawPath();

            }
        }
    }
}
