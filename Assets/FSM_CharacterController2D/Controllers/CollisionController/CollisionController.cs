using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
	public class CollisionController
	{   
		private CharacterController characterController;

		private RaycastInfo raycastInfo;

		private CollisionInfo previousCollisionInfo;

		public void SetReferenceToCharacter(CharacterController characterController)
		{
			this.characterController = characterController;
		}

		public void UpdateCollisions()
		{
			previousCollisionInfo = characterController.collisionInfo;
			characterController.collisionInfo.Reset();

			CollisionInfo velocityCollisionInfo = new CollisionInfo();
			
			//Prepare Raycasting
			raycastInfo.UpdateRaycastOrigins(characterController.transform, characterController.boxCollider2D);
			raycastInfo.CalculateRaySpacing(characterController.transform, characterController.boxCollider2D);

			Vector2 deltaMovement = characterController.motion.combinedVelocity * Time.fixedDeltaTime;

			if(HorizontalCollisionHandling(ref deltaMovement, ref velocityCollisionInfo))
			{
				characterController.motion.rawVelocity.x = 0f;
			}
			if(VerticalCollisionHandling(ref deltaMovement, ref velocityCollisionInfo))
			{
				characterController.motion.rawVelocity.y = 0f;
			}

			//Manage collision info
			characterController.collisionInfo = velocityCollisionInfo;
			CollisionInfo maintainedCollisions = MaintainCollisions();
			characterController.collisionInfo = CollisionInfo.Combine(characterController.collisionInfo, maintainedCollisions);

			characterController.motion.clampedVelocity = deltaMovement / Time.fixedDeltaTime;
		}

		private CollisionInfo MaintainCollisions()
		{
			CollisionInfo collisionInfo = new CollisionInfo();

			if(previousCollisionInfo.right)
			{
				Vector2 vector = (Vector2)characterController.transform.right * RaycastInfo.skinWidth;
				HorizontalCollisionHandling(ref vector, ref collisionInfo);
			}

			if(previousCollisionInfo.left)
			{
				Vector2 vector = -(Vector2)characterController.transform.right * RaycastInfo.skinWidth;
				HorizontalCollisionHandling(ref vector, ref collisionInfo);
			}

			if(previousCollisionInfo.above)
			{
				Vector2 vector = (Vector2)characterController.transform.up * RaycastInfo.skinWidth;
				VerticalCollisionHandling(ref vector, ref collisionInfo);
			}

			if(previousCollisionInfo.below)
			{
				Vector2 vector = -(Vector2)characterController.transform.up * RaycastInfo.skinWidth;
				VerticalCollisionHandling(ref vector, ref collisionInfo);
			}

			
			return collisionInfo;
		}

		private bool HorizontalCollisionHandling(ref Vector2 deltaMovement, ref CollisionInfo collisionInfo)
		{		
			float rayDir = Mathf.Sign(deltaMovement.x);
			float rayLenght = Mathf.Abs(deltaMovement.x) + RaycastInfo.skinWidth;

			for( int i = 0; i < raycastInfo.horizontalRayCount; i++)
			{
				Vector2 rayOrigin = (rayDir == -1) ? raycastInfo.bottomLeft : raycastInfo.bottomRight;
				rayOrigin += (Vector2)characterController.transform.up * (raycastInfo.horizontalRaySpacing * i);

				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, (Vector2)characterController.transform.right * rayDir, rayLenght, characterController.properties.whatIsPlatform);
				if(hit)
				{
					if(hit.distance == 0) //Solves bug where platform moving through passenger would cause jittering in the x axis.
					{
						continue;
					}

					Debug.DrawRay(rayOrigin, (Vector2)characterController.transform.right * rayDir * rayLenght, Color.red);

					deltaMovement.x = Round((hit.distance - RaycastInfo.skinWidth) * rayDir, 6);

					collisionInfo.left = rayDir == -1;
					collisionInfo.right = rayDir == 1;

					return true;
				}
				else
					Debug.DrawRay(rayOrigin, (Vector2)characterController.transform.right * rayDir * rayLenght, Color.yellow);
			}	

			return false;
		}

		private bool VerticalCollisionHandling(ref Vector2 deltaMovement, ref CollisionInfo collisionInfo)
		{
			float rayDir = Mathf.Sign(deltaMovement.y);
			float rayLenght = Mathf.Abs(deltaMovement.y) + RaycastInfo.skinWidth;

			for( int i = 0; i < raycastInfo.verticalRayCount; i++)
			{
				Vector2 rayOrigin = (rayDir == -1) ? raycastInfo.bottomLeft : raycastInfo.topLeft;
				rayOrigin += (Vector2)characterController.transform.right * (raycastInfo.verticalRaySpacing * i + deltaMovement.x);

				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, (Vector2)characterController.transform.up * rayDir, rayLenght, characterController.properties.whatIsPlatform);
				if(hit)
				{
					Debug.DrawRay(rayOrigin, (Vector2)characterController.transform.up * rayDir * rayLenght, Color.red);

					deltaMovement.y = Round((hit.distance - RaycastInfo.skinWidth) * rayDir, 6);

					collisionInfo.below = rayDir == -1;
					collisionInfo.above = rayDir == 1;

					return true;
				}
				else
					Debug.DrawRay(rayOrigin, (Vector2)characterController.transform.up * rayDir * rayLenght, Color.yellow);
			}

			return false;
		}

		/// <summary>
		/// Round float to desired number of digits
		/// </summary>
		private float Round(float value, int digits)
		{
			float mult = Mathf.Pow(10.0f, (float)digits);
			return Mathf.Round(value * mult) / mult;
		}
	}
}