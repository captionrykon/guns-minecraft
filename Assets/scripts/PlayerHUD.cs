using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ParentHealthProgress HeartBar;

    private void Awake()
    {
        HeartBar = GameObject.FindGameObjectWithTag("heart").GetComponent<ParentHealthProgress>();
    }
   
    public void UpdateHealth(int currentHealth ,int maxHealth)
    {
        HeartBar.SetValues(currentHealth, maxHealth);
    }
}


////public void updateWeaponUI(Wapon newWapon)
////{
////    weaponUI.UpdateInfo(newWapon.icon, newWapon.magazineSize, newWapon.storedammo);
////}
////public void updateWeaponAmmoUI(int currentAmmo, int StoredAmmo)
////{
////    weaponUI.updateAmmoUi(currentAmmo,StoredAmmo);
////}

//if (baseValue > maxValue)
//{
//    baseValue = maxValue;
//}

//for (int i = 0; i < hearts.Length; i++)
//{
//    if (i < baseValue)
//    {
//        hearts[i].sprite = fullHeart;

//    }
//    else
//    {
//        hearts[i].sprite = EmptyHeart;
//    }

//    if (i < maxValue)
//    {
//        hearts[i].enabled = true;
//    }
//    else
//    {
//        hearts[i].enabled = false;
//    }

//}
 
//    }
// public void SetValues(int _basevalue, int _maxValue)
//{
//    baseValue = _basevalue;
//    maxValue = _maxValue;
//    /// amount.text = baseValue.ToString();


//}

