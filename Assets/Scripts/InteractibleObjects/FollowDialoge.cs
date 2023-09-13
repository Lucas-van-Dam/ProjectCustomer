using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDialogue : Dialogue
{
    public override void Dissapear()
    {
        GetComponent<ChaseObject>().isFollowActive = true;
    }
}
