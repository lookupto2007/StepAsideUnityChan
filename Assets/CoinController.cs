using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    //�i�ۑ�jUnity�����̈ʒu���擾����B
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        //��]���J�n����p�x��ݒ�
        this.transform.Rotate(0, Random.Range(0, 360), 0);

        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //��]
        this.transform.Rotate(0, 3, 0);

        //��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�B
        if(transform.position.z + 10.0f < this.unitychan.transform.position.z)
        {
            Destroy(gameObject);
        }

    }


}
