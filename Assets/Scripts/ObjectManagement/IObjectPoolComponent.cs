
using System;

namespace Assets.Scripts.ObjectManagement
{
    public interface IObjectPoolComponent
    {
        ObjectPoolTag PoolTag { get; }
        Action Reseted { get; set; }

        void ResetObject();
    }
}