﻿using UnityEngine;
using System.Collections;
using System;

namespace WeaponSystem
{
    public class MeleeHitbox : MonoBehaviour
    {
        public enum HitboxType
        { 
            basic,
            stun,
            knockback,
        }

        public new Collider2D collider;

        public HitboxType type;
        public Vector2 hitForce;
        public int damage;
        public LayerMask targetLayer;

        private void Start()
        {
            Disable();
        }

        public void Enable() => collider.enabled = true;
        public void Disable() => collider.enabled = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (targetLayer != (targetLayer | (1 << other.gameObject.layer)))
                return;

            Entity e = other.GetComponent<Entity>();
            if (e)
                switch (type)
                {
                    case HitboxType.basic:
                    default:
                        //e.Hit();
                        break;
                    case HitboxType.stun:
                        e.HitWithStun();
                        break;
                    case HitboxType.knockback:
                        e.HitWithForce(damage, hitForce);
                        break;
                }
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + transform.TransformVector(collider.offset), transform.position + transform.TransformVector(collider.offset) + (Vector3)hitForce.normalized);
        }
    }
    
}