using UnityEngine;

public class CameraAction : MonoBehaviour
{   
    private Transform cameraTransform { get; set;}=null ;

    void Start()
    {
     cameraTransform = GetComponent<Transform>();   
    }

    
    void Update()
    {
        DrawRay();

        if(Input.GetMouseButtonDown(0))
        {
        
            Vector3 mousePosition = Input.mousePosition ;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane)); //farclipplaine = grand rectangle de la camera 

            if(Physics.Raycast(cameraTransform.position,worldPos - cameraTransform.position, out RaycastHit hit))           //recupere dans la case hit l'objet toucher 
            {
                Debug.Log(hit.transform.name);
                Tower tower = hit.transform.GetComponent<Tower>() ;
                if(tower != null)
                {
                    tower.Upgrade() ;
                }
            }
        }
    }

    private void DrawRay() //tire un rayon de la camera vers la souris
    {
        Vector3 mousePosition = Input.mousePosition ;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane));

        Debug.DrawRay(cameraTransform.position, worldPos - cameraTransform.position, Color.red) ;

    }
}
