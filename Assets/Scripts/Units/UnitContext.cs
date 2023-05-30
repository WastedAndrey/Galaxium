
using Assets.Scripts.General;
using UnityEngine;

namespace Assets.Scripts.Units
{
    [System.Serializable]
    public class UnitContext
    { // fields inside context are public, but context itself inside unit is private.
      // Context is transfered only to entities, that really require it  
        [Header("Links")]
        public GameObject Model;
        public Collider2D Trigger;
        [Header("Stats")]
        public UnitStats StatsDefault;
        public UnitStats StatsCurrent;
        public UnitStatuses StatusesDefault;
        public UnitStatuses StatusesCurrent;
        public MonoBehaviourEvents MonoBehaviourEvents = new MonoBehaviourEvents();
        public UnitCommands UnitCommands = new UnitCommands();
       
        

        public bool IsAlive { get => StatusesCurrent.IsAlive.Value; set => StatusesCurrent.IsAlive.Value = value; }
        public float HealthMax { get => StatsDefault.Health.Value; set => StatsDefault.Health.Value = value; }
        public float Health { get => StatsCurrent.Health.Value; set => StatsCurrent.Health.Value = value; }
        public float AttackDamage { get => StatsCurrent.AttackDamage.Value; set => StatsCurrent.AttackDamage.Value = value; }
        public float AttackSpeed { get => StatsCurrent.AttackSpeed.Value; set => StatsCurrent.AttackSpeed.Value = value; }
        public float MovementSpeed { get => StatsCurrent.MovementSpeed.Value; set => StatsCurrent.MovementSpeed.Value = value; }
        public UnitTeam Team { get => StatusesCurrent.Team.Value; set => StatusesCurrent.Team.Value = value; }
        public Vector2 MovementVector { get; set; }
    }
}