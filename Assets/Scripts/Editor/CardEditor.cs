using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    private Type[] cardEffectImplementations;
    private int cardEffectImplementationTypeIndex;

    private Type[] conditionImplementations;
    private int[] conditionImplementationTypeIndexs = new int[conditionAmount];
    private const int conditionAmount = 5;

    private int currentCardEffectConditions = 0;

    void OnEnable()
    {
        for(int i = 0; i < conditionImplementationTypeIndexs.Length; i++)
        {
            conditionImplementationTypeIndexs[i] = int.MaxValue;
        }
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Card card = target as Card;
        //specify type
        if (card == null) return;

        if (cardEffectImplementations == null || conditionImplementations == null|| GUILayout.Button("Refresh Implementations"))
        {
            //this is probably the most imporant part:
            //find all cardEffectImplementations of INode using System.Reflection.Module
            cardEffectImplementations = GetImplementations<CardEffect>().Where(impl => !impl.IsSubclassOf(typeof(UnityEngine.Object))).ToArray();
            conditionImplementations = GetImplementations<Condition>().Where(impl => !impl.IsSubclassOf(typeof(UnityEngine.Object))).ToArray();
        }

        //select implementation from editor popup
        cardEffectImplementationTypeIndex = EditorGUILayout.Popup(new GUIContent("CardEffect"),
            cardEffectImplementationTypeIndex, cardEffectImplementations.Select(impl => impl.FullName).ToArray());

        for(int i = 0; i < currentCardEffectConditions; i++)
        {
            conditionImplementationTypeIndexs[i] = EditorGUILayout.Popup(new GUIContent("Condition"),
                conditionImplementationTypeIndexs[i], conditionImplementations.Select(impl => impl.FullName).ToArray());
        }

        if (GUILayout.Button("Create CardEffect"))
        {
            //set new value
            CardEffect cardEffect = (CardEffect)Activator.CreateInstance(cardEffectImplementations[cardEffectImplementationTypeIndex]);
            for (int i = 0; i < conditionImplementationTypeIndexs.Length; i++)
            {
                if (conditionImplementationTypeIndexs[i] == int.MaxValue) break;
                Condition condition = (Condition)Activator.CreateInstance(conditionImplementations[conditionImplementationTypeIndexs[i]]);
                cardEffect.activationConditions.Add(condition);
            }
            
            card.effects.Add(cardEffect);
        }

        if(GUILayout.Button("Add Condition"))
        {
            if(currentCardEffectConditions != conditionAmount) currentCardEffectConditions++;
        }

        if (GUILayout.Button("Remove Condition"))
        {
            if(currentCardEffectConditions != 0)
            {
                currentCardEffectConditions--;
                conditionImplementationTypeIndexs[currentCardEffectConditions] = int.MaxValue;
            }
        }
    }

    private static Type[] GetImplementations<T>()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());
        var interfaceType = typeof(T);
        return types.Where(p => interfaceType.IsAssignableFrom(p) && !p.IsAbstract).ToArray();
    }
}
