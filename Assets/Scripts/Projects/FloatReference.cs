using System;

[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value => useConstant ? ConstantValue : Variable.Value; 

}