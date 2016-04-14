﻿using AES.Entities.Contexts;
using AES.Entities.Tables;
using AES.Shared;
using AES.Shared.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace AES.SecuritySvc.Tests
{
    [TestClass]
    public class SecurityUnitTest
    {
        private const string FIRSTNAME = "TestFirst";
        private const string LASTNAME = "TestLast";
        private const string SSN = "11-22-3344";
        private readonly string SSN_CRYPT;
        private readonly DateTime DOB;

        public SecurityUnitTest()
        {
            SSN_CRYPT = Encryption.Encrypt(SSN);
            DOB = new DateTime(1970, 6, 2);

            DBFileManager.SetDataDirectory(true);
        }

        [TestMethod]
        public void TC3_UserExists()
        {
            using (var db = new AESDbContext())
            {
                // Holds the user
                ApplicantUser user = null;

                // Ensure the user is in the DB
                userInDB(ref user, db, true);

                // Try to login via the security module
                var s = new SecuritySvc();
                var validUser = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME, SSN, DOB));

                Assert.AreEqual(user.userID, validUser.UserID);
            }
        }

        [TestMethod]
        public void TC3_NewUser()
        {
            // Get the context
            using (var db = new AESDbContext())
            {
                // Holds the user
                ApplicantUser user = null;

                // Ensure the user is not in the DB
                userInDB(ref user, db, false);

                // Try to login via the security module
                var s = new SecuritySvc();
                var newUser = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME, SSN, DOB));

                Assert.IsNotNull(newUser);
                Assert.AreEqual(newUser.FirstName, FIRSTNAME);
                Assert.AreEqual(newUser.LastName, LASTNAME);
                Assert.AreEqual(newUser.DOB, DOB);
            }
        }

        [TestMethod]
        public void TC3_BadCredentials()
        {
            using (var db = new AESDbContext())
            {

                // Holds the user
                ApplicantUser user = null;

                // Ensure the user is in the DB
                userInDB(ref user, db, true);

                // Try to log in with bad credentials
                var s = new SecuritySvc();
                var badFName = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME.Remove(FIRSTNAME.Length - 2), LASTNAME, SSN, DOB));
                var badLName = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME.Remove(LASTNAME.Length - 2), SSN, DOB));
                var badDOB = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME, SSN, DOB.AddDays(1)));

                Assert.IsNull(badFName);
                Assert.IsNull(badLName);
                Assert.IsNull(badDOB);
            }
        }

        [TestMethod]
        public void TC3_IncompleteCredentials()
        {
            using (var db = new AESDbContext())
            {
                // Try to log in with incomplete credentials
                var s = new SecuritySvc();
                var badFName = s.ValidateUser(new ApplicantInfoContract(null, LASTNAME, SSN, DOB));
                var badLName = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, null, SSN, DOB));
                var badSSN = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME, null, DOB));

                // Can't have null DateTime object
                // var badDOB = s.ValidateUser(new ApplicantInfoContract(FIRSTNAME, LASTNAME, SSN, null));

                Assert.IsNull(badFName);
                Assert.IsNull(badLName);
                Assert.IsNull(badSSN);
            }
        }

        [TestMethod]
        public void TC_CreateEmployee()
        {
            //db.Stores.AddOrUpdate(TestStore1);

            using (var db = new AESDbContext())
            {
                var s = new SecuritySvc();
                string blankPass = "";
                string nullPass = null;

                var CryptRandom = new RNGCryptoServiceProvider();
                var intRandom = new Random(Guid.NewGuid().GetHashCode());

                Byte[] randomBytes;

                for (int i = 0; i < 20; i++)
                {
                    randomBytes = new byte[intRandom.Next(1, 30)];
                    CryptRandom.GetNonZeroBytes(randomBytes);
                    string normalPass = Convert.ToBase64String(randomBytes);
                    var newValidEmployee = GenerateRandomEmployee(intRandom, CryptRandom);
                    Assert.IsTrue(s.CreateEmployee(newValidEmployee, normalPass));
                }
            }
        }

        private EmployeeUserContract GenerateRandomEmployee(Random intRandom, RNGCryptoServiceProvider CryptRandom)
        {


            Byte[] randomBytes = new byte[intRandom.Next(1, 30)];

            CryptRandom.GetNonZeroBytes(randomBytes);

            string email = Convert.ToBase64String(randomBytes) + "@gmail.com";

            randomBytes = new byte[intRandom.Next(1, 30)];

            CryptRandom.GetNonZeroBytes(randomBytes);

            string firstName = Convert.ToBase64String(randomBytes);

            randomBytes = new byte[intRandom.Next(1, 30)];

            CryptRandom.GetNonZeroBytes(randomBytes);

            string lastName = Convert.ToBase64String(randomBytes);

            var roles = Enum.GetValues(typeof(EmployeeRole));

            var randomRole = (EmployeeRole)roles.GetValue(intRandom.Next(roles.Length));

            var newValidEmployee = new EmployeeUserContract()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Role = randomRole
            };

            return newValidEmployee;
        }


        private void userInDB(ref ApplicantUser user, AESDbContext db, bool isIn)
        {
            // If it doesn't work the first time getting it, then we will add it in and do it again.
            for (int i = 0; i < 2; ++i)
            {
                user = db.ApplicantUsers.FirstOrDefault(u => u.SSN == SSN_CRYPT);

                if (user == null && i == 0)
                {
                    if (isIn)
                    {
                        db.ApplicantUsers.Add(new ApplicantUser()
                        {
                            FirstName = FIRSTNAME,
                            LastName = LASTNAME,
                            DOB = DOB,
                            SSN = SSN_CRYPT,
                            UserInfo = new UserInfo(),
                            Availability = new Availability()
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        return;
                    }
                }
                else if(user != null && !isIn)
                {

                    db.ApplicantUsers.Remove(user);
                    db.SaveChanges();
                    
                    // Do a weird error if they aren't removed
                    if(db.ApplicantUsers.FirstOrDefault(u => u.SSN == SSN_CRYPT) != null)
                    {
                        Assert.IsFalse(true);
                    }
                    else
                    {
                        return;
                    }
                }
                // If we finish the loop, do something weird so we know that the user couldn't be added
                else if (user == null && i != 0)
                {
                    Assert.IsTrue(false);
                }
                else break;
            }
        }
    }
}
