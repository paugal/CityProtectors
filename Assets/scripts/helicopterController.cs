using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlHeliPointer : MonoBehaviour
{

    public float rayLength = 1f;
    private Vector3 validPos;

    public GameObject helicopter;
    public GameObject blades;

    
    void Start(){}

    void Update()
    {
        validMovement();
        followPointer();
        rotateBlades();
        
    }
    
    void rotateBlades()
    {
        blades.transform.Rotate(0, 1000 * Time.deltaTime, 0);
    }

    void followPointer()
    {
        Vector3 target = new Vector3(transform.position.x, 15.9f, transform.position.z);
        helicopter.transform.position = Vector3.MoveTowards(helicopter.transform.position, target, 25f);
    }

    void validMovement()
    {
        //Para solucionar algunos problemas relacionados con el rastreo de la raqueta, forzamos el modelo en una latitud constante.
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        
        //Creamos un rayo para cada direccion
        Ray frontRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        Ray backRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward* -1);
        Ray rightRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.right);
        Ray leftRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.right* -1);
        RaycastHit hit;
        
        //Impedimos que el jugador se salga de los limites
        if (Physics.Raycast(frontRay, out hit, rayLength) ||Physics.Raycast(backRay, out hit, rayLength)||Physics.Raycast(rightRay, out hit, rayLength)||Physics.Raycast(leftRay, out hit, rayLength))
        {
            if (hit.collider.tag == "limit")
            {
                transform.position = validPos;
            }else{
            validPos = transform.position;
            }
        }else{
            validPos = transform.position;
        }
    }
}
