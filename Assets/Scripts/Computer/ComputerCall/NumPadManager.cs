using System;
using UnityEngine;
using TMPro;


namespace FishyBusiness
{
     public class NumPadManager : MonoBehaviour
     {
         [SerializeField] private PhoneNumberGenerator _phoneNumberGenerator;
         public event Action OnCallPressed;

         public void Update()
         {
             if (Input.GetKeyDown(KeyCode.F))
             {
                 Debug.Log(_phoneNumberGenerator.inputField.text);
             }
         }


         public void B0()
         {
             _phoneNumberGenerator.inputField.text += "0";
         }
         public void B1()
         {
             _phoneNumberGenerator.inputField.text+= "1";
         }
         public void B2()
         {
             _phoneNumberGenerator.inputField.text+= "2";
         }
         public void B3()
         {
             _phoneNumberGenerator.inputField.text += "3";
         }
         public void B4()
         {
             _phoneNumberGenerator.inputField.text += "4";
         }
         public void B5()
         {
             _phoneNumberGenerator.inputField.text += "5";
         }
         public void B6()
         {
             _phoneNumberGenerator.inputField.text += "6";
         }
         public void B7()
         {
             _phoneNumberGenerator.inputField.text += "7";
         }
         public void B8()
         {
             _phoneNumberGenerator.inputField.text += "8";
         }
         public void B9()
         {
             _phoneNumberGenerator.inputField.text += "9";
         }
         
         public void Call()
         {
            OnCallPressed?.Invoke();
         }

         public void Erase()
         {
             _phoneNumberGenerator.inputField.text = "";
         }
     }
}