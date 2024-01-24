using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEngine;

public class Centepied : MonoBehaviour
{
    [SerializeField]int health;
    [SerializeField]int attackBeforeBreak;
    private bool attackstart;

    void BossStart()
    {
        StartCoroutine(AttackIndicator());
    }

    IEnumerator AttackIndicator()
    {
        yield return new WaitForSeconds(1f);
        attackstart=false;
    }
}
