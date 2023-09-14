using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoldersUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> images; 
    [SerializeField] private Image imageDisplay;
    
    private Movement player;
    private int currentImage = 0;

    public void Enable(GameObject interactor)
    {
        imageDisplay.sprite = images[0];
        player = interactor.GetComponent<Movement>();
    }

    public void NextImage()
    {
        imageDisplay.sprite = images[++currentImage > images.Count - 1 ? --currentImage : currentImage];
    }

    public void PreviousImage()
    {
        imageDisplay.sprite = images[--currentImage < 0 ? ++currentImage : currentImage];
    }

    public void Quit()
    {
        gameObject.SetActive(false);
        player.Paralyse();
    }
    
    
    
    
}
