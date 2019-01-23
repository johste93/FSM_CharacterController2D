﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Transition_FlutteringToFallingWithoutControl
    {
        public static bool ConditionsMet(CharacterController characterController)
        {
            bool conditionsMet = 
                !characterController.inputInfo.onButtonPressed ||
                characterController.motion.timeSpentFluttering >= characterController.properties.flutterJumpDuration;


            if(conditionsMet)
                characterController.stateController.SetState(State.FallingWithoutControl);

            return conditionsMet;
        }
    }
}
