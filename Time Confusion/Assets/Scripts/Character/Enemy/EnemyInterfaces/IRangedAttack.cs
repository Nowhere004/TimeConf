using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangedAttack
{
    bool IsInRangedAttackRangeFunc();
    float RangedAttackAggro { get; }
}
