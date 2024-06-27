using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Contractor = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contractor;
using Site = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Site;
using Stage = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Stage;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;
using Unit = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Unit;
using Work = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Work;
using WorkType = ConstructionSiteReportingSystem.Infrastructure.Data.Models.WorkType;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
	internal class DataSeed
    {
        public List<ApplicationUser> Users { get; set; }

        public IEnumerable<Contractor> Contractors { get; set; }

        public IEnumerable<Site> Sites { get; set; }

        public IEnumerable<Stage> Stages { get; set; }

        public IEnumerable<Unit> Units { get; set; }

        public IEnumerable<WorkType> WorkTypes { get; set; }

        public IEnumerable<Work> Works { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public DataSeed()
        {
            SeedUsers();
            SeedContractors();
            SeedSites();
            SeedStages();
            SeedUnits();
            SeedWorkTypes();
            SeedWorks();
            SeedTasks();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            Users = new List<ApplicationUser>();

            var testUser = new ApplicationUser()
            {
                Id = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f",
                UserName = "test@mail.com",
                NormalizedUserName = "TEST@MAIL.COM",
                Email = "test@mail.com",
                NormalizedEmail = "TEST@MAIL.COM",
                FirstName = "Konstantin",
                MiddleName = "Kirilov",
                LastName = "Georgiev"
            };

            testUser.PasswordHash = hasher.HashPassword(testUser, "Test123!");
            Users.Add(testUser);

            var guestUser = new ApplicationUser()
            {
                Id = "a615552b-5981-4730-be32-12c087492aef",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
				FirstName = "Ivan",
				MiddleName = "Metodiev",
				LastName = "Petrov"
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

        private void SeedSites()
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
                    Type = "machine shift"
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
                    SiteId = 1,
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
					SiteId = 1,
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
					SiteId = 1,
					WorkTypeId = 2,
                    Description = "Entered cost for crushed aggredate material and delivery",
                    CarryOutDate = DateTime.Now.AddDays(-1),
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
					SiteId = 1,
					WorkTypeId = 2,
                    Description = "Entered cost for crushed aggredate compaction using 11 ton roller",
                    CarryOutDate = DateTime.Now.AddDays(-1),
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
					SiteId = 1,
					WorkTypeId = 2,
                    CarryOutDate = DateTime.Now.AddDays(-2),
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
					SiteId = 1,
					WorkTypeId = 3,
                    Description = "Used combined excavators",
                    CarryOutDate = DateTime.Now.AddDays(-10),
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
					SiteId = 1,
					WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(-12),
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
					SiteId = 1,
					WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(-13),
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
					SiteId = 1,
					WorkTypeId = 4,
                    CarryOutDate = DateTime.Now.AddDays(-14),
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
					SiteId = 1,
					WorkTypeId = 5,
                    CarryOutDate = DateTime.Now.AddDays(-15),
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
					SiteId = 1,
					WorkTypeId = 6,
                    CarryOutDate = DateTime.Now.AddDays(-5),
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
					SiteId = 1,
					WorkTypeId = 7,
                    Description = "Entered cost for reinforcement steel and delivery",
                    CarryOutDate = DateTime.Now.AddDays(-4),
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
					SiteId = 1,
					WorkTypeId = 7,
                    Description = "Entered cost for reinforcement steel laying",
                    CarryOutDate = DateTime.Now.AddDays(-4),
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
					SiteId = 1,
					WorkTypeId = 8,
                    Description = "Entered cost for formwork assembly",
                    CarryOutDate = DateTime.Now.AddDays(-17),
                    StageId = 2,
                    ContractorId = 1,
                    Quantity = 57,
                    UnitId = 4,
                    CostPerUnit = 8M,
                    TotalCost = 456M,
                    CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
                },
				new Work()
				{
					Id = 15,
					SiteId = 2,
					WorkTypeId = 3,
					Description = "Used combined excavators",
					CarryOutDate = DateTime.Now.AddDays(-5),
					StageId = 1,
					ContractorId = 4,
					Quantity = 200,
					UnitId = 3,
					CostPerUnit = 8M,
					TotalCost = 1600M,
					CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
				},
				new Work()
				{
					Id = 16,
					SiteId = 2,
					WorkTypeId = 3,
					CarryOutDate = DateTime.Now.AddDays(-4),
					StageId = 1,
					ContractorId = 4,
					Quantity = 100,
					UnitId = 3,
					CostPerUnit = 8M,
					TotalCost = 800M,
					CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
				},
				new Work()
				{
					Id = 17,
					SiteId = 2,
					WorkTypeId = 3,
                    Description = "Entered cost for combined excavator use",
					CarryOutDate = DateTime.Now.AddDays(-3),
					StageId = 1,
					ContractorId = 2,
					Quantity = 2,
					UnitId = 8,
					CostPerUnit = 450M,
					TotalCost = 900M,
					CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
				},
				new Work()
				{
					Id = 18,
					SiteId = 2,
					WorkTypeId = 4,
					CarryOutDate = DateTime.Now.AddDays(-2),
					StageId = 1,
					ContractorId = 4,
					Quantity = 130,
					UnitId = 1,
					CostPerUnit = 164M,
					TotalCost = 21320M,
					CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
				},
				new Work()
				{
					Id = 19,
					SiteId = 2,
					WorkTypeId = 4,
					CarryOutDate = DateTime.Now.AddDays(1),
					StageId = 1,
					ContractorId = 4,
					Quantity = 250,
					UnitId = 1,
					CostPerUnit = 164M,
					TotalCost = 41000M,
					CreatorId = "32f9a0f0-4d62-4573-96e3-fbb7ad7f321f"
				},
				new Work()
				{
					Id = 20,
					SiteId = 3,
					WorkTypeId = 1,
					CarryOutDate = DateTime.Now,
					StageId = 4,
					ContractorId = 3,
					Quantity = 950,
					UnitId = 5,
					CostPerUnit = 23M,
					TotalCost = 21850M,
					CreatorId = "a615552b-5981-4730-be32-12c087492aef"
				},
				new Work()
				{
					Id = 21,
					SiteId = 3,
					WorkTypeId = 1,
					CarryOutDate = DateTime.Now.AddDays(-1),
					StageId = 4,
					ContractorId = 3,
					Quantity = 350,
					UnitId = 5,
					CostPerUnit = 23M,
					TotalCost = 8050M,
					CreatorId = "a615552b-5981-4730-be32-12c087492aef"
				},
				 new Work()
				{
					Id = 22,
					SiteId = 3,
					WorkTypeId = 2,
					CarryOutDate = DateTime.Now.AddDays(-1),
					StageId = 1,
					ContractorId = 4,
					Quantity = 200,
					UnitId = 3,
					CostPerUnit = 42.5M,
					TotalCost = 8500M,
					CreatorId = "a615552b-5981-4730-be32-12c087492aef"
				},
				  new Work()
				{
					Id = 23,
					SiteId = 3,
					WorkTypeId = 2,
					CarryOutDate = DateTime.Now,
					StageId = 1,
					ContractorId = 4,
					Quantity = 390,
					UnitId = 3,
					CostPerUnit = 42.5M,
					TotalCost = 16575M,
					CreatorId = "a615552b-5981-4730-be32-12c087492aef"
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
