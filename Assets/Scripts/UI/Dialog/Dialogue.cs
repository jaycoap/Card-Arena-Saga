﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; //NPC_NAME

    [TextArea(3, 10)]
    public string[] sentences; //대화 적는 칸 3줄로 확장
}
