using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType
    {
        Bow,    
        Gun,
        Hammer,
        Rifle,
        Sword,
        Sycthe
    }

    public WeaponType myWeapon;

    public GameObject _selectWeaponPanel;
    [SerializeField] Button[] weaponSelectButtons;
    

    // Start is called before the first frame update
    void Start()
    {

        SetSelectButton();
    }

    void SetSelectButton()
    {
        weaponSelectButtons[0].onClick.AddListener(() => SetWeapon(WeaponType.Bow));
        weaponSelectButtons[1].onClick.AddListener(() => SetWeapon(WeaponType.Gun));
        weaponSelectButtons[2].onClick.AddListener(() => SetWeapon(WeaponType.Hammer));
        weaponSelectButtons[3].onClick.AddListener(() => SetWeapon(WeaponType.Rifle));
        weaponSelectButtons[4].onClick.AddListener(() => SetWeapon(WeaponType.Sword));
        weaponSelectButtons[5].onClick.AddListener(() => SetWeapon(WeaponType.Sycthe));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetWeapon(WeaponType _weapon)
    {
        myWeapon = _weapon;
    }

}
