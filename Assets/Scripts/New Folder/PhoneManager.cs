using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public PhoneDatabase phoneDatabase; // Database chứa danh sách phone
    public GameObject phonePrefab; // Prefab của bạn
    public Transform phoneListParent; // Transform chứa danh sách các prefab

    void Start()
    {
        DisplayPhones();
    }

    void DisplayPhones()
    {
        // Xóa tất cả các phone cũ trước khi thêm mới
        foreach (Transform child in phoneListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Phones phone in phoneDatabase.phones)
        {
            GameObject phoneGO = Instantiate(phonePrefab, phoneListParent);
            PhoneDisplay phoneDisplay = phoneGO.GetComponent<PhoneDisplay>();

            if (phoneDisplay != null)
            {
                phoneDisplay.SetPhoneData(phone);
            }
            else
            {
                Debug.LogError("PhoneDisplay component not found in prefab!");
            }
        }
    }
}
