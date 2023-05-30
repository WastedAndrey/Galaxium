
using Assets.Scripts.Weapons;

namespace Assets.Scripts.Units.Components
{
    public class WeaponComponent : UnitComponentBase
    {
        private WeaponBase _weapon;

        public WeaponComponent(UnitBase unit, UnitContext unitContext, WeaponBase weapon) : base(unit, unitContext)
        {
            _weapon = weapon;
        }
        public override void Update(float deltaTime) 
        {
            _weapon.Update(deltaTime, _context.AttackSpeed);
        }

        public void Shoot()
        {
            _weapon.Shoot(_unit.Position, _unit.Rotation, _context.AttackDamage, _context.Team);
        }
    }
}