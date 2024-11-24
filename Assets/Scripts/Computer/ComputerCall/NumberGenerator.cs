using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


namespace FishyBusiness
{
    public class PhoneNumberGenerator : MonoBehaviour
    {
        [SerializeField] private NumPadManager _numPadManager;
        [SerializeField] private TextMeshProUGUI _phoneGeneratedTxt;
        [SerializeField] private TextMeshProUGUI _resultComparaisonTxt;
        [SerializeField] private TextMeshProUGUI phoneCallText;
        
        public TMP_InputField inputField;
        public UnityEvent OnRing;
        public UnityEvent OnFailedRing;
        
        private string phoneNumberGenerated;
        private bool hasPhone;
        
        private void Start()
        {
            SetPhoneNumber();
            
        }

        public void SetPhoneNumber()
        {
            phoneNumberGenerated = PhoneNumberUtilities.GeneratePhoneNumber();
            _phoneGeneratedTxt.text = phoneNumberGenerated;
        }
        
        private void OnEnable()
        {
            _numPadManager.OnCallPressed += CheckNumber;
        }


        private void OnDisable()
        {
            _numPadManager.OnCallPressed -= CheckNumber;
        }
        
        public void CheckNumber() 
        {
            hasPhone = Random.Range(0, 2) == 0;
            
            string userInputNumber = inputField.text;

            if (userInputNumber == phoneNumberGenerated)
            {
                _resultComparaisonTxt.text = "Right Number";
                _resultComparaisonTxt.color = Color.green;
                if (hasPhone)
                {
                    phoneCallText.text = "Phone Ring";  
                    phoneCallText.color = Color.cyan;
                    OnRing.Invoke();
                }
                else
                {
                    phoneCallText.text = "No Phone Rings!";  
                    phoneCallText.color = Color.red;
                    OnFailedRing.Invoke();
                }
            }
            else
            {
                _resultComparaisonTxt.text = "Wrong Number";
                _resultComparaisonTxt.color = Color.red;
            }
        }
    }
}