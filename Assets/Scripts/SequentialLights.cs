using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialLights : MonoBehaviour
{
    [SerializeField] private List<List<GameObject>> lightSequence = new List<List<GameObject>>();
    [SerializeField] private float interval;
    [SerializeField] private Material lightMaterial;

    private bool on;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !on)
        {
            on = true;
            StartCoroutine(TurnOnLights(0));
        }
    }

    private IEnumerator TurnOnLights(int step)
    {
        foreach (GameObject light in lightSequence[step])
        {
            light.GetComponent<MeshRenderer>().material = lightMaterial;
        }
        yield return new WaitForSeconds(interval);
        if (++step >= lightSequence.Count)
            yield break;
        StartCoroutine(TurnOnLights(step));
    }
}
