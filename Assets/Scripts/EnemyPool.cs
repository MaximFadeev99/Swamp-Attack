using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private const string NinjaPrefabPath = "Enemy Ninja";

    private List<Enemy> _pool = new List<Enemy>();
    private Enemy _ninja;
    private int _ninjaCount = 10;

    protected virtual void Awake()
    {
        Initialize();
    }

    private void Initialize() 
    {
        _ninja = Resources.Load<Enemy>(NinjaPrefabPath);

        for (int i = 1; i <= _ninjaCount; i++)
        {
            Enemy ninja = Instantiate(_ninja, transform);           
            ninja.gameObject.SetActive(false);
            ninja.GetComponent<SpriteRenderer>().sortingOrder = i;
            _pool.Add(ninja);
        }
    }

    public bool TryGetIdleEnemy(out Enemy idleEnemy) 
    {       
        idleEnemy = _pool.First(enemy => enemy.gameObject.activeSelf == false);
        return idleEnemy != null ? true : false;
    }
}