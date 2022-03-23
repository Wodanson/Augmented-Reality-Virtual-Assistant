using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ActionBase : ScriptableObject, IAction
{
    private UnityEvent onFinished = new UnityEvent();
    public UnityEvent OnFinished => onFinished;

    public virtual void Finish()
    {
        Debug.Log("Before");
        onFinished?.Invoke();
        Debug.Log("After");
        onFinished?.RemoveAllListeners();
    }

    public virtual void Next()
    {

    }

    public virtual void Perform()
    {
        //throw new System.NotImplementedException();
    }
}
