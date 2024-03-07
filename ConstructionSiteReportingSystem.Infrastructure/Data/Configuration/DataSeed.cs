using Microsoft.AspNetCore.Identity;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class DataSeed
    {
        public List<IdentityUser> Users { get; set; }

        public IEnumerable<Contractor> Contractors { get; set; }

        public IEnumerable<ProjectSiteName> ProjectSiteNames { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<Site> Sites { get; set; }

        public IEnumerable<Stage> Stages { get; set; }

        public IEnumerable<SiteStage> SitesStages { get; set; }

        public IEnumerable<Unit> Units { get; set; }

        public IEnumerable<WorkType> WorkTypes { get; set; }

        public IEnumerable<Work> Works { get; set; }

        public IEnumerable<WorkByProject> WorksByProjects { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public DataSeed()
        {
            SeedUsers();
            SeedContractors();
            SeedProjectSiteNames();
            SeedProject();
            SeedSite();
            SeedStages();
            SeedSiteStages();
            SeedUnits();
            SeedWorkTypes();
            SeedWorks();
            SeedWorksByProjects();
            SeedTasks();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            Users = new List<IdentityUser>();

            var testUser = new IdentityUser()
            {
                Id = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                UserName = "test@mail.com",
                NormalizedUserName = "TEST@MAIL.COM",
                Email = "test@mail.com",
                NormalizedEmail = "TEST@MAIL.COM"
            };

            testUser.PasswordHash = hasher.HashPassword(testUser, "Test123!");
            Users.Add(testUser);

            var guestUser = new IdentityUser()
            {
                Id = "a615552b-5981-4730-be32-12c087492aef",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM"
            };

            guestUser.PasswordHash = hasher.HashPassword(guestUser, "Guest123!");
            Users.Add(guestUser);
        }

        private void SeedContractors()
        {
            Contractors = new List<Contractor>()
            {
                new Contractor()
                {
                    Id = 1,
                    Name = "GBS Build"
                },
                new Contractor()
                {
                    Id = 2,
                    Name = "M Constructions"
                },
                new Contractor()
                {
                    Id = 3,
                    Name = "Quality Plumbing"
                },
                new Contractor()
                {
                    Id = 4,
                    Name = "Pavement Systems"
                },
                new Contractor()
                {
                    Id = 5,
                    Name = "NewSteel LTD"
                }
            };
        }

        private void SeedProjectSiteNames()
        {
            ProjectSiteNames = new List<ProjectSiteName>()
            {
                new ProjectSiteName()
                {
                    Id = 1,
                    Name = "Plant construction for production of electric bicycles MaxCompany"
                },
                new ProjectSiteName()
                {
                    Id = 2,
                    Name = "Construction of streets in Plovdiv Municipality"
                }
            };
        }

        private void SeedProject()
        {
            Projects = new List<Project>()
            {
                new Project()
                {
                    Id = 1,
                    ProjectSiteNameId = 1
                },
                new Project()
                {
                    Id = 2,
                    ProjectSiteNameId = 2
                }
            };
        }

        private void SeedSite()
        {
            Sites = new List<Site>()
            {
                new Site()
                {
                    Id = 1,
                    ProjectSiteNameId = 1,
                    FinishDate = DateTime.Now.AddYears(3)
                },
                new Site()
                {
                    Id = 2,
                    ProjectSiteNameId = 2,
                    FinishDate = DateTime.Now.AddYears(5)
                }
            };
        }

        private void SeedStages()
        {
            Stages = new List<Stage>()
            {
                new Stage()
                {
                    Id = 1,
                    Name = "Sitework and foundation"
                },
                new Stage()
                {
                    Id = 2,
                    Name = "Rough framing"
                },
                new Stage()
                {
                    Id = 3,
                    Name = "Exterior construction"
                },
                new Stage()
                {
                    Id = 4,
                    Name = "Mechanical, electrical and plumbing"
                },
                new Stage()
                {
                    Id = 5,
                    Name = "Finishes and fixtures"
                }
            };
        }

        private void SeedSiteStages()
        {
            SitesStages = new List<SiteStage>()
            {
                new SiteStage()
                {
                    SiteId = 1,
                    StageId = 1
                },
                new SiteStage()
                {
                    SiteId = 1,
                    StageId = 2
                },
                new SiteStage()
                {
                    SiteId = 1,
                    StageId = 3
                },
                new SiteStage()
                {
                    SiteId = 1,
                    StageId = 4
                },
                new SiteStage()
                {
                    SiteId = 1,
                    StageId = 5
                },
                new SiteStage()
                {
                    SiteId = 2,
                    StageId = 1
                },
                new SiteStage()
                {
                    SiteId = 2,
                    StageId = 2
                },
                new SiteStage()
                {
                    SiteId = 2,
                    StageId = 3
                },
                new SiteStage()
                {
                    SiteId = 2,
                    StageId = 4
                },
                new SiteStage()
                {
                    SiteId = 2,
                    StageId = 5
                }
            };
        }

        private void SeedUnits()
        {
            Units = new List<Unit>()
            {
                new Unit()
                {
                    Id = 1,
                    Type = "Ton"
                },
                new Unit()
                {
                    Id = 2,
                    Type = "Kilogram"
                },
                new Unit()
                {
                    Id = 3,
                    Type = "m^3"
                },
                new Unit()
                {
                    Id = 4,
                    Type = "m^2"
                },
                new Unit()
                {
                    Id = 5,
                    Type = "Meter"
                },
                new Unit()
                {
                    Id = 6,
                    Type = "Piece"
                },
                new Unit()
                {
                    Id = 6,
                    Type = "Piece"
                },
                new Unit()
                {
                    Id = 7,
                    Type = "Piece/m"
                },
                new Unit()
                {
                    Id = 8,
                    Type = "Machine hours"
                },
                new Unit()
                {
                    Id = 9,
                    Type = "Man hours"
                }
            };
        }

        private void SeedWorkTypes()
        {
            WorkTypes = new List<WorkType>()
            {
                new WorkType()
                {
                    Id = 1,
                    Name = "PE400 SN8 pipe installation"
                },
                new WorkType()
                {
                    Id = 2,
                    Name = "Delivery,laying and compaction of crushed aggregate for road base"
                },
                new WorkType()
                {
                    Id = 3,
                    Name = "Earthwork excavation"
                },
                new WorkType()
                {
                    Id = 4,
                    Name = "Delivery, laying and compaction of asphalt concrete binder course"
                },
                new WorkType()
                {
                    Id = 5,
                    Name = "Delivery, laying and compaction of asphalt concrete surface course"
                },
                new WorkType()
                {
                    Id = 6,
                    Name = "Delivery and pouring concrete for foundation slab"
                },
                new WorkType()
                {
                    Id = 7,
                    Name = "Delivery and laying of reinforcement steel for foundation slab"
                },
                new WorkType()
                {
                    Id = 8,
                    Name = "Large-area formwork for concrete slab"
                }
            };
        }

        private void SeedWorks()
        {
            Works = new List<Work>()
            {
                new Work()
                {
                    Id = 1,
                    WorkTypeId = 1,
                    CarryOutDate = DateTime.Now,
                    StageId = 4,
                    ContractorId = 3,
                    Quantity = 897,
                    UnitId = 5,
                    CostPerUnit = 23M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 2,
                    WorkTypeId = 2,
                    CarryOutDate = DateTime.Now,
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 120,
                    UnitId = 3,
                    CostPerUnit = 42.5M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 3,
                    WorkTypeId = 2,
                    Description = "Imput cost for crushed aggredate material and delivery",
                    CarryOutDate = DateTime.Now.AddDays(1),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 150,
                    UnitId = 3,
                    CostPerUnit = 35.5M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 4,
                    WorkTypeId = 2,
                    Description = "Input cost for crushed aggredate compaction using 11 ton roller",
                    CarryOutDate = DateTime.Now.AddDays(1),
                    StageId = 1,
                    ContractorId = 2,
                    Quantity = 1,
                    UnitId = 8,
                    CostPerUnit = 600M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = false
                },
                new Work()
                {
                    Id = 5,
                    WorkTypeId = 2,
                    CarryOutDate = DateTime.Now.AddDays(2),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 250,
                    UnitId = 3,
                    CostPerUnit = 42.5M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 6,
                    WorkTypeId = 3,
                    Description = "Used combined excavators",
                    CarryOutDate = DateTime.Now.AddDays(10),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 150,
                    UnitId = 3,
                    CostPerUnit = 8M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 7,
                    WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(12),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 163,
                    UnitId = 1,
                    CostPerUnit = 164M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 8,
                    WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(13),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 158,
                    UnitId = 1,
                    CostPerUnit = 164M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 9,
                    WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(14),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 75,
                    UnitId = 1,
                    CostPerUnit = 164M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 10,
                    WorkTypeId = 5,
                    CarryOutDate = DateTime.Now.AddDays(15),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 210,
                    UnitId = 1,
                    CostPerUnit = 152M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 11,
                    WorkTypeId = 6,
                    CarryOutDate = DateTime.Now.AddDays(5),
                    StageId = 1,
                    ContractorId = 2,
                    Quantity = 20,
                    UnitId = 3,
                    CostPerUnit = 135M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 12,
                    WorkTypeId = 7,
                    Description = "Input cost for reinforcement steel and delivery",
                    CarryOutDate = DateTime.Now.AddDays(4),
                    StageId = 1,
                    ContractorId = 5,
                    Quantity = 57,
                    UnitId = 2,
                    CostPerUnit = 2.2M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    IsIncluded = true
                },
                new Work()
                {
                    Id = 13,
                    WorkTypeId = 7,
                    Description = "Input cost for reinforcement steel laying",
                    CarryOutDate = DateTime.Now.AddDays(4),
                    StageId = 1,
                    ContractorId = 1,
                    Quantity = 57,
                    UnitId = 2,
                    CostPerUnit = 0.3M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    IsIncluded = false
                },
                new Work()
                {
                    Id = 14,
                    WorkTypeId = 8,
                    Description = "Input cost for formwork assembly",
                    CarryOutDate = DateTime.Now.AddDays(17),
                    StageId = 2,
                    ContractorId = 1,
                    Quantity = 57,
                    UnitId = 4,
                    CostPerUnit = 8M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    IsIncluded = true
                }
            };
        }

        private void SeedWorksByProjects()
        {
            WorksByProjects = new List<WorkByProject>()
            {
                new WorkByProject()
                {
                    Id = 1,
                    WorkTypeId = 1,
                    UnitId = 5,
                    ToTalQuantity = 3543,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 2,
                    WorkTypeId = 2,
                    UnitId = 3,
                    ToTalQuantity = 12056,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 3,
                    WorkTypeId = 3,
                    UnitId = 3,
                    ToTalQuantity = 15327,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 4,
                    WorkTypeId = 4,
                    UnitId = 1,
                    ToTalQuantity = 3024,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 5,
                    WorkTypeId = 5,
                    UnitId = 1,
                    ToTalQuantity = 3024,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 6,
                    WorkTypeId = 6,
                    UnitId = 1,
                    ToTalQuantity = 3000,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 7,
                    WorkTypeId = 7,
                    UnitId = 2,
                    ToTalQuantity = 72000,
                    ProjectId = 1
                },
                new WorkByProject()
                {
                    Id = 8,
                    WorkTypeId = 8,
                    UnitId = 4,
                    ToTalQuantity = 3600,
                    ProjectId = 1
                }
            };
        }

        private void SeedTasks()
        {
            Tasks = new List<Task>()
            {
                new Task() 
                { 
                    Id = 1,
                    Title = "Order concrete",
                    Description = "Must order 5m3 concrete class C20/25 with delivery date next Monday",
                    CreatedOn = DateTime.Now,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = Enums.Status.NotStarted
                },
                new Task()
                {
                    Id = 2,
                    Title = "New project documentation",
                    Description = "Should start looking through documentation and drawings of upcoming project",
                    CreatedOn = DateTime.Now.AddDays(30),
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = Enums.Status.NotStarted
                },
                new Task()
                {
                    Id = 3,
                    Title = "Weekly meeting",
                    Description = "Go to weekly site Monday meeting",
                    CreatedOn = DateTime.Now.AddDays(-5),
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = Enums.Status.Finished
                },
                new Task()
                {
                    Id = 4,
                    Title = "Monthly workers attendance forms",
                    Description = "Fill in monthly workers attendance forms and send them to accounting by the end of month",
                    CreatedOn = DateTime.Now,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = Enums.Status.InProgress
                },
                new Task()
                {
                    Id = 5,
                    Title = "Schedule meeting",
                    Description = "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties",
                    CreatedOn = DateTime.Now,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    Status = Enums.Status.NotStarted
                },
                new Task()
                {
                    Id = 6,
                    Title = "Formwork",
                    Description = "Call Doka representative and order more formwork for site",
                    CreatedOn = DateTime.Now.AddDays(5),
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    Status = Enums.Status.NotStarted
                },
            };
        }
    }
}
