using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD_OOP_Task
{
    public class clsUser
    {
        private enum enMode { AddNewUser = 1, UpdateUser = 2, DeleteUser = 3, PrintAllUser }
        static enMode _Mode = enMode.AddNewUser;
        private enum enModeUpdate { EditName = 1, EditEmail = 2, EditPhoneNumber = 3 }
        static enModeUpdate _ModeUpdate ;

     

        List<clsUser> Users = new List<clsUser>();
        private string Name { get; set; }

        private string Email { get; set; }

        private string Phone { get; set; }
        private void InputAddUser()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            Phone = Console.ReadLine();

        }

        private int ChooseUpdateEdit()
        {
            Console.WriteLine("1- Edit Name: ");
            Console.WriteLine("2- Edit Email: ");
            Console.WriteLine("3- Edit Phone: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public static void PrintOperations()
        {
            Console.WriteLine("1- Add User");
            Console.WriteLine("2- Update Data of User");
            Console.WriteLine("3- Delete User");
            Console.WriteLine("4- print All User");
        }
        private void AddUser()
        {
            clsUser user = new clsUser();
            Console.WriteLine("=============================AddUser============================");
            Console.Write("Enter Name: ");
            user.Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            user.Phone = Console.ReadLine();

            Users.Add(user);

            Console.WriteLine($"============================User Information you Enterd================================");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone Number: {user.Phone}");
        }

        private bool IsUserExist(string PhoneNumber)
        {
            foreach (var user in Users)
            {

                if (user.Phone == PhoneNumber) return true;
            }

            return false;
        }

        private clsUser GetUser(string PhoneNumber) {

            foreach (var user in Users)
            {

                if (user.Phone == PhoneNumber) return user;
            }

            return null;

        }

        private void UpdateChoice(enModeUpdate _UpdateChoice , clsUser user)
        {
            string name  , phone , email;

            switch(_UpdateChoice)
            {
                case enModeUpdate.EditName:
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    user.Name = name;
                    break;
                case enModeUpdate.EditPhoneNumber:
                    Console.Write("Enter PhoneNumber: ");
                    phone = Console.ReadLine();
                    user.Phone = phone;
                    break;
                case enModeUpdate.EditEmail:
                    Console.Write("Enter Email: ");
                    email = Console.ReadLine();
                    user.Email = email;
                    break;
            }
        }

       
        private void UpdateUser()
        {
            Console.WriteLine("========================Update Data Of User=========================");
            Console.Write("Enter User Phone Number You Want To Edit: ");
            string PhoneNumber = Console.ReadLine();

            if (IsUserExist(PhoneNumber))
            {
                 _ModeUpdate = (enModeUpdate)ChooseUpdateEdit();
                clsUser user = GetUser(PhoneNumber);
               
                UpdateChoice(_ModeUpdate, user);

                Console.WriteLine($"============================User Information you Edited================================");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone Number: {user.Phone}");

            }
            else
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("This UserPhone Not Found");
            }
        }

        private  void DeleteUser()
        {
            Console.Write("Enter User Phone Number You Want To Delete:");
            string PhoneNumber = Console.ReadLine();

            if(IsUserExist(PhoneNumber))
            {
                Users.Remove(GetUser(PhoneNumber));
            }
            else
            {
                Console.WriteLine("No User with This Phone Number");
                Console.WriteLine("===========================");
            }
        }

        private  void PrintAllUser()
        {
            if(Users.Count <= 0)
            {
                Console.WriteLine("No User in the System Yet");
                return;
            }
            int userscount = 0;
            foreach (var user in Users)
            {
                Console.WriteLine($"User{++userscount}");
                Console.WriteLine($"Name: " + user.Name);
                Console.WriteLine("Email: " + user.Email);
                Console.WriteLine("Phone: " + user.Phone);
                Console.WriteLine("======================");
            }
        }

        private void CRUDOperExecute()
        {
            PrintOperations();
            _Mode = (enMode)Convert.ToInt32(Console.ReadLine());
            switch (_Mode)
            {
                case enMode.AddNewUser:
                    AddUser();
                    break;
                case enMode.UpdateUser:
                    UpdateUser();
                    break;
                case enMode.DeleteUser:
                    DeleteUser();
                    break;
                case enMode.PrintAllUser:
                    PrintAllUser();
                    break;
            }
        }
        public void RunCRUDApp()
        {
            string Continue = "n";

            do
            {
                CRUDOperExecute();
                Console.WriteLine("Do You Want to Make Any Thing Else (Y) or (y) for yes and (N) or (n) for No");
                Continue = Console.ReadLine();
            } while (Continue.ToLower() == "y");
        }

    }
}
