using Assets.Scripts.ObjectManagement;
using UnityEngine;

public class LimitedLifetime : MonoBehaviour
{
    [SerializeField]
    private float _lifetimeMax;
    [SerializeField]
    private float _lifetimeCurrent;


    private void Awake()
    {
        _lifetimeCurrent = 0;
    }

    void Update()
    {
        _lifetimeCurrent += Time.deltaTime;
        if (_lifetimeCurrent >= _lifetimeMax)
        {
            ObjectManager.Instanse.DestroyObject(this.gameObject);
        }
    }
}
