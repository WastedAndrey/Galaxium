
using UnityEngine;

namespace Assets.Scripts.Units
{
    public class UnitLink : MonoBehaviour
    {
        [SerializeField]
        private UnitBase _unit;

        public UnitBase Unit => _unit;
    }
}