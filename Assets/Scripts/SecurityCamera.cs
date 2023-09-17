using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float smoothing;
    
    private Transform player;

    private RaycastHit hit;

    private Quaternion targetRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, range))
        {
            if (hit.collider.CompareTag(player.tag))
            {
                targetRotation = Quaternion.LookRotation(player.position - transform.position);
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothing);
    }
}
