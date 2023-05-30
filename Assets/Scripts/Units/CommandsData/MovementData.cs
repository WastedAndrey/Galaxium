
using UnityEngine;

namespace Assets.Scripts.Units.CommandsData
{
    public class MovementData : SimpleCommandData<Vector2>
    {
        public MovementData(Vector2 initialValue) : base(initialValue) { }
    }
}