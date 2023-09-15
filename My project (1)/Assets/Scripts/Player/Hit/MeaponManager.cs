using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeaponManager : MonoBehaviour
{
    public Tool currentTool;

    public static UnityAction StartAtackEvent = null;

    public static UnityAction EndAtackEvent = null;

    private bool IsAttackStarted;

    private void OnEnable()
    {
        StartAtackEvent += Attack;
        IsAttackStarted = false;
    }
    protected virtual void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsAttackStarted)
        {
            StartAtackEvent.Invoke();
        }
    }
    private void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    private IEnumerator AttackProcess()
    {
        IsAttackStarted = true;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray.origin, ray.direction * 3, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out MyTree tree))
            {
                Debug.Log("aaaa");
                tree.Health = currentTool.Damage;
            }
        }
        yield return new WaitForSeconds(1);

        IsAttackStarted = false;
        EndAtackEvent?.Invoke();
        
        yield return null;
    }

    private void OnDisable()
    {
        StartAtackEvent -= Attack;
    }
}
