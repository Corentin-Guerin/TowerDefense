using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float _cameraSpeed = 2.0f ;
    public float cameraSpeed {get {return _cameraSpeed ; } } 
    private Transform cameraTransform { get;set; } = null ;
    public float _borderSize = 10.0f ;
    public float borderSize {get {return _borderSize ; } }

    private const float deadZone = 0.5f ; //ne peut pas etre modifié car constante 
   

    private void Start()
    {
        //deplacement de la camera via l'emplacement de la souris (league of legende)
        cameraTransform = GetComponent<Transform>() ;
    }

    
    private void Update()
    {
        //check de la position de la souris dans l'ecran
        Vector3 mousePos = Input.mousePosition ;
        Vector3 direction = Vector3.zero ;
        
        if(mousePos.x < borderSize || Input.GetAxis("Horizontal") < -deadZone)
        {
            direction += Vector3.left ;
        }
        else if(mousePos.x >= Screen.width - borderSize || Input.GetAxis("Horizontal") > deadZone)        //Screen.width = récupère la taille de l'ecran 
        {
            direction += Vector3.right;
        }

        if(mousePos.y < borderSize || Input.GetAxis("Vertical") < -deadZone)
        {
            direction += Vector3.back;
        }
        else if(mousePos.y >= Screen.height - borderSize || Input.GetAxis("Vertical") > deadZone)        //Screen.width = récupère la taille de l'ecran 
        {
            direction += Vector3.forward;
        }

        direction.Normalize();
        cameraTransform.position += direction * Time.deltaTime * cameraSpeed ;
    }
}