using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform playerCamera;
    public float playerActivationDistance;
    bool activate = false;

    private Transform _selection;

    [SerializeField] private string selectableTag = "Selectable";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * playerActivationDistance;

        RaycastHit hit;
        activate = Physics.Raycast(playerCamera.position, playerCamera.TransformDirection(Vector3.forward), out hit, playerActivationDistance);
        
        //Debug Draw ray
        //Debug.DrawRay(transform.position, forward, Color.green);


        //Activates when object is hit by ray
        if (activate)
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                selection.gameObject.GetComponent<Outline>().enabled = true;

                _selection = selection; 
            }

            //Interact with object
            if(selection.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(selection.gameObject);
            }
        }
        else
        {
            _selection.gameObject.GetComponent<Outline>().enabled = false;
        }
        
    }
}
