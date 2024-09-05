using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneDisplay : MonoBehaviour
{
    public TextMeshProUGUI initialText; // TextMeshProUGUI để hiển thị chữ cái đầu
    public TextMeshProUGUI nameText; // TextMeshProUGUI để hiển thị phoneName
    public Image phoneImage; // Image để hiển thị phoneImage
    public Button detailsButton; // Button để mở chi tiết

    private Phones phoneData; // Dữ liệu phone hiện tại

    public void SetPhoneData(Phones phone)
    {
        if (phone == null)
        {
            Debug.LogError("Phone data is null!");
            return;
        }

        phoneData = phone;

        // Cập nhật text cho chữ cái đầu tiên
        if (!string.IsNullOrEmpty(phone.phoneName))
        {
            initialText.text = phone.phoneName[0].ToString();
        }
        else
        {
            initialText.text = ""; // Hoặc một ký tự mặc định
        }

        // Cập nhật text cho tên
        nameText.text = phone.phoneName;

        // Cập nhật hình ảnh
        phoneImage.sprite = phone.phoneImage;

        // Đăng ký sự kiện cho nút
        if (detailsButton != null)
        {
            detailsButton.onClick.RemoveAllListeners();
            detailsButton.onClick.AddListener(OnDetailsButtonClicked);
        }
        else
        {
            Debug.LogError("Details button is not assigned!");
        }
    }

    private void OnDetailsButtonClicked()
    {
        // Gọi hàm để hiển thị chi tiết phoneData
        PhoneDetailsManager.Instance.ShowPhoneDetails(phoneData);
    }
}
