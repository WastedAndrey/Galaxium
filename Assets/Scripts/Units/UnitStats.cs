
using Assets.Scripts.General;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public interface IUnitStatsReadOnly
    {
        IReactivePropertyReadOnly<float> Health { get; }
        IReactivePropertyReadOnly<float> AttackDamage { get; }
        IReactivePropertyReadOnly<float> AttackSpeed { get; }
        IReactivePropertyReadOnly<float> MovementSpeed { get; }
    }

    [System.Serializable]
    public class UnitStats : IUnitStatsReadOnly
    {
        [SerializeField]
        private ReactiveProperty<float> _health;
        [SerializeField]
        private ReactiveProperty<float> _attackDamage;
        [SerializeField]
        private ReactiveProperty<float> _attackSpeed;
        [SerializeField]
        private ReactiveProperty<float> _movementSpeed;



        public ReactiveProperty<float> Health { get => _health; set => _health = value; }
        public ReactiveProperty<float> AttackDamage { get => _attackDamage; set => _attackDamage = value; }
        public ReactiveProperty<float> AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
        public ReactiveProperty<float> MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

        // this looks weird a bit, but main goal is to create READ ONLY interface from this class 
        // without creating additional data entities, so objects outside Unit object CAN READ its stats, but CAN NOT WRITE
        IReactivePropertyReadOnly<float> IUnitStatsReadOnly.Health => _health;
        IReactivePropertyReadOnly<float> IUnitStatsReadOnly.AttackDamage => _attackDamage;
        IReactivePropertyReadOnly<float> IUnitStatsReadOnly.AttackSpeed => _attackSpeed;
        IReactivePropertyReadOnly<float> IUnitStatsReadOnly.MovementSpeed => _movementSpeed;

        public void CopyFrom(UnitStats target)
        {
            this._health.Value = target._health.Value;
            this._attackDamage.Value = target._attackDamage.Value;
            this._attackSpeed.Value = target._attackSpeed.Value;
            this._movementSpeed.Value = target._movementSpeed.Value;
        }
    }
}