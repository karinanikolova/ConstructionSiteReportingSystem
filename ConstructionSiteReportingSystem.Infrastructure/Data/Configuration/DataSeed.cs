using Microsoft.AspNetCore.Identity;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class DataSeed
    {
        public List<IdentityUser> Users { get; set; }

        public IEnumerable<Contractor> Contractors { get; set; }

        public IEnumerable<Site> Sites { get; set; }

        public IEnumerable<Stage> Stages { get; set; }

        public IEnumerable<SiteStage> SitesStages { get; set; }

        public IEnumerable<Unit> Units { get; set; }

        public IEnumerable<WorkType> WorkTypes { get; set; }

        public IEnumerable<Work> Works { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public DataSeed()
        {
            SeedUsers();
            SeedContractors();
            SeedSite();
            SeedStages();
            SeedSiteStages();
            SeedUnits();
            SeedWorkTypes();
            SeedWorks();
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

        private void SeedSite()
        {
            Sites = new List<Site>()
            {
                new Site()
                {
                    Id = 1,
                    Name = "Plant construction for production of electric bicycles MaxCompany",
                    ImageUrl = "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    FinishDate = DateTime.Now.AddYears(3)
                },
                new Site()
                {
                    Id = 2,
					Name = "Construction of streets in Plovdiv Municipality",
                    ImageUrl = "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    FinishDate = DateTime.Now.AddYears(5)
                },
				new Site()
				{
					Id = 3,
					Name = "Plant construction for cardboard packaging GreenPac",
					ImageUrl = "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
					FinishDate = DateTime.Now.AddYears(2)
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
                },
				new SiteStage()
				{
					SiteId = 3,
					StageId = 1
				},
				new SiteStage()
				{
					SiteId = 3,
					StageId = 2
				},
				new SiteStage()
				{
					SiteId = 3,
					StageId = 3
				},
				new SiteStage()
				{
					SiteId = 3,
					StageId = 4
				},
				new SiteStage()
				{
					SiteId = 3,
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
                    Type = "ton"
                },
                new Unit()
                {
                    Id = 2,
                    Type = "kg"
                },
                new Unit()
                {
                    Id = 3,
                    Type = "cu.m"
                },
                new Unit()
                {
                    Id = 4,
                    Type = "sq.m"
                },
                new Unit()
                {
                    Id = 5,
                    Type = "m"
                },
                new Unit()
                {
                    Id = 6,
                    Type = "piece"
                },
                new Unit()
                {
                    Id = 7,
                    Type = "piece/m"
                },
                new Unit()
                {
                    Id = 8,
                    Type = "machine hours"
                },
                new Unit()
                {
                    Id = 9,
                    Type = "man hours"
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
                    TotalCost = 20631M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 5100M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
                },
                new Work()
                {
                    Id = 3,
                    WorkTypeId = 2,
                    Description = "Entered cost for crushed aggredate material and delivery",
                    CarryOutDate = DateTime.Now.AddDays(1),
                    StageId = 1,
                    ContractorId = 4,
                    Quantity = 150,
                    UnitId = 3,
                    CostPerUnit = 35.5M,
                    TotalCost = 5325M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
                },
                new Work()
                {
                    Id = 4,
                    WorkTypeId = 2,
                    Description = "Entered cost for crushed aggredate compaction using 11 ton roller",
                    CarryOutDate = DateTime.Now.AddDays(1),
                    StageId = 1,
                    ContractorId = 2,
                    Quantity = 1,
                    UnitId = 8,
                    CostPerUnit = 600M,
                    TotalCost = 600M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 10625M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 1200M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 26732M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 25912M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 12300M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 31920M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    TotalCost = 2700M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef"
                },
                new Work()
                {
                    Id = 12,
                    WorkTypeId = 7,
                    Description = "Entered cost for reinforcement steel and delivery",
                    CarryOutDate = DateTime.Now.AddDays(4),
                    StageId = 1,
                    ContractorId = 5,
                    Quantity = 57,
                    UnitId = 2,
                    CostPerUnit = 2.2M,
                    TotalCost = 125.4M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef"
                },
                new Work()
                {
                    Id = 13,
                    WorkTypeId = 7,
                    Description = "Entered cost for reinforcement steel laying",
                    CarryOutDate = DateTime.Now.AddDays(4),
                    StageId = 1,
                    ContractorId = 1,
                    Quantity = 57,
                    UnitId = 2,
                    CostPerUnit = 0.3M,
                    TotalCost = 17.1M,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef"
                },
                new Work()
                {
                    Id = 14,
                    WorkTypeId = 8,
                    Description = "Entered cost for formwork assembly",
                    CarryOutDate = DateTime.Now.AddDays(17),
                    StageId = 2,
                    ContractorId = 1,
                    Quantity = 57,
                    UnitId = 4,
                    CostPerUnit = 8M,
                    TotalCost = 456M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
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
                    Status = (Status)0
                },
                new Task()
                {
                    Id = 2,
                    Title = "New project documentation",
                    Description = "Should start looking through documentation and drawings of upcoming project",
                    CreatedOn = DateTime.Now.AddDays(30),
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = (Status)0
                },
                new Task()
                {
                    Id = 3,
                    Title = "Weekly meeting",
                    Description = "Go to weekly site Monday meeting",
                    CreatedOn = DateTime.Now.AddDays(-5),
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = (Status)2
                },
                new Task()
                {
                    Id = 4,
                    Title = "Monthly workers attendance forms",
                    Description = "Fill in monthly workers attendance forms and send them to accounting by the end of month",
                    CreatedOn = DateTime.Now,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                    Status = (Status)1
                },
                new Task()
                {
                    Id = 5,
                    Title = "Schedule meeting",
                    Description = "Call engineer supervisor and schedule meeting to discuss construction work progress and difficulties",
                    CreatedOn = DateTime.Now,
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    Status = (Status)0
                },
                new Task()
                {
                    Id = 6,
                    Title = "Formwork",
                    Description = "Call Doka representative and order more formwork for site",
                    CreatedOn = DateTime.Now.AddDays(5),
                    CreatorId = "a615552b-5981-4730-be32-12c087492aef",
                    Status = (Status)0
                },
            };
        }
    }
}
