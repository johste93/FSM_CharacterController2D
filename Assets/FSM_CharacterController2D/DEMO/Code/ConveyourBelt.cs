using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_CharacterController2D;

public class ConveyourBelt : MonoBehaviour
{
    public float direction = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        FSM_CharacterController2D.CharacterController controller = other.GetComponent<FSM_CharacterController2D.CharacterController>();

        controller.motion.conveyorSpeed = new Vector2(direction * 3, 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FSM_CharacterController2D.CharacterController controller = other.GetComponent<FSM_CharacterController2D.CharacterController>();

        //inherit half of the speed
        controller.motion.conveyorSpeed = Vector2.zero;
    }
}
