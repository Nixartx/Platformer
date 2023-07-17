using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffReciever : MonoBehaviour
{
    private List<Buff> buffs;
    public Action OnBuffsChanged;

    private void Start()
    {
        buffs = new List<Buff>();
        GameManager.Instance.buffRecieversContainer.Add(gameObject, this);
    }

    public void AddBuff(Buff buff)
    {
        if (!buffs.Contains(buff))
            buffs.Add(buff);
        if (OnBuffsChanged != null)
            OnBuffsChanged();
    }

    public void RemoveBuff(Buff buff)
    {
        if (buffs.Contains(buff))
            buffs.Remove(buff);
        if (OnBuffsChanged != null)
            OnBuffsChanged();
    }
}
