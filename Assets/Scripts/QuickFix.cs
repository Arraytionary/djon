using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickFix : MonoBehaviour
{
    public void Attack()
    {
        GetComponentInParent<WalkingEnemy>().Attack();
    }
}