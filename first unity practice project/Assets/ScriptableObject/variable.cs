using UnityEngine;

[CreateAssetMenu]
public class variable : ScriptableObject
{

    public float Value;

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public void SetValue(float value){
        Value = value;
    }

    public void ApplyChange(float value){
        Value += value;
    }

}
