using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialLights : MonoBehaviour
{
    [SerializeField] private List<List<GameObject>> lightSequence = new List<List<GameObject>>();
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }

    private IEnumerator TurnOnLights(int step)
    {
        foreach (GameObject light in lightSequence[step])
        {
            
        }
        yield return 0;
    }
}
