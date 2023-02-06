using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Generate))]
public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _player = null;

    public GameObject _stage = null;

    private Generate _generate = null;

    // Start is called before the first frame update
    void Start()
    {
        _generate = GetComponent<Generate>();
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        Vector3 stagePosition = _stage.transform.position;
        Vector3 stageScale = _stage.transform.localScale;
        float distanceX = Mathf.Clamp(Random.Range(stagePosition.x - stageScale.x / 2, stagePosition.x + stageScale.x / 2)
                                        , stagePosition.x - stageScale.x / 2
                                        , stagePosition.x + stageScale.x / 2);

        float distanceZ = Random.Range(_player.transform.position.z
                                     , _stage.transform.position.z + _stage.transform.localScale.z / 2);

        Debug.Log($"x = {distanceX}, z = {distanceZ}");

        // オブジェクトをスポーンする座標
        _generate.GeneratePoolObject(new Vector3(distanceX, 3.0f, distanceZ));
        yield return null;
        StartCoroutine(SpawnObstacle());
    }
}
