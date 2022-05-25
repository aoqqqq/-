using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dong : MonoBehaviour
{
    Move ab;
    int Yesm;//备份索引
    public int idx;//索引 移动索引
    int zt = 0;
    bool boo = true;
    public int a;
    Vector3[] points;//点位置数组

    B GetB;
    private void Awake()
    {
        GetB = GetComponentInParent<B>();
        points = GetB.v2;//获取数组

        idx = GetB.index;//获得索引
        Yesm = idx;//备份索引
        BM();//分配
    }
    void k()
    {

        float x = points[idx].x - GetB.v2[idx].x;
        float y = points[idx].y - GetB.v2[idx].y;
        float z = points[idx].z - GetB.v2[idx].z;
        this.transform.position = points[idx] + new Vector3(x, y, z);//归位置
        points = GetB.v2;
    }
    /// <summary>
    /// 索引分配
    /// </summary>
    void BM()
    {
        if (idx == GetB.v2.Length - 1)
        {
            idx = 0;
        }//避免索引超界
        else
        {
            idx++;//自身索引前面的物体的索引
        }
    }
    /// <summary>
    /// 自身走向前索引
    /// </summary>
    void lep()
    {
        points = GetB.v2;
        if (boo)
        {
            GetB.objindex[Yesm] = idx;


            if (this.transform.position == points[idx])//完成目标后分配其他目标
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
                this.transform.position = Vector3.MoveTowards(transform.position, points[idx], GetB.sp * Time.deltaTime);//自身移动到目标
            }

        }


        //else
        //{
        //    k();
        //    points = GetB.v2; //新位置替换旧位置
        //    idx = Yesm;//归位初始索引
        //    BM();//重新分配索引

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
        //    idx++;//下个目标的索引

        //    if (idx == points.Length)//避免超界
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
