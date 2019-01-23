using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Transition_RunningToJumping
    {
        public static bool ConditionsMet(CharacterController characterController)
        {
            bool conditionsMet = 
                JumpedWithinWiggleRoom(characterController);

            if(conditionsMet)
                characterController.stateController.SetState(State.Jumping);

            return conditionsMet;
        }

        public static bool JumpedWithinWiggleRoom(CharacterController characterController)
        {
            return (Time.time - characterController.motion.timeOfLastJumpAttempt) < characterController.properties.wiggleRoomSecounds;
        }
    }
}