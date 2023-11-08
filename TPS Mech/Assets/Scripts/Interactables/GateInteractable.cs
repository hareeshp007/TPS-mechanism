using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInteractable : MonoBehaviour, IInteractable
{
    public Animator GateAnimator;
    [SerializeField]
    private bool GateOpen=false;

    public void OnInteract()
    {
        GateOpen = !GateOpen;
        GateAnimator.SetBool("OpenGate", GateOpen);
    }
}
