using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinalDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip Shot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Movement>().Paralyse();

        // var anim = interactor.GetComponent<Animator>(); 
        // Debug.Log(anim);
        // anim.SetTrigger("End");
        interactor.GetComponent<AudioSource>().PlayOneShot(Shot);
        interactor.GetComponentInChildren<VideoPlayer>().Play();

        foreach (var audio in interactor.GetComponentsInChildren<AudioSource>())
        {
            audio.enabled = false;
        }
    }

    public string getToolTipText()
    {
        return "";
    }
}
