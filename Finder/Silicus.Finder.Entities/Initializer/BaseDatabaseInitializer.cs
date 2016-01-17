using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Silicus.Finder.Models.DataObjects;
using System.Collections;
using System.Collections.Generic;


namespace Silicus.Finder.Entities.Initializer
{
    public static class BaseDatabaseInitializer
    {
        private static readonly string DropConnectionScript = "Silicus.Finder.Entities.DatabaseScripts.DropConnection.sql";
        private static readonly string IndexScriptLocation = "Silicus.Finder.Entities.DatabaseScripts.SqlIndexes.sql";
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DBName"];
        private static readonly string MembershipDatabaseName = ConfigurationManager.AppSettings["MembershipDBName"];

        public static void Seed(FinderIpDataContext context)
        {
            //DropExistingConnectionToDatabase(context, DatabaseName);

            //AddIndexes(context, DatabaseName);
            context.Add(new User
           {
               FirstName = "Test",
               LastName = "Admin",
               NewPassword = "testadmin@123",
               ConfirmPassword = "testadmin@123",
               Address = "Test",
               Email = "testadmin@test.com",
               IdentityUserId = new System.Guid("2D3B545B-50F6-45D4-B916-23D276B3DB00"),
               Role = "ADMIN",
               isActive = true

           });
            context.Add(new User
            {
                FirstName = "Test",
                LastName = "User",
                NewPassword = "testuser@123",
                ConfirmPassword = "testuser@123",
                Address = "Test",
                Email = "testuser@test.com",
                IdentityUserId = new System.Guid("88B34980-EDD3-420C-8387-621B629A4E9B"),
                Role = "USER",
                isActive = true

            });



            context.Add(
                new Employee
                {
                    FirstName = "Abhishek",
                    MiddleName = "A",
                    LastName = "Jadhav",
                    Gender = Gender.Male,

                    Contact = new Contact
                    {
                        EmailAddress = "a@b.com",
                        MobileNumber = 758838,
                        PhoneNumber = "02382-265234",
                        Skype = "aMohite"
                    },

                    CubicleLocation = new CubicleLocation
                    {
                        Building = "B",
                        DeskNumber = "5/INCB-19",
                        FloorNumber = 5
                    },

                    EmployeeType = EmployeeType.Contract,
                    HighestQualification = "Be",
                    ManagerRecommendation = "Well performance",
                    SilicusExperienceInMonths = 4,
                    TotalExperienceInMonths = 4,
                    SkillSets = new List<SkillSet> { 
                                            new SkillSet {Name="C#",Description="C# net description" }
                                         }

                }
                         );


            context.Add(new Employee
            {
                FirstName = "Ankit",
                MiddleName = "Amit",
                LastName = "Agrawal",
                Gender = Gender.Male,
                Contact = new Contact
                {
                    EmailAddress = "a@b.com",
                    MobileNumber = 758838,
                    PhoneNumber = "02382-265234",
                    Skype = "aMohite"
                },
                CubicleLocation = new CubicleLocation
                {
                    Building = "B",
                    DeskNumber = "5/INCB-19",
                    FloorNumber = 5
                },
                //EmployeeSkillSets
                EmployeeType = EmployeeType.Contract,
                HighestQualification = "MTEK",
                ManagerRecommendation = "Well performance",
                SilicusExperienceInMonths = 4,
                TotalExperienceInMonths = 4,

                SkillSets = new List<SkillSet> { 
                                                  new SkillSet {Name="ASP",Description="ASP net description" }
                                               }
            }
            );

            context.Add(new Project
            {
                ProjectName = "SilicusFinder",
                Description = "Employee Finder",
                ProjectType = ProjectType.Internal,
                EngagementType = EngagementType.Time_Based,
                StartDate = new DateTime(2015,1,10),
                Status = Status.In_Progress,
                ExpectedEndDate = new DateTime(2015,10,20),
                ActualEndDate = new DateTime(2015,12,23),
                EngagementManagerId = 1,
                ProjectManagerId = 2,
                AdditionalNotes = "Project is developing",                
            }
            );

            context.Add(new Project
            {
                ProjectName = "Online Reservation",
                Description = "All types of reservation",
                ProjectType = ProjectType.External,
                EngagementType = EngagementType.T_and_M,
                StartDate = new DateTime(2016, 1, 10),
                Status = Status.Not_Started,
                ExpectedEndDate = new DateTime(2016, 10, 20),
                ActualEndDate = new DateTime(2016, 12, 4),
                EngagementManagerId = 2,
                ProjectManagerId = 1,
                AdditionalNotes = "Project is not started",
            }
            );

           
           

        }


        private static void AddIndexes(FinderIpDataContext context, string databaseName)
        {
            context.Database.CreateIfNotExists();

            var sqlContent = Content(IndexScriptLocation);

            var modifiedSqlScript = sqlContent.Replace("@DatabaseName", databaseName);

            context.Database.ExecuteSqlCommand(modifiedSqlScript);
        }
        
        private static void DropExistingConnectionToDatabase(FinderIpDataContext context, string databaseName)
        {
            var sqlContent = Content(DropConnectionScript);

            var modifiedSqlScript = sqlContent.Replace("@DatabaseName", databaseName);

            context.Database.ExecuteSqlCommand(modifiedSqlScript);
        }

        private static string Content(string fileLocation)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileLocation))
            {
                if (stream == null)
                {
                    return string.Empty;
                }

                var streamReader = new StreamReader(stream);

                return streamReader.ReadToEnd();
            }
        }
    }
}
