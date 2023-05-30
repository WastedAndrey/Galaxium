
using Assets.Scripts.General;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public interface IUnitStatusesReadOnly
    {
        IReactivePropertyReadOnly<bool> IsAlive { get; }
        IReactivePropertyReadOnly<UnitTeam> Team { get; }
    }

    [System.Serializable]
    public class UnitStatuses : IUnitStatusesReadOnly
    {
        [SerializeField]
        private ReactiveProperty<bool> _isAlive = new ReactiveProperty<bool>(true);
        [SerializeField]
        private ReactiveProperty<UnitTeam> _unitTeam;
        public ReactiveProperty<bool> IsAlive { get => _isAlive; set => _isAlive = value; }
        public ReactiveProperty<UnitTeam> Team { get => _unitTeam; set => _unitTeam = value; }
        // this looks weird a bit, but main goal is to create READ ONLY interface from this class 
        // without creating additional data entities, so objects outside Unit object CAN READ its stats, but CAN NOT WRITE
        IReactivePropertyReadOnly<bool> IUnitStatusesReadOnly.IsAlive => _isAlive;
        IReactivePropertyReadOnly<UnitTeam> IUnitStatusesReadOnly.Team => _unitTeam;

        public void CopyFrom(UnitStatuses target)
        {
            this._isAlive.Value = target._isAlive.Value;
            this._unitTeam.Value = target._unitTeam.Value;
        }
    }
}