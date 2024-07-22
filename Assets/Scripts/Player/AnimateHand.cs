using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty grabAnimation;
    public Animator handAnimation; 
    void Update()
    {
        Pinch();
        Grab(); 
    }

    public void Pinch() { handAnimation.SetFloat("Trigger", pinchAnimation.action.ReadValue<float>()); }
    public void Grab() { handAnimation.SetFloat("Grip", grabAnimation.action.ReadValue<float>()); }
}
