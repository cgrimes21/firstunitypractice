using System;

[Serializable]
public class variablereference  {

    public bool UseConstant = true;
    public float ConstantValue;
    public variable Variable;

    public float Value 
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator float(variablereference reference) { return reference.Value; }
}
