using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_CharacterController2D;

public class JumpPad : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        
        FSM_CharacterController2D.CharacterController controller = other.GetComponent<FSM_CharacterController2D.CharacterController>();

        controller.stateController.SetState(State.Jumping);
        controller.motion.rawVelocity += new Vector2(0, 30);
        Debug.Log("OnTriggerEnter2D");
    }
}
