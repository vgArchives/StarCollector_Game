using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableController1 : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Track"))
        {
            Debug.Log("Estou colidindo com a pista");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Track"))
        {
            Debug.Log("Parei de colidir com a pista");
        }
    }
}
