using UnityEditor;

[CustomEditor(typeof(Gun)), CanEditMultipleObjects]
public class PropertyEditorGun : Editor
{
    //public SerializedProperty
    //    State_Prop,
    //    FireRate_Prop,
    //    MagazineSize_Prop,
    //    MaxAmmo_Prop;

    //private void OnEnable()
    //{
        
    //}

    //public override void OnInspectorGUI()
    //{
    //    serializedObject.Update();

    //    EditorGUILayout.PropertyField(State_Prop);

    //    Gun.GunType gt = (Gun.GunType)State_Prop.enumValueIndex;

    //    switch(gt)
    //    {
    //        case Gun.GunType.AR:

    //            break;
    //        case Gun.GunType.ShotGun:

    //            break;

    //        case Gun.GunType.SubmachineGun:

    //            break;
    //    }

    //    serializedObject.ApplyModifiedProperties();
    //}
}
