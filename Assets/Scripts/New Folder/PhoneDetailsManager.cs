using UnityEngine;

public class PhoneDetailsManager : MonoBehaviour
{
    public static PhoneDetailsManager Instance;
    public PhoneDetails phoneDetailsPrefab; // Prefab chứa chi tiết phone
    public Transform detailsPanel; // Panel để chứa PhoneDetails

    private void Awake()
    {
        // Đảm bảo chỉ có một instance của PhoneDetailsManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPhoneDetails(Phones phone)
    {
        // Xóa chi tiết cũ nếu có
        foreach (Transform child in detailsPanel)
        {
            Destroy(child.gameObject);
        }

        // Tạo mới PhoneDetails và cập nhật dữ liệu
        PhoneDetails phoneDetails = Instantiate(phoneDetailsPrefab, detailsPanel);
        phoneDetails.SetPhoneDetails(phone);
    }
}
