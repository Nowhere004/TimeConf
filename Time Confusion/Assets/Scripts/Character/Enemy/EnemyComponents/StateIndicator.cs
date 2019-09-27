using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class StateIndicator<TStateEnum,TStateClass> where TStateEnum:Enum where TStateClass:class
{
    private Dictionary<TStateEnum, TStateClass> enemyStates;
    private List<TStateClass> tStateClass;
    public List<TStateClass> InitializedEnemyStates()
    {       
        var enemyStatesTypes = Assembly.GetAssembly(typeof(TStateClass)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(TStateClass)));
        tStateClass = new List<TStateClass>();
        foreach (var type in enemyStatesTypes)
        {
            TStateClass tempState = Activator.CreateInstance(type) as TStateClass;
            tStateClass.Add(tempState);
        }
        return tStateClass;
    }
}
