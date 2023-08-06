using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //cornPrefabを入れる
    public GameObject cornPrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //（課題）Unityちゃんの位置を取得する。
    private GameObject unitychan;

    //アイテム位置を記憶
    private int itemPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //最初のアイテムの位置を設定する。
        itemPositionZ = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //一定の距離ごとにアイテムを生成
        //for (int i = startPos; i < goalPos; i += 15)
        //Unityちゃんの位置から見て50M先まで
        int unityNow =   (int)unitychan.transform.position.z;

        //アイテムの追加
        if (itemPositionZ - unityNow <= 50 && goalPos >= itemPositionZ + 15)
        {
            int nextItemPositionZ = itemPositionZ + 15;
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(cornPrefab);
                        cone.transform.position = new Vector3(4 * j, transform.position.y, nextItemPositionZ);
                        itemPositionZ = (int)cone.transform.position.z;
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン:30%車:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextItemPositionZ + offsetZ);
                            itemPositionZ = (int)coin.transform.position.z;
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextItemPositionZ + offsetZ);
                            itemPositionZ = (int)car.transform.position.z;
                        }
                    }
                }
        }
    }
}
