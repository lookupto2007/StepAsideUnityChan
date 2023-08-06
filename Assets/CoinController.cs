using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    //（課題）Unityちゃんの位置を取得する。
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 3, 0);

        //画面外に出たらオブジェクトを破壊する。
        if(transform.position.z + 10.0f < this.unitychan.transform.position.z)
        {
            Destroy(gameObject);
        }

    }


}
