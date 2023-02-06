using UnityEngine;

/// <summary>
/// オブジェクトプールに必要な機能
/// </summary>

public class PoolObject : MonoBehaviour
{
    Transform _transform;

    public void InitItem(Vector3 spwanPos)
    {
        _transform = GetComponent<Transform>();
        //アイテムの生成位置を指定
        _transform.position = spwanPos;
        //アイテムをアクティブにする
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "GameOver")
        {
            gameObject.SetActive(false);
        }
    }
}