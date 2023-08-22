using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progessBar : MonoBehaviour
{
   
   // [SerializeField] private Image fill;
   // [SerializeField] private Text amount;

    public int NumberOfHearts;
    Image heartImage;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite EmptyHeart;
  

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }
   
    public void CalculateFillAmount(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.empty:
                heartImage.sprite = EmptyHeart;
                break;
            case HeartStatus.half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.full:
                heartImage.sprite = fullHeart;
                break;

        }
    }
}
public enum HeartStatus
{
    empty = 0,
    half =1,
    full= 2
}
