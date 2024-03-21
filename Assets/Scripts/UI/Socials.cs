using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Socials : MonoBehaviour
{
    // Đường link tới trang MXH
    [SerializeField] string DucfacebookProfileURL = "https://www.facebook.com/Hoangducc1997";
    [SerializeField] string DuctiktokProfileURL = "https://www.tiktok.com/@hoangducc12312997";
    [SerializeField] string DucyoutubeProfileURL = "http://www.youtube.com/@ucngo6151";


    [SerializeField] string thuanProfileFace = "https://www.facebook.com/minhtinh.ng/";
    [SerializeField] string thuanProfileTiktok = "https://www.tiktok.com/@thuanisme1710";
    [SerializeField] string thuanProfileYtb = "https://www.youtube.com/@ThuanNguyenMinh1710";

    [SerializeField] GameObject previousBtn;
    [SerializeField] GameObject NextBtn;

    [SerializeField] Text creatorName;
    [SerializeField] bool isThuan;

    public void OnEnable()
    {
        creatorName.text = "Duc Contract";
        isThuan = false;
        SetActivePreviousNextBtn(false);
    }

    // Phương thức sẽ được gọi khi nút được nhấn
    public void OpenProfileFacebook()
    {
        // Mở trình duyệt mặc định của người dùng và điều hướng đến trang 
       if(!isThuan) Application.OpenURL(DucfacebookProfileURL);
       else Application.OpenURL(thuanProfileFace);
    }

    public void OpenProfileTikTok()
    {
        // Mở trình duyệt mặc định của người dùng và điều hướng đến trang 
        if (!isThuan) Application.OpenURL(DuctiktokProfileURL);
        else Application.OpenURL(thuanProfileTiktok);
    }

    public void OpenProfileYoutube()
    {
        // Mở trình duyệt mặc định của người dùng và điều hướng đến trang 
        if (!isThuan) Application.OpenURL(DucyoutubeProfileURL);
        else Application.OpenURL(thuanProfileYtb);
    }

    public void OnNextClick()
    {
        creatorName.text = "Thuan Contract";
        isThuan = true;
        SetActivePreviousNextBtn(true);
    }
    public void OnPreviousClick()
    {
        creatorName.text = "Duc Contract";
        isThuan = false;
        SetActivePreviousNextBtn(false);
    }

    public void SetActivePreviousNextBtn(bool isnext)
    {
        previousBtn.SetActive(isnext);
        NextBtn.SetActive(!isnext);

    }
}


