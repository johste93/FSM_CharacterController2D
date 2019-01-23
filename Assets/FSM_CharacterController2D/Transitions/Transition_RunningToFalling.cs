using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D{
    public class Transition_RunningToFalling
    {
        public static bool ConditionsMet(CharacterController characterController)
        {
            bool conditionsMet = 
                characterController.motion.combinedVelocity.y < 0f;

            if(conditionsMet)
                characterController.stateController.SetState(State.Falling);

            return conditionsMet;
        }
    }
}
