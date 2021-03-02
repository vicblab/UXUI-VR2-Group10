using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityManager : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> gravityObjects = new List<Rigidbody>();
    [SerializeField] private bool gravityOn;
    [SerializeField] private GameObject walls;
    void Start()
    {
        foreach (OVRGrabbable grabObj in FindObjectsOfType<OVRGrabbable>())
        {
            gravityObjects.Add(grabObj.gameObject.GetComponent<Rigidbody>());
        }
    }
    public void ToggleGravity(bool to)
    {
        gravityObjects.Clear();
        foreach (OVRGrabbable grabObj in FindObjectsOfType<OVRGrabbable>())
        {
            gravityObjects.Add(grabObj.gameObject.GetComponent<Rigidbody>());
        }
        gravityOn = to;

	

        foreach (Rigidbody rb in gravityObjects)
        {
            rb.useGravity = gravityOn;
            rb.isKinematic = !gravityOn;
        }
    }

    public void ToggleColor(bool to)
    {
	if(to)
	{


		walls.SetActive(false);
	}else{
		walls.SetActive(true);
		GetComponent<AudioSource>().Play(0);
	}
    }


}
