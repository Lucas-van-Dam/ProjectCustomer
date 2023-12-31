using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class KeypadUI : MonoBehaviour
{
    [SerializeField] private List<char> correctCombination;
    [SerializeField] private Door door;
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private AudioClip keyPress;
    [SerializeField] private AudioClip succes;
    [SerializeField] private AudioClip failure;
    [SerializeField] private float deleteKeyPitchLowering;
    [SerializeField] private float keyPitchRange;
    [SerializeField] private FoldersUI folder;

    private GameObject interactor;

    private Keypad keypad;

    private bool done = false;
    
    private List<char> currentCombination = new List<char>();

    private AudioSource audioSource;
    private float defaultPitch;
    
    private bool folderPickedUp = false;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        defaultPitch = audioSource.pitch;
    }

    private void OnEnable()
    {
        UpdateScreen();
    }

    public void Enable(GameObject interactor, Keypad keypad)
    {
        if (folderPickedUp)
            folder.gameObject.SetActive(true);
        this.interactor = interactor;
        this.keypad = keypad;
    }

    public void KeyPressed(string key)
    {
        if (done)
            return;
        PlayKeySound();
        currentCombination.Add(key.ToCharArray().FirstOrDefault());

        if (currentCombination.Count == 4)
        {
            if (currentCombination.SequenceEqual(correctCombination))
            {
                StartCoroutine(QuitScreen());
                done = true;
            }
            else
            {
                audioSource.pitch = defaultPitch;
                audioSource.PlayOneShot(failure);
                currentCombination.Clear();
            }
        }
        UpdateScreen();
    }

    public void DeleteKey()
    {
        audioSource.pitch -= deleteKeyPitchLowering;
        audioSource.PlayOneShot(keyPress);
        audioSource.pitch = defaultPitch;
        if (currentCombination.Count > 0)
        {
            currentCombination.RemoveAt(currentCombination.Count - 1);
            UpdateScreen();
        }
    }

    public void QuitKey()
    {
        keypad.gameObject.GetComponentInChildren<SphereCollider>().GetComponent<MeshRenderer>().material.SetInt("_On", 1);
        audioSource.pitch = defaultPitch;
        audioSource.PlayOneShot(keyPress);
        gameObject.SetActive(false);
        interactor.GetComponent<Movement>().Paralyse();
        folder.gameObject.SetActive(false);
    }

    private void UpdateScreen()
    {
        var combination = string.Empty;
        currentCombination.ForEach(x => combination = string.Concat(combination, x.ToString()));
        codeText.text = combination;
    }

    private void PlayKeySound()
    {
        audioSource.pitch = defaultPitch;
        audioSource.pitch += Random.Range(-keyPitchRange, keyPitchRange);
        audioSource.PlayOneShot(keyPress);
        
    }

    private IEnumerator QuitScreen()
    {
        audioSource.pitch = defaultPitch;
        audioSource.PlayOneShot(succes);
        door.Locked = false;
        yield return new WaitForSeconds(0.5f);
        interactor.GetComponent<Movement>().Paralyse();
        gameObject.SetActive(false);

        folder.gameObject.SetActive(false);
    }


    public void MoveAside()
    {
        folderPickedUp = true;

        foreach (RectTransform transform in GetComponentsInChildren<RectTransform>())
        {
            if (transform == GetComponent<RectTransform>())
                continue;

            transform.position += new Vector3(500, 0, 0);
        }
    }
}
