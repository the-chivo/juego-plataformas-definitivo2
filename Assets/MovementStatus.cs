using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class MovementStatus : ScriptableObject
{
   public int maxJumps;
   public float maxJumpTime;
   public float peackGravity;
   public float upGravity;
   public float fallGravity;
   public float airFriction;
   public float jumpForce;
   public float groundAceleration;
   public float airAceleration;
   public float maxGroundHorizontalSpeed;
   public float maxAirHorizontalSpeed;
   public float yVelocityLowGravityThreshold;
   public float maxFallSpeed;
}
