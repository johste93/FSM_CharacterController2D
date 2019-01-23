using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Transition_FallingToFluttering
    {
        public static bool ConditionsMet(CharacterController characterController)
        {
            bool conditionsMet = 
                characterController.inputInfo.onButtonPressed &&
                characterController.motion.combinedVelocity.y <= characterController.properties.flutterJumpMinimumVelocity;


            if(conditionsMet)
                characterController.stateController.SetState(State.Fluttering);

            return conditionsMet;
        }
    }
}