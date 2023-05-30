
using System;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class MonoBehaviourEvents
    {
        public Action<Collider2D> OnTriggerEnter;
        public Action<Collider2D> OnTriggerExit;

        public Action Enabled;
        public Action Disabled;
        public Action Destroyed;
        public Action<float> Updated;
        public Action<float> FixedUpdated;
    }
}