using Lab01.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab01.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {

        private int checkedGender;
        DateTime Dob;
        public RegisterPage()
        {
           
            this.InitializeComponent();
        }

        private void btnSubmicClick(object sender, RoutedEventArgs e)
        {
            bool allValid = true;
            var validation = new ValidationInput();
            if (validation.IsEmail(txtEmail.Text))
            {
                msgEmail.Text = "";
            }
            else
            {
                allValid = false;
                msgEmail.Text = "Email invalid";
            }

            if (validation.IsPhoneNumber(txtPhone.Text))
            {
                msgPhone.Text = "";
            }
            else
            {
                allValid = false;
                msgPhone.Text = "Phone invalid";
            }

            if (validation.IsStringInvalid(txtFistName.Text, 2))
            {
                allValid = false;
                msgFistName.Text = "Fist Name must be atlest 2 letters";

            }
            else
            {
                msgFistName.Text = "";
            }

            if (validation.IsStringInvalid(txtLastName.Text, 2))
            {
               
                allValid = false;
                msgLastName.Text = "Last Name must be atlest 2 letters";
            }
            else
            {
                msgLastName.Text = "";
            }

            if (validation.IsStringInvalid(txtAddress.Text, 1))
            {
                allValid = false;
                msgAddress.Text = "Address cant be null";
             
            }
            else
            {
                msgAddress.Text = "";
            }

            if (validation.IsStringInvalid(txtPass.Password, 5))
            {
                
                allValid = false;
                msgPassword.Text = "Password must be atlest 5 letters";
            }
            else
            {
                msgPassword.Text = "";
            }

            if (validation.IsStringInvalid(txtAvatar.Text, 1))
            {
                allValid = false;
                msgAvatar.Text = "Avatar cant be null";
               
            }
            else
            {
                msgAvatar.Text = "";
            }

            if (validation.IsStringInvalid(txtIntro.Text, 1))
            {
                allValid = false;
                msgAvatar.Text = "Avatar cant be null";

            }
            else
            {
                msgAvatar.Text = "";
            }

            if (allValid)
            {
                var account = new Entity.Account();
                account.FistName = txtFistName.Text;
                account.LastName = txtLastName.Text;
                account.Password = txtPass.Password;
                account.Address = txtAddress.Text;
                account.Phone = txtPhone.Text;
                account.Avatar = txtAvatar.Text;
                account.Gender = checkedGender;
                account.Email = txtEmail.Text;
                account.Dob = Dob;
                account.Introduction = txtIntro.Text;
                var jsonAcount = JsonConvert.SerializeObject(account);
                Debug.WriteLine(jsonAcount);
            }
        }

        private void btnResetClick(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFistName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtIntro.Text = "";
            txtPass.Password = "";
            dateDob.SelectedDate = null;
            msgFistName.Text = "";
            msgLastName.Text = "";
            msgAddress.Text = "";
            msgPhone.Text = "";
            msgPassword.Text = "";
            msgAvatar.Text = "";
            msgEmail.Text = "";
        }

        private void HandleChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            switch (rb.Tag)
            {
                case 1:
                    checkedGender = 1;
                    break;
                case 0:
                    checkedGender = 0;
                    break;
                default:
                    break;
            }
        }

        private void HandleDateChange(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if(dateDob.SelectedDate != null)
            {
                Dob = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
        }

     
    }
}
