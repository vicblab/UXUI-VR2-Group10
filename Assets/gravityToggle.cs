using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityToggle : MonoBehaviour
{

    private bool gravity=false;
    public GameObject[] pieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter()
    {
        
        if (pieces == null)
            pieces = GameObject.FindGameObjectsWithTag("piece");

        if(gravity){

       //Call SetColor using the shader property name "_Color" and setting the color to red
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            

                foreach (GameObject piece in pieces)
             {
                piece.GetComponent<Rigidbody>().useGravity = false;
                piece.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
             }


        }else{

            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
           

                foreach (GameObject piece in pieces)
             {
                piece.GetComponent<Rigidbody>().useGravity = true;
                piece.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
             }
        }

        gravity = !gravity;

    }
}
