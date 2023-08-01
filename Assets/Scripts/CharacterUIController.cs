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
    
    [SerializeField] private PressedButton attackBtn;
    public PressedButton AttackBtn => attackBtn;

    [SerializeField] private Button fireBtn;
    public Button FireBtn => fireBtn;
    
    [SerializeField] private Button jumpBtn;
    public Button JumpBtn => jumpBtn;
}
