using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    [SerializeField] private PressedButton leftBtn;
    public PressedButton LeftBtn => leftBtn;
    
    [SerializeField] private PressedButton rightBtn;
    public PressedButton RightBtn => rightBtn;
    
    [SerializeField] private Button attackBtn;
    public Button AttackBtn => attackBtn;
    
    [SerializeField] private Button jumpBtn;
    public Button JumpBtn => jumpBtn;
}
