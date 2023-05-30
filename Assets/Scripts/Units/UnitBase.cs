
using Assets.Scripts.Units.CommandsData;
using Assets.Scripts.Units.Components;
using System;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public class UnitBase : MonoBehaviour
    {
        [SerializeField]
        private UnitContext _context = new UnitContext();

        [SerializeField]
        protected UnitControllerBase _componentsWrapper;

        public IUnitStatsReadOnly StatsDefault => _context.StatsDefault;
        public IUnitStatsReadOnly StatsCurrent => _context.StatsDefault;
        public IUnitStatusesReadOnly StatusesDefault => _context.StatusesDefault;
        public IUnitStatusesReadOnly StatusesCurrent => _context.StatusesDefault;
        public bool IsAlive => _context.StatusesCurrent.IsAlive.Value;
        public float HealthMax =>  _context.StatsDefault.Health.Value; 
        public float HealthCurrent  => _context.StatsCurrent.Health.Value; 
        public float AttackSpeed => _context.StatsCurrent.AttackSpeed.Value; 
        public float MovementSpeed  => _context.StatsCurrent.MovementSpeed.Value;
        public UnitTeam Team => _context.StatusesCurrent.Team.Value;
        public Vector2 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
   
        
        public event Action<UnitBase, float> DamageReceived;
        public event Action<UnitBase, float> DamageRestored;
        public event Action<UnitBase, UnitTeam> TeamChanged;
        public event Action<UnitBase> Died;
        public event Action<UnitBase> Revived;
        public event Action<UnitBase> Destroyed;
        public event Action<UnitBase> Reseted;
        public event Action<UnitBase, Vector2> Moved;

        private void Awake()
        {
            ResetUnit();

            _componentsWrapper.Init(this, _context);
        }
        public void ResetUnit()
        {
            _context.StatsCurrent.CopyFrom(_context.StatsDefault);
            _context.StatusesCurrent.CopyFrom(_context.StatusesDefault);
            this.gameObject.SetActive(true);
            Reseted?.Invoke(this);
        }

        public void ReceiveDamage(float damage)
        {
            DamageData damageData = new DamageData(damage);
            _context.UnitCommands.ReceiveDamage?.Invoke(damageData);
            DamageReceived?.Invoke(this, damageData.FinalValue);
        }
        public void RestoreAllHealth()
        {
            DamageData restoreData = new DamageData(HealthMax - HealthCurrent);
            _context.UnitCommands.RestoreAllHealth?.Invoke(restoreData);
            DamageRestored?.Invoke(this, restoreData.FinalValue);
        }
        public void RestoreHealth(float health)
        {
            DamageData restoreData = new DamageData(health);
            _context.UnitCommands.RestoreHealth?.Invoke(restoreData);
            DamageRestored?.Invoke(this, restoreData.FinalValue);
        }

        public void Revive()
        {
            BoolData reviveData = new BoolData(true);
            _context.UnitCommands.Revive?.Invoke(reviveData);
            if (reviveData.FinalValue)
                Revived?.Invoke(this);
        }

        public void Die()
        {
            BoolData dieData = new BoolData(true);
            _context.UnitCommands.Die?.Invoke(dieData);
            if (dieData.FinalValue)
                Died?.Invoke(this);
        }

        public void DestroyObject()
        {
            BoolData destroyData = new BoolData(true);
            _context.UnitCommands.DestroyObject?.Invoke(destroyData);
            if (destroyData.FinalValue)
                Destroyed?.Invoke(this);
        }
  
        public void Move(Vector2 movementSpeed)
        {
            MovementData movementData = new MovementData(movementSpeed);
            _context.UnitCommands.Move?.Invoke(movementData);
        }
        public void Teleport(Vector2 position)
        {
            MovementData movementData = new MovementData(position);
            _context.UnitCommands.Teleport?.Invoke(movementData);
        }

        public void SetUnitTeam(UnitTeam team)
        {
            UnitTeamData teamData = new UnitTeamData(team);
            _context.UnitCommands.SetTeam?.Invoke(teamData);
            TeamChanged?.Invoke(this, teamData.FinalValue);
        }

        private void OnEnable()
        {
            _context.MonoBehaviourEvents.Enabled();
        }

        private void OnDisable()
        {
            _context.MonoBehaviourEvents.Disabled();
        }

        private void OnDestroy()
        {
            _context.MonoBehaviourEvents.Destroyed();
        }

        private void Update()
        {
            if (_context.MovementVector != Vector2.zero)
            {
                Moved?.Invoke(this, _context.MovementVector);
                _context.MovementVector = Vector2.zero;
            }
            _context.MonoBehaviourEvents.Updated(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _context.MonoBehaviourEvents.FixedUpdated(Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _context.MonoBehaviourEvents.OnTriggerEnter?.Invoke(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _context.MonoBehaviourEvents.OnTriggerExit?.Invoke(collision);
        }
    }
}