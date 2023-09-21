using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SequentialLights : MonoBehaviour
{
    [SerializeField] private List<LightBundle> lightSequence = new List<LightBundle>();
    [SerializeField] private float interval;
    [SerializeField] private AudioClip lightTurnOnSound;

    private bool on = false;
    
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
            // StartCoroutine(TurnOnLights(0));
            StartCoroutine(nameof(TurnOnLights), 0);
        }
    }

    private IEnumerator TurnOnLights(int step)
    {
        foreach (GameObject lightObj in lightSequence[step].lights)
        {
            lightObj.GetComponent<LightElement>()?.PlayAudio(lightTurnOnSound);
            lightObj.GetComponentInChildren<Light>().gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(interval);
        if (++step >= lightSequence.Count)
            yield break;
        StartCoroutine(TurnOnLights(step));
    }
}

[System.Serializable]
public class LightBundle : IEnumerable
{
    public List<GameObject> lights;
    public IEnumerator GetEnumerator()
    {
        yield return GetEnumerator();
    }
}
