﻿using System;

namespace LegacyApp
{
    
    public interface ICreditLimitService
    {
        int GetCreditLimit(string lastName, DateTime dateOfBirth);
    }
    
    public interface IClientRepository
    {
        Client GetById(int clientId);
    }
    
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditService;
        public UserService() : this(new ClientRepository(), new UserCreditService())
        {
        }
        
        public UserService(IClientRepository clientRepository, ICreditLimitService creditService)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsFirstNameCorrect(firstName) || !IsLastNameCorrect(lastName))
            {
                return false;
            }

            if (!IsEmailCorrect(email))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (IsAgeShoudBeRounded(dateOfBirth, now))
            {
                age--;
            }

            if (age < 21)
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            CalculateCreditLimit(user, client);

            if (!IsUserHasGoodCreditLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool IsUserHasGoodCreditLimit(User user)
        {
            return !(user.HasCreditLimit && user.CreditLimit < 500);
        }

        private void CalculateCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }

        private bool IsAgeShoudBeRounded(DateTime dateOfBirth, DateTime now)
        {
            return now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day);
        }

        private bool IsEmailCorrect(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsLastNameCorrect(string lastName)
        {
            return !string.IsNullOrEmpty(lastName);
        }

        private bool IsFirstNameCorrect(string firstName)
        {
            return !string.IsNullOrEmpty(firstName);
        }
    }
}
