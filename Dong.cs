using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dong : MonoBehaviour
{
    Move ab;
    int Yesm;//��������
    public int idx;//���� �ƶ�����
    int zt = 0;
    bool boo = true;
    public int a;
    Vector3[] points;//��λ������

    B GetB;
    private void Awake()
    {
        GetB = GetComponentInParent<B>();
        points = GetB.v2;//��ȡ����

        idx = GetB.index;//�������
        Yesm = idx;//��������
        BM();//����
    }
    void k()
    {

        float x = points[idx].x - GetB.v2[idx].x;
        float y = points[idx].y - GetB.v2[idx].y;
        float z = points[idx].z - GetB.v2[idx].z;
        this.transform.position = points[idx] + new Vector3(x, y, z);//��λ��
        points = GetB.v2;
    }
    /// <summary>
    /// ��������
    /// </summary>
    void BM()
    {
        if (idx == GetB.v2.Length - 1)
        {
            idx = 0;
        }//������������
        else
        {
            idx++;//��������ǰ������������
        }
    }
    /// <summary>
    /// ��������ǰ����
    /// </summary>
    void lep()
    {
        points = GetB.v2;
        if (boo)
        {
            GetB.objindex[Yesm] = idx;


            if (this.transform.position == points[idx])//���Ŀ����������Ŀ��
            {
                GetB.z1++;
                Debug.Log(GetB.z1);
                boo = false;
                idx++;
                if (idx == GetB.v2.Length)
                {
                    idx = 0;
                }

                //if (zt == 0)
                //{
                //    //zt++;
                //    //GetB.pos++;
                //}

            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, points[idx], GetB.sp * Time.deltaTime);//�����ƶ���Ŀ��
            }

        }


        //else
        //{
        //    k();
        //    points = GetB.v2; //��λ���滻��λ��
        //    idx = Yesm;//��λ��ʼ����
        //    BM();//���·�������

        //    GetB.pos = 0;
        //    GetB.zq = 0;
        //    zt = 0;
        //}

    }
    private void FixedUpdate()
    {
        //if (GetB.z1 == 0)
        //{
        //    boo = true;
        //}

        if (!boo)
        {
            if (GetB.updatpos())
            {
                boo = true;
            }
        }

    }
    private void LateUpdate()
    {
        if (GetB.ON_OFF)
            lep();

        //if (zt == 1&&GetB.z1<GetB.v2.Length)
        //{  
        //    GetB.z2++; 
        //    GetB.zq++;
        //    zt = 0;
        //    GetB.objindex[Yesm] = idx;
        //    idx++;//�¸�Ŀ�������

        //    if (idx == points.Length)//���ⳬ��
        //    {
        //        idx = 0;
        //    }
        //}

        //if (GetB.zq >= points.Length && boo)
        //{
        //    GetB.z1++;
        //    boo = false;
        //}
        //Debug.Log(GetB.z1 + "Q" + GetB.zq);
        //if (!boo)
        //{
        //    if (GetB.z1== GetB.v2.Length&&GetB.z1 <= GetB.zq)
        //    {  
        //    GetB.zq = 0;
        //    GetB.pos = 0;
        //    }
        //}
        //if (GetB.z1 == 0) 
        //{
        //     boo = false;
        //}

    }
}
