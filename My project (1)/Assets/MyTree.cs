using System;
using UnityEngine;
using UnityEngine.Events;

public class MyTree : MonoBehaviour, ISelectableObject
{
    public float startHeal;
    public GameObject SelectedUI;

    public GameObject[] DropPrefabs;
    public Transform[] DropPoints;

    public UnityAction TreeHealthChengeEvent;
    public UnityAction TreeDieEvent;

    public event Action SelectableItemDestroyEvent;

    private float health;
    private float Health { get => health;
        set 
        {
            health = Mathf.Clamp(value, 0, startHeal);
            //Debug.Log("tree health " + health);
            TreeHealthChengeEvent?.Invoke();
            if(health == 0)
            {
                TreeDieEvent?.Invoke();
            }
        } 
    }

    private void OnEnable()
    {
        TreeDieEvent += OnDie;
    }

    private void Start()
    {
        Health = startHeal;
    }

    private void OnDie()
    {
        foreach(var dropPoint in DropPoints)
        {
            var prefab = DropPrefabs[UnityEngine.Random.Range(0, DropPrefabs.Length)];

            Instantiate(prefab, dropPoint.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
        SelectableItemDestroyEvent.Invoke();
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
    }

    public void Interact()
    {

    }

    public void Disalect()
    {
        SelectedUI.SetActive(false);
    }
    public void Select()
    {
        SelectedUI.SetActive(true);
    }
    private void OnDisable()
    {
        TreeDieEvent -= OnDie;
    }
}
