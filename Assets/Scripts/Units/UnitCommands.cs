
using Assets.Scripts.Units.CommandsData;
using System;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public class UnitCommands
    {
        public Action<DamageData> ReceiveDamage;
        public Action<DamageData> RestoreAllHealth;
        public Action<DamageData> RestoreHealth;
        public Action<MovementData> Move;
        public Action<MovementData> Teleport;
        public Action<UnitTeamData> SetTeam;
        public Action<BoolData> Die;
        public Action<BoolData> Revive;
        public Action<BoolData> ResetStats;
        public Action<BoolData> DestroyObject;
    }
}