using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentHealthProgress : MonoBehaviour
{
    public GameObject heartPrefab;
    private int baseValue;
    private int maxValue;
    List<progessBar> progessHearts = new List<progessBar>();
    public PlayerStates playerStates;

    private void OnEnable()
    {
        PlayerStates.onPlayerdamage += DrawHearts;

    }
    private void OnDisable()
    {
        PlayerStates.onPlayerdamage -= DrawHearts;

    }
    private void Start()
    {
        DrawHearts();
    }
    public void SetValues(int _basevalue, int _maxValue)
    {
        baseValue = _basevalue;
        maxValue = _maxValue;
        /// amount.text = baseValue.ToString();
    }

    public void DrawHearts()
    {
        ClearHaerts();
        int maxHealthRem = maxValue % 2;
        int heartsTomake = ((maxValue / 2) + maxHealthRem);
        for (int i =0; i < heartsTomake; i++)
        {
            CreateEmptyHeart();
        }
        for (int i = 0; i < progessHearts.Count; i++)
        {
            int heartsstatusRem =(int) Mathf.Clamp(baseValue - (i * 2), 0, 2);
            progessHearts[i].CalculateFillAmount((HeartStatus) heartsstatusRem);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        progessBar HeartComponent = newHeart.GetComponent<progessBar>();
        HeartComponent.CalculateFillAmount(HeartStatus.empty);
        progessHearts.Add(HeartComponent);
    }
    public void ClearHaerts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        progessHearts = new List<progessBar>();

    }
}
