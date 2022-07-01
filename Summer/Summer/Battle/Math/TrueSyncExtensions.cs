using TrueSync;
using System.Reflection;
using UnityEngine;

/**
* @brief Extensions added by TrueSync.
**/
public static class TrueSyncExtensions
{

    public static TSVector ToTSVector(this Vector3 vector)
    {
        return new TSVector(vector.x, vector.y, vector.z);
    }
    public static TSVector[] ToTSVectorByVectorArray(this Vector3[] vector)
    {
        if (vector == null)
        {
            return null;
        }

        TSVector[] arrary = new TSVector[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            arrary[i] = vector[i].ToTSVector();
        }
        return arrary;
    }

    public static TSVector2 ToTSVector2ByVector3(this Vector3 vector)
    {
        return new TSVector2(vector.x, vector.z);
    }

    public static TSVector ToTSVectorByVector2(this Vector2 vector)
    {
        return new TSVector(vector.x, vector.y, 0);
    }

    public static TSVector ToTSVectorByVector4(this TSVector4 vector)
    {
        return new TSVector(vector.x, vector.y, vector.z);
    }

    public static TSVector2 ToTSVector2(this Vector2 vector)
    {
        return new TSVector2(vector.x, vector.y);
    }

    public static TSVector2[] ToTSVector2ByVectorArray(this Vector2[] vector)
    {
        if (vector == null)
        {
            return null;
        }

        TSVector2[] arrary = new TSVector2[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            arrary[i] = vector[i].ToTSVector2();
        }
        return arrary;
    }

    public static Vector3 Abs(this Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    public static TSQuaternion ToTSQuaternion(this Quaternion rot)
    {
        return new TSQuaternion(rot.x, rot.y, rot.z, rot.w);
    }

    public static Quaternion ToQuaternion(this TSQuaternion rot)
    {
        return new Quaternion((float)rot.x, (float)rot.y, (float)rot.z, (float)rot.w);
    }

    public static TSMatrix ToTSMatrix(this Quaternion rot)
    {
        return TSMatrix.CreateFromQuaternion(rot.ToTSQuaternion());
    }

    public static Vector3 ToVector(this TSVector jVector)
    {
        return new Vector3((float) jVector.x, (float) jVector.y, (float) jVector.z);
    }

    public static Vector3[] ToVectorByVectorArray(this TSVector[] vector)
    {
        if (vector == null)
        {
            return null;
        }

        Vector3[] arrary = new Vector3[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            arrary[i] = vector[i].ToVector();
        }
        return arrary;
    }
    public static Vector3 ToVectorByVector2(this TSVector2 jVector)
    {
        return new Vector3((float)jVector.x, (float)jVector.y, 0);
    }

    public static void Set(this TSVector jVector, TSVector otherVector)
    {
        jVector.Set(otherVector.x, otherVector.y, otherVector.z);
    }

    public static Quaternion ToQuaternionByMatrix(this TSMatrix jMatrix)
    {
        return TSQuaternion.CreateFromMatrix(jMatrix).ToQuaternion();
    }

    public static Vector3 StringToVector3(string verc, char separater = ',')
    {
        if (string.IsNullOrEmpty(verc) || string.IsNullOrEmpty(separater.ToString()))
        {
            return Vector3.zero;
        }
        string[] verc3 = verc.Split(separater);
        if (verc3.Length < 3)
        {
            return Vector3.zero;
        }

        Vector3 back3 = Vector3.zero;
        float result = 0;
        if (float.TryParse(verc3[0], out result))
        {
            back3.x = result;
        }

        if (float.TryParse(verc3[1], out result))
        {
            back3.y = result;
        }

        if (float.TryParse(verc3[2], out result))
        {
            back3.z = result;
        }

        return back3;
    }

    public static TSVector StringToTSVector(string verc, char separater = ',')
    {
        return StringToVector3(verc, separater).ToTSVector();
    }

    #region ChenPlus
    public static Vector2 ToVector2(this TSVector2 jVector)
    {
        return new Vector2((float)jVector.x, (float)jVector.y);
    }

    public static Vector2[] ToVector2ByVectorArray(this TSVector2[] vector)
    {
        if (vector == null)
        {
            return null;
        }

        Vector2[] arrary = new Vector2[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            arrary[i] = vector[i].ToVector2();
        }
        return arrary;
    }
    #endregion
}