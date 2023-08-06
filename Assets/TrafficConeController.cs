using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficConeController : MonoBehaviour
{
    //（課題）Unityちゃんの位置を取得する。
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {

        //画面外に出たらオブジェクトを破壊する。
        if (transform.position.z + 10.0f < this.unitychan.transform.position.z)
        {
            Destroy(gameObject);
        }

    }
}
