using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinionOnBoardCondition))]
public class MinionOnBoardConditionPropertyDrawer : PropertyDrawer
{
    private bool isTribeRequiredState = false;
    private bool isInitiallized = false;

    private Rect effectNameRect;
    private Rect boardAllianceRect;
    private Rect minionAmountRect;
    private Rect isTribeRequiredRect;
    private Rect tribeRect;

    private SerializedProperty boardAlliance;
    private SerializedProperty minionAmount;
    private SerializedProperty isTribeRequired;
    private SerializedProperty tribe;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.BeginChangeCheck();

        if (!isInitiallized)
        {
            effectNameRect = new Rect(position.xMin, position.yMin, position.width, 16);
            boardAllianceRect = new Rect(position.x, position.y + 18, position.width, 16);
            minionAmountRect = new Rect(position.x, position.y + 36, position.width, 16);
            isTribeRequiredRect = new Rect(position.x, position.y + 54, position.width, 16);
            tribeRect = new Rect(position.x, position.y + 72, position.width, 16);

            boardAlliance = property.FindPropertyRelative("boardAlliance");
            minionAmount = property.FindPropertyRelative("minionAmount");
            isTribeRequired = property.FindPropertyRelative("isTribeRequired");
            tribe = property.FindPropertyRelative("tribe");

            isTribeRequiredState = isTribeRequired.boolValue;
        }

        EditorGUI.LabelField(effectNameRect, label);

        EditorGUI.indentLevel++;

        EditorGUI.PropertyField(boardAllianceRect, boardAlliance);
        EditorGUI.PropertyField(minionAmountRect, minionAmount);

        isTribeRequired.boolValue = EditorGUI.Toggle(isTribeRequiredRect, "Is Tribe Required", isTribeRequired.boolValue);
        if(isTribeRequired.boolValue == true)
        {
            EditorGUI.PropertyField(tribeRect, tribe);
        }

        EditorGUI.indentLevel--;

        if (EditorGUI.EndChangeCheck())
        {
            if (isTribeRequired.boolValue != isTribeRequiredState) isTribeRequiredState = !isTribeRequiredState;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //check if is tribe required and then change 4 to 5 accoridingly
        return isTribeRequiredState ? EditorGUIUtility.singleLineHeight * 5 + 6 : EditorGUIUtility.singleLineHeight * 4 + 6;
    }
}
