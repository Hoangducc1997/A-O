using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject CharacterShop;
    [SerializeField] GameObject DiamondShop;

    [Header("Character")]
    [SerializeField] CharactersDatabase characterDataBase;
    [SerializeField] Image characterSprite;
    [SerializeField] Text characterName;
    [SerializeField] int currentIDCharShop;
    [SerializeField] Text chacracterUserDiamondShop;

    [SerializeField] GameObject PreviosBtn;
    [SerializeField] GameObject NextBtn;
    [SerializeField] GameObject SelectBtn;
    [SerializeField] GameObject SelectedBtn;
    [SerializeField] GameObject BuyBtn;
    [SerializeField] Text DiamondUserCharShop;

    [Header("Diamond Shop")]
    [SerializeField] Text DiamondUserDiamondShop;

    #region Character Shop

    public void initCharacter()
    {
        currentIDCharShop = 0;
        SetCharacterInfoShop();
        PreviosBtn.SetActive(false);
    }

    public void PreviosCharacter()
    {
        currentIDCharShop -= 1;
        if (currentIDCharShop <= 0)
        {
            PreviosBtn.SetActive(false);
        }
        else
        {
            PreviosBtn.SetActive(true);
        }
        NextBtn.SetActive(true);
        SetCharacterInfoShop();
    }

    // 
    //public void OnPurchaseCharacter(int mount)
    //{
    //    PlayerGameData.Instance.AddDimond(amount);
    //    chacracterUserDiamondShop.text = PlayerGameData.Instance.PlayerData.totalDiamond.ToString();
    //}

    public void NextCharacter()
    {
        currentIDCharShop += 1;
        if (currentIDCharShop <= characterDataBase.CharactersCount)
        {
            NextBtn.SetActive(true);
            SetCharacterInfoShop();
        }
        else
        {
            NextBtn.SetActive(false);
        }
        PreviosBtn.SetActive(true);
        
    }

    public void SelectedNewCharacter()
    {
        PlayerGameData.Instance.UseNewCharacter(currentIDCharShop);
        SetActiveBtnCharacterCustom(true, true);
    }

    public void SetCharacterInfoShop()
    {
        Character characterShop = characterDataBase.GetCharacterByID(currentIDCharShop);
        characterSprite.sprite = characterShop.characterSprite;
        characterName.text = characterShop.characterName;
        
        if(PlayerGameData.Instance.PlayerData == null)
        {
            PlayerGameData.Instance.PlayerData = SaveManager.Load();
        }

        if (PlayerGameData.Instance.PlayerData.currentCharacter == currentIDCharShop)
        {
            SetActiveBtnCharacterCustom(true, true);
        }
        else
        {
            if(PlayerGameData.Instance.PlayerData.listCharacterID.Contains(currentIDCharShop))
            {
                SetActiveBtnCharacterCustom(false, true);
            }
            else
            {
                SetActiveBtnCharacterCustom();
            }
        }
    }

    public void SetActiveBtnCharacterCustom(bool isSelected = false, bool isBougth = false)
    {
        if(!isBougth)
        {
            SelectBtn.SetActive(false);
            SelectedBtn.SetActive(false);
            BuyBtn.SetActive(true);
        }
        else
        {
            SelectedBtn.SetActive(isSelected);
            SelectBtn.SetActive(!isSelected);
            BuyBtn.SetActive(false);
        }
    }

    public void OnClickHideCharacterShop()
    {
        CharacterShop.SetActive(false);

    }

    public void OnClickShowCharacterShop()
    {
        initCharacter();
        CharacterShop.SetActive(true);
        DiamondUserCharShop.text = PlayerGameData.Instance.PlayerData.totalDiamond.ToString();
    }
    #endregion

    #region Diamond Shop
    public void OnPurchaseDiamond(int amount)
    {
        PlayerGameData.Instance.AddDimond(amount);
        DiamondUserDiamondShop.text = PlayerGameData.Instance.PlayerData.totalDiamond.ToString();
    }

    public void OnClickHideDiamondShop()
    {
        DiamondShop.SetActive(false);

        
    }
    public void OnClickShowDiamondShop()
    {
        DiamondShop.SetActive(true);
        if (PlayerGameData.Instance.PlayerData == null)
        {
            PlayerGameData.Instance.PlayerData = SaveManager.Load();
        }
        DiamondUserDiamondShop.text = PlayerGameData.Instance.PlayerData.totalDiamond.ToString();
    }
    
    #endregion
}
