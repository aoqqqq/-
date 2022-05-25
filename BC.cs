using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BC
{
    /// <summary>
    /// 贝塞尔2阶
    /// </summary>
    /// <param name="A">A位置</param>
    /// <param name="B">B位置</param>
    /// <param name="C">C位置</param>
    /// <param name="T">T值</param>
    /// <returns></returns>
    private static Vector3 bc2(Vector3 A, Vector3 B, Vector3 C, float T)
    {
        float a = 1 - T;
        float aa = a * a;
        Vector3 A1 = aa * A;
        float b = 2 * T;
        float b1 = 1 - T;
        float b2 = b * b1;
        Vector3 B2 = b2 * B;
        float c = T * T;
        Vector3 C3 = c * C;
        Vector3 bc2ss = A1 + B2 + C3;
        //Vector3 bc2s = Mathf.Pow((1 - T), 2f) * A + 2 * T*(1 - T) * B + Mathf.Pow(T, 2f) * C;
        return bc2ss;
    }
    /// <summary>
    /// 二阶贝塞尔点的位置
    /// </summary>
    /// <param name="A">gameobjA</param>
    /// <param name="B">gameobjB</param>
    /// <param name="C">gameobjC</param>
    /// <param name="point">需要绘制位置的个数</param>
    /// <returns>点的位置</returns>
    public static Vector3[] bc2point_position(Vector3 A, Vector3 B, Vector3 C, int point)
    {
        Vector3[] v = new Vector3[point + 1];
        float y = 0;
        for (int i = 1; i < v.Length; i++)
        {
            float x = 1;

            y += x / (float)point;

            v[i] = bc2(A, B, C, y);

        }
        v[0] = A;
        return v;
    }




    /// <summary>
    /// 三阶贝塞尔
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="C"></param>
    /// <param name="D"></param>
    /// <param name="T"></param>
    /// <returns></returns>
    private static Vector3 bc3(Vector3 A, Vector3 B, Vector3 C,Vector3 D,float T)
    {
        float y = Mathf.Pow(1 - T, 3);
        Vector3 AA = A * y;
        float yy = T*Mathf.Pow(1 - T, 2);
        Vector3 BB = 3 * B * yy;
        float yyy = Mathf.Pow(T,2);
        float yyy1 =1-T;
        Vector3 CC = 3 * C * yyy * yyy1;
        Vector3 DD = D*Mathf.Pow(T, 3);
        Vector3 bc33 = AA + BB + CC + DD;
        return bc33;
    }
    public static Vector3[] bc3point_position(Vector3 A, Vector3 B, Vector3 C, Vector3 D,int point) 
    {
        Vector3[] v = new Vector3[point+1];
        float T = 0;
        for (int i = 1; i < v.Length; i++)
        {
            float d = 1;
             T += d /(float) point;
            v[i] = bc3(A, B, C, D, T);
        }
        v[0] = A;
        return v;
    }
}
