

using TrueSync;

public class FPHelper
{
    public static bool ToFp(string param, out FP ret)
    {
        float value = 0.0f;
        bool result = float.TryParse(param, out value);
        ret = value;
        return result;
    }

    public static FP ToFp(string param)
    {
        float value = 0.0f;
        bool result = float.TryParse(param, out value);
        FP ret = value;
        return ret;
    }
}
