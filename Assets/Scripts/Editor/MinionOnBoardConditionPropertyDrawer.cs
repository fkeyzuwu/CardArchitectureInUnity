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
    private Rect startListenStateRect;
    private Rect stopListenStateRect;
    private Rect boardAllianceRect;
    private Rect minionAmountRect;
    private Rect isTribeRequiredRect;
    private Rect tribeRect;

    private SerializedProperty startListenState;
    private SerializedProperty stopListenState;
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
            effectNameRect =        new Rect(position.xMin, position.yMin, position.width, 16);
            startListenStateRect =  new Rect(position.x, position.y + 18, position.width, 16);
            stopListenStateRect =   new Rect(position.x, position.y + 36, position.width, 16);
            boardAllianceRect =     new Rect(position.x, position.y + 54, position.width, 16);
            minionAmountRect =      new Rect(position.x, position.y + 72, position.width, 16);
            isTribeRequiredRect =   new Rect(position.x, position.y + 90, position.width, 16);
            tribeRect =             new Rect(position.x, position.y + 108, position.width, 16);

            startListenState = property.FindPropertyRelative("startListenState");
            stopListenState = property.FindPropertyRelative("stopListenState");
            boardAlliance = property.FindPropertyRelative("boardAlliance");
            minionAmount = property.FindPropertyRelative("minionAmount");
            isTribeRequired = property.FindPropertyRelative("isTribeRequired");
            tribe = property.FindPropertyRelative("tribe");

            isTribeRequiredState = isTribeRequired.boolValue;
        }

        EditorGUI.LabelField(effectNameRect, label);

        EditorGUI.indentLevel++;

        EditorGUI.PropertyField(startListenStateRect, startListenState);
        EditorGUI.PropertyField(stopListenStateRect, stopListenState);
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
        //check if is tribe required and then change 7 to 6 accoridingly
        return isTribeRequiredState ? EditorGUIUtility.singleLineHeight * 7 + 6 : EditorGUIUtility.singleLineHeight * 6 + 6;
    }
}
