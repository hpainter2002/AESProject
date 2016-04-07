﻿using AES.Entities.Contexts;
using AES.Entities.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace AES.OpeningsSvc.Tests
{
    [TestClass]
    public class OpeningTests
    {

        private const string STORE1_ADDRESS = "123 Maple Street";
        private const string STORE1_CITY = "Thomasville";
        private const string STORE1_NAME = "AES Thomasville";
        private const string STORE1_STATE = "OR";
        private const string STORE1_PHONE = "321-546-2545";
        private const int STORE1_ZIP = 12345;

        private const string STORE2_ADDRESS = "456 Arbor Avenue";
        private const string STORE2_CITY = "Georgeville";
        private const string STORE2_NAME = "AES Georgeville";
        private const string STORE2_STATE = "WA";
        private const string STORE2_PHONE = "123-456-9780";
        private const int STORE2_ZIP = 23456;

        private const string JOB1_TITLE = "Job 1 Title";
        private const string JOB1_DESC_SHORT = "Job 1 Short Description";
        private const string JOB1_DESC_LONG = "The long description for Job 1";

        private const string JOB2_TITLE = "Job 2 Title";
        private const string JOB2_DESC_SHORT = "Job 2 Short Description";
        private const string JOB2_DESC_LONG = "The long description for Job 2";

        public OpeningTests()
        {
            // Get the directory we're starting in
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            // Loop until we find the folder that holds AES.Web
            while (dir.GetDirectories().FirstOrDefault(d => d.Name == "AES.Web") == null)
            {
                dir = dir.Parent;
            }

            // Create a new sub directory and then set the DataDirectory
            dir = dir.CreateSubdirectory("TestDB");
            AppDomain.CurrentDomain.SetData("DataDirectory", dir.FullName);
        }

        [TestMethod]
        public void TC_Openings()
        {

            using (var db = new AESDbContext())
            {

                Store TestStore1 = new Store()
                {
                    Address = STORE1_ADDRESS,
                    City = STORE1_CITY,
                    Name = STORE1_NAME,
                    State = STORE1_STATE,
                    Zip = STORE1_ZIP,
                    Phone = STORE1_PHONE
                };

                Store TestStore2 = new Store()
                {
                    Address = STORE2_ADDRESS,
                    City = STORE2_CITY,
                    Name = STORE2_NAME,
                    State = STORE2_STATE,
                    Zip = STORE2_ZIP,
                    Phone = STORE2_PHONE
                };

                Job TestJob1 = new Job()
                {
                    title = JOB1_TITLE,
                    descLong = JOB1_DESC_LONG,
                    descShort = JOB1_DESC_SHORT
                };

                Job TestJob2 = new Job()
                {
                    title = JOB2_TITLE,
                    descLong = JOB2_DESC_LONG,
                    descShort = JOB2_DESC_SHORT
                };

                var testJob1 = new JobOpening()
                {
                    Job = TestJob1
                };
                testJob1.Store = TestStore1;
                var testJob2 = new JobOpening()
                {
                    Job = TestJob2
                };
                testJob2.Store = TestStore2;

                db.Stores.AddOrUpdate(TestStore1);
                db.Stores.AddOrUpdate(TestStore2);
                db.Jobs.AddOrUpdate(TestJob1);
                db.Jobs.AddOrUpdate(TestJob2);
                db.JobOpenings.AddOrUpdate(testJob1);
                db.JobOpenings.AddOrUpdate(testJob2);
                db.SaveChanges();

                var gottenOpenings = db.JobOpenings.Where(opening => opening.Store.ID == TestStore1.ID).ToList();

                OpeningSvc openingService = new OpeningSvc();

                var Store1Openings = openingService.GetOpenings(TestStore1.ID);
                var Store2Openings = openingService.GetOpenings(TestStore2.ID);

                foreach (var opening in Store1Openings)
                {
                    Assert.AreEqual(TestJob1.descShort, opening.shortDesc);
                    Assert.AreEqual(TestJob1.descLong, opening.longDesc);
                    Assert.AreEqual(TestJob1.title, opening.title);
                }

                foreach (var opening in Store2Openings)
                {
                    Assert.AreEqual(TestJob2.descShort, opening.shortDesc);
                    Assert.AreEqual(TestJob2.descLong, opening.longDesc);
                    Assert.AreEqual(TestJob2.title, opening.title);
                }

            }
        }
    }
}
