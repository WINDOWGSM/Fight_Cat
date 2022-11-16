using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType
    {
        Bow,    
        Bomb,
        Hammer,
        Rifle,
        Sword,
        Sycthe
    }

    public WeaponType myWeapon;

    public GameObject _selectWeaponPanel;
    [SerializeField] Button[] weaponSelectButtons;
    [SerializeField] Image selectWeaponImage;
    
    

    // Start is called before the first frame update
    void Start()
    {

        SetSelectButton();
    }

    void SetSelectButton()
    {
        weaponSelectButtons[0].onClick.AddListener(() => SetWeapon(WeaponType.Bow, weaponSelectButtons[0].GetComponent<Image>()));
        weaponSelectButtons[1].onClick.AddListener(() => SetWeapon(WeaponType.Bomb, weaponSelectButtons[1].GetComponent<Image>()));
        weaponSelectButtons[2].onClick.AddListener(() => SetWeapon(WeaponType.Hammer, weaponSelectButtons[2].GetComponent<Image>()));
        weaponSelectButtons[3].onClick.AddListener(() => SetWeapon(WeaponType.Rifle, weaponSelectButtons[3].GetComponent<Image>()));
        weaponSelectButtons[4].onClick.AddListener(() => SetWeapon(WeaponType.Sword, weaponSelectButtons[4].GetComponent<Image>()));
        weaponSelectButtons[5].onClick.AddListener(() => SetWeapon(WeaponType.Sycthe, weaponSelectButtons[5].GetComponent<Image>()));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetWeapon(WeaponType _weapon, Image _image)
    {
        myWeapon = _weapon;
        selectWeaponImage.sprite = _image.sprite;

    }

}
