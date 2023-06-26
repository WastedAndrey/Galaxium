﻿
using Assets.Scripts.ObjectManagement;
using Assets.Scripts.Units.CommandsData;
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class DestroyApplyerComponent : UnitComponentBase
    {
        ObjectManager _objectManager;

        public DestroyApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }
        public override void OnEnable()
        {
            _context.UnitCommands.DestroyObject += Destroy;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.DestroyObject -= Destroy;
        }
        private void Destroy(BoolData destroyData)
        {
            if (destroyData.FinalValue)
                _objectManager.DestroyObject(_unit.gameObject);
        }  
    }
}