using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefab������
    public GameObject carPrefab;

    //coinPrefab������
    public GameObject coinPrefab;

    //cornPrefab������
    public GameObject cornPrefab;

    //�X�^�[�g�n�_
    private int startPos = 80;

    //�S�[���n�_
    private int goalPos = 360;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //�i�ۑ�jUnity�����̈ʒu���擾����B
    private GameObject unitychan;

    //�A�C�e���ʒu���L��
    private int itemPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");

        //�ŏ��̃A�C�e���̈ʒu��ݒ肷��B
        itemPositionZ = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //���̋������ƂɃA�C�e���𐶐�
        //for (int i = startPos; i < goalPos; i += 15)
        //Unity�����̈ʒu���猩��50M��܂�
        int unityNow =   (int)unitychan.transform.position.z;

        //�A�C�e���̒ǉ�
        if (itemPositionZ - unityNow <= 50 && goalPos >= itemPositionZ + 15)
        {
            int nextItemPositionZ = itemPositionZ + 15;
                //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //�R�[����x�������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(cornPrefab);
                        cone.transform.position = new Vector3(4 * j, transform.position.y, nextItemPositionZ);
                        itemPositionZ = (int)cone.transform.position.z;
                    }
                }
                else
                {
                    //���[�����ƂɃA�C�e���𐶐�
                    for (int j = -1; j <= 1; j++)
                    {
                        //�A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        //�A�C�e����u��z���W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        //60%�R�C��:30%��:10%�����Ȃ�
                        if (1 <= item && item <= 6)
                        {
                            //�R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextItemPositionZ + offsetZ);
                            itemPositionZ = (int)coin.transform.position.z;
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //�Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextItemPositionZ + offsetZ);
                            itemPositionZ = (int)car.transform.position.z;
                        }
                    }
                }
        }
    }
}
