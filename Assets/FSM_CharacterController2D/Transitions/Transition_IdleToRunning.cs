using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Transition_IdleToRunning
    {
        public static bool ConditionsMet(CharacterController characterController)
        {
            bool conditionsMet = characterController.inputInfo.onButtonDown && characterController.collisionInfo.below;

            if(conditionsMet)
                characterController.stateController.SetState(State.Running);

            return conditionsMet;
        }
    }
}