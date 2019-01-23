using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public enum State
    {
        Idle,
        Falling,
        FallingWithoutControl,
        FallingOfWall,
        Running,
        Jumping,
        WallJumping,
        Fluttering,
        WallSliding
    }
}