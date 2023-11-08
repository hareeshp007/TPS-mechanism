using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractable : MonoBehaviour, IInteractable
{
    public Animator SwitchAnimator;
    public void OnInteract()
    {
        Debug.Log("switch interacted");
        SwitchAnimator.SetBool("ButtonPressed", true);
    }

    
}
