using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトプール作成
/// </summary>
public class Generate : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle = null;

    private List<PoolObject> _list_poolObject = new List<PoolObject>();

    [SerializeField]
    private int _max = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _max; i++)
        {
            PoolObject _poolObject;

            _poolObject = Instantiate(_obstacle).GetComponent<PoolObject>();
            _poolObject.transform.parent = transform;
            _poolObject.gameObject.SetActive(false);
            _list_poolObject.Add(_poolObject);
        }
    }

    /// <summary>
    /// _list_poolObject 内の非アクティブのオブジェクトを探す
    /// </summary>
    /// <param name="spawnPos"></param>
    public void GeneratePoolObject(Vector3 spawnPos)
    {
        for (int i = 0; i < _list_poolObject.Count; i++)
        {
            if (false == _list_poolObject[i].gameObject.activeSelf)
            {
                // 非アクティブのオブジェクトを生成
                _list_poolObject[i].InitItem(spawnPos);
                break;
            }
        }
    }
}
