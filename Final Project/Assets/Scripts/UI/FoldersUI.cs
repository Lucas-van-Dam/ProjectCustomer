using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoldersUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> images; 
    [SerializeField] private Image imageDisplay;
    [SerializeField] private AudioClip pageTurning;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject pickUpButton;
    [SerializeField] private GameObject leftButtonImage;
    [SerializeField] private GameObject rightButtonImage;


    private AudioSource audioSource; 
    
    private Movement player;
    private int currentImage = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Enable(GameObject interactor)
    {
        imageDisplay.sprite = images[0];
        player = interactor.GetComponent<Movement>();
    }

    public void NextImage()
    {
        imageDisplay.sprite = images[++currentImage > images.Count - 1 ? --currentImage : currentImage];
        audioSource.PlayOneShot(pageTurning);
    }

    public void PreviousImage()
    {
        imageDisplay.sprite = images[--currentImage < 0 ? ++currentImage : currentImage];
        audioSource.PlayOneShot(pageTurning);
    }

    public void Quit()
    {
        gameObject.SetActive(false);
        player.Paralyse();
    }


    public void MoveAside()
    {
        foreach (RectTransform transform in GetComponentsInChildren<RectTransform>())
        {
            if (transform == GetComponent<RectTransform>() || transform.gameObject == leftButtonImage || transform.gameObject == rightButtonImage)
                continue;

            quitButton.SetActive(false);
            pickUpButton.SetActive(false);

            transform.position -= new Vector3(500, 0, 0);
        }
    }

}
