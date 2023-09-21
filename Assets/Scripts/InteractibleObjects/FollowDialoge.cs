using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FollowDialogue : Dialogue
{
    [SerializeField]
    NavEnd navEnd;

    Transform target;

    public override void Interact(GameObject interactor)
    {
        base.Interact(interactor);

        target = interactor.transform;

    }

    [YarnCommand("activateNav")]
    public void activateNav()
    {
        navEnd.gameObject.SetActive(true);

        GetComponent<ChaseObject>().target = target;
        GetComponent<ChaseObject>().isFollowActive = true;
    }
}
