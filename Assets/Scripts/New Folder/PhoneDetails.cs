using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhoneDetails : MonoBehaviour
{
    public TextMeshProUGUI nameText; // TextMeshProUGUI để hiển thị tên
    public TextMeshProUGUI numberText; // TextMeshProUGUI để hiển thị số điện thoại
    public Image phoneImage; // Image để hiển thị hình ảnh

    // Hàm này được gọi để thiết lập dữ liệu cho UI
    public void SetPhoneDetails(Phones phone)
    {
        if (phone == null)
        {
            Debug.LogError("Phone data is null!");
            return;
        }

        // Cập nhật text cho tên
        nameText.text = phone.phoneName;

        // Cập nhật text cho số điện thoại
        numberText.text = phone.numberPhone;

        // Cập nhật hình ảnh
        phoneImage.sprite = phone.phoneImage;
    }
}
