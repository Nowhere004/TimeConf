﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeleeAttack
{   
    bool IsInMeleeAttackRangeFunc();
    float MeleeAttackAggro { get; }
}
