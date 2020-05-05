using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionControl : MonoBehaviour {

    [SerializeField] public GameObject textGUI;
    [SerializeField] public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            GameObject selection = hit.transform.gameObject;
            Debug.Log("hit " + selection.tag);
            if(selection.CompareTag("Art")){
                textGUI.SetActive(true);
            } else {
                textGUI.SetActive(false);

            }

        }
    }
}
