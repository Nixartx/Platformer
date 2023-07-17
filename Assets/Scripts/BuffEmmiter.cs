using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmmiter : MonoBehaviour
{
    [SerializeField] private Buff buff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.buffRecieversContainer.TryGetValue(other.gameObject, out var receiver))
        {
            receiver.AddBuff(buff);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameManager.Instance.buffRecieversContainer.TryGetValue(other.gameObject, out var receiver))
        {
            receiver.RemoveBuff(buff);
        }
    }
}


[System.Serializable]
public class Buff
{
    public BuffType type;
    public float additiveBinus;
    public float multipleBinus;
}
public enum BuffType
{
    Damage, Force, Armor
}