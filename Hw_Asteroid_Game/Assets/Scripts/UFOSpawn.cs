using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    private PoolUFO _poolUFO;
    [SerializeField] private float speed;
    [SerializeField] private int _ufoCapacity;
    [SerializeField] private float _xStart;
    [SerializeField] private float _yStart;
    [SerializeField] private float ufoHealth;
    [SerializeField] private float moveRangeX;
    [SerializeField] private float shootSkip;

    void Start()
    {
        _poolUFO = new PoolUFO(_ufoCapacity);
        Spawn();
        
    }

    public void Spawn()
    {
        UFO gotUFO = _poolUFO.GetUFO();

        if (gotUFO == null)
        {
            Damage ufoH = new Damage(ufoHealth, ufoHealth);
            Enemy.CreateUFO(new Vector3(_xStart, _yStart, 0), Quaternion.identity, speed, ufoH, moveRangeX, shootSkip);
        }
        else
        {
            gotUFO.ActivateEnemy(new Vector3(_xStart, _yStart, 0), Quaternion.identity);
        }
    }

    public bool ReturnUFOToPool(UFO ufo)
    {
        return _poolUFO.AddUFO(ufo);

    }
}
