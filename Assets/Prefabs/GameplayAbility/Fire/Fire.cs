using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability/Fire")]
public class Fire : Ability
{
    [SerializeField] TargetScanner scannerPrefab;
    [SerializeField] float range = 2f;
    [SerializeField] float scanDuration = .5f;
    
    [SerializeField] float damage = 40f;
    [SerializeField] float fireDuration = 3f;

    [SerializeField] GameObject scanVFX;
    [SerializeField] GameObject damageVFX;

    TargetScanner scanner;
    public override void ActivateAbility()
    {
        if (!CommitAbility()) return;

        scanner = Instantiate(scannerPrefab);
        scanner.Init(range, scanDuration, scanVFX == null ? null : Instantiate(scanVFX));
        scanner.StartScan();
        scanner.onNewTargetFound += ApplyDamage;


    }

    private void ApplyDamage(GameObject target)
    {
        Debug.Log($"Damaging: {target}");

        HealthComponet targetHealthComp = target.GetComponent<HealthComponet>();
        if (targetHealthComp == null)
            return;

        if (targetHealthComp.GetComponent<ITeamInterface>().GetRelationTowards(OwningAblityComponet.gameObject) != TeamRelation.Hostile) 
            return;

        DurationDamager damager = targetHealthComp.gameObject.AddComponent<DurationDamager>();
        damager.Init(fireDuration, damage, targetHealthComp, OwningAblityComponet.gameObject, damageVFX);
    }
}
