using ConstructionSiteReportingSystem.Infrastructure.Data;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using ConstructionSiteReportingSystem.Tests.Mocks;
using System.Globalization;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	public class UnitTestsBase
	{
		protected ConstructionSiteDbContext _dbContext;

		protected UnitTestsBase()
		{

		}

		public List<ApplicationUser> TestUsers { get; private set; }

		public IEnumerable<Contractor> TestContractors { get; private set; }

		public IEnumerable<Site> TestSites { get; private set; }

		public IEnumerable<Stage> TestStages { get; private set; }

		public IEnumerable<Unit> TestUnits { get; private set; }

		public IEnumerable<WorkType> TestWorksTypes { get; private set; }

		public IEnumerable<Work> TestWorks { get; private set; }

		public IEnumerable<Task> TestTasks { get; private set; }

		[OneTimeSetUp]
		public void SetUpDatabase()
		{
			_dbContext = DatabaseMock.Instance;
			_dbContext.Database.EnsureCreated();

			SeedDatabase();
		}

		[OneTimeTearDown]
		public void TearDownDatabase() => _dbContext.Dispose();

		private void SeedDatabase()
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
			TestUsers = new List<ApplicationUser>()
			{
				new ApplicationUser()
				{
					Id = "TestUserId",
					UserName = "user@mail.com",
					NormalizedUserName = "USER@MAIL.COM",
					Email = "user@mail.com",
					NormalizedEmail = "USER@MAIL.COM",
					FirstName = "UserFirstName",
					MiddleName = "UserMiddleName",
					LastName = "UserLastName"
				},
				new ApplicationUser()
				{
					Id = "TestAdminId",
					UserName = "admin@mail.com",
					NormalizedUserName = "ADMIN@MAIL.COM",
					Email = "admin@mail.com",
					NormalizedEmail = "ADMIN@MAIL.COM",
					FirstName = "AdminFirstName",
					MiddleName = "AdminMiddleName",
					LastName = "AdminLastName"
				}
			};

			_dbContext.Users.AddRange(TestUsers);
			_dbContext.SaveChanges();
		}

		private void SeedContractors()
		{
			TestContractors = new List<Contractor>()
			{
				new Contractor()
				{
					Id = 1,
					Name = "First Contractor",
					IsApproved = true
				},
				new Contractor()
				{
					Id = 2,
					Name = "Second Contractor",
					IsApproved = true
				},
				new Contractor()
				{
					Id = 3,
					Name = "Third Contractor",
					IsApproved = true
				},
				new Contractor()
				{
					Id = 4,
					Name = "Fourth Contractor",
					IsApproved = false
				},
				new Contractor()
				{
					Id = 5,
					Name = "Fifth Contractor",
					IsApproved = false
				}
			};

			_dbContext.Contractors.AddRange(TestContractors);
			_dbContext.SaveChanges();
		}

		private void SeedSites()
		{
			TestSites = new List<Site>()
			{
				new Site()
				{
					Id = 1,
					Name = "First Site Name",
					ImageUrl = "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
					FinishDate = DateTime.Now.AddYears(3)
				},
				new Site()
				{
					Id = 2,
					Name = "Second Site Name",
					ImageUrl = "https://images.pexels.com/photos/2833686/pexels-photo-2833686.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
					FinishDate = DateTime.Now.AddYears(5)
				},
				new Site()
				{
					Id = 3,
					Name = "Third Site Name",
					ImageUrl = "https://images.pexels.com/photos/236698/pexels-photo-236698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
					FinishDate = DateTime.Now.AddYears(2)
				}
			};

			_dbContext.Sites.AddRange(TestSites);
			_dbContext.SaveChanges();
		}

		private void SeedStages()
		{
			TestStages = new List<Stage>()
			{
				new Stage()
				{
					Id = 1,
					Name = "First Stage",
					IsApproved = true
				},
				new Stage()
				{
					Id = 2,
					Name = "Second Stage",
					IsApproved = true
				},
				new Stage()
				{
					Id = 3,
					Name = "Third Stage",
					IsApproved = true
				},
				new Stage()
				{
					Id = 4,
					Name = "Fourth Stage",
					IsApproved = false
				},
				new Stage()
				{
					Id = 5,
					Name = "Fifth Stage",
					IsApproved = false
				}
			};

			_dbContext.Stages.AddRange(TestStages);
			_dbContext.SaveChanges();
		}

		private void SeedUnits()
		{
			TestUnits = new List<Unit>()
			{
				new Unit()
				{
					Id = 1,
					Type = "kg",
					IsApproved = true
				},
				new Unit()
				{
					Id = 2,
					Type = "cu.m",
					IsApproved = true
				},
				new Unit()
				{
					Id = 3,
					Type = "m",
					IsApproved = true
				},
				new Unit()
				{
					Id = 4,
					Type = "sq.m",
					IsApproved = false
				},
				new Unit()
				{
					Id = 5,
					Type = "t",
					IsApproved = false
				}
			};

			_dbContext.Units.AddRange(TestUnits);
			_dbContext.SaveChanges();
		}

		private void SeedWorkTypes()
		{
			TestWorksTypes = new List<WorkType>()
			{
				new WorkType()
				{
					Id = 1,
					Name = "First Work Type Name",
					IsApproved = true
				},
				new WorkType()
				{
					Id = 2,
					Name = "Second Work Type Name",
					IsApproved = true
				},
				new WorkType()
				{
					Id = 3,
					Name = "Third Work Type Name",
					IsApproved = true
				},
				new WorkType()
				{
					Id = 4,
					Name = "Fourth Work Type Name",
					IsApproved = false
				},
				new WorkType()
				{
					Id = 5,
					Name = "Fifth Work Type Name",
					IsApproved = false
				}
			};

			_dbContext.WorksTypes.AddRange(TestWorksTypes);
			_dbContext.SaveChanges();
		}

		private void SeedWorks()
		{
			TestWorks = new List<Work>()
			{
				new Work()
				{
					Id = 1,
					SiteId = 1,
					WorkTypeId = 1,
					CarryOutDate = DateTime.ParseExact("19/03/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture),
					StageId = 1,
					ContractorId = 1,
					Quantity = 897,
					UnitId = 3,
					CostPerUnit = 23M,
					TotalCost = 20631M,
					CreatorId = "TestUserId"
				},
				new Work()
				{
					Id = 2,
					SiteId = 2,
					WorkTypeId = 2,
					CarryOutDate = DateTime.ParseExact("05/01/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture),
					StageId = 2,
					ContractorId = 2,
					Quantity = 120,
					UnitId = 2,
					CostPerUnit = 42.5M,
					TotalCost = 5100M,
					CreatorId = "TestUserId"
				},
				new Work()
				{
					Id = 3,
					SiteId = 2,
					WorkTypeId = 3,
					CarryOutDate = DateTime.ParseExact("07/01/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture),
					StageId = 2,
					ContractorId = 3,
					Quantity = 150,
					UnitId = 1,
					CostPerUnit = 50M,
					TotalCost = 7500M,
					CreatorId = "TestUserId"
				},
				new Work()
				{
					Id = 4,
					SiteId = 2,
					WorkTypeId = 1,
					CarryOutDate = DateTime.ParseExact("09/01/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture),
					StageId = 2,
					ContractorId = 1,
					Quantity = 270,
					UnitId = 3,
					CostPerUnit = 39.5M,
					TotalCost = 10_665M,
					CreatorId = "TestUserId"
				},
				new Work()
				{
					Id = 5,
					SiteId = 3,
					WorkTypeId = 3,
					Description = "Some work description.",
					CarryOutDate = DateTime.ParseExact("17/02/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture),
					StageId = 3,
					ContractorId = 3,
					Quantity = 150,
					UnitId = 2,
					CostPerUnit = 35.5M,
					TotalCost = 5325M,
					CreatorId = "TestAdminId"
				}
			};

			_dbContext.Works.AddRange(TestWorks);
			_dbContext.SaveChanges();
		}

		private void SeedTasks()
		{
			TestTasks = new List<Task>()
			{
				new Task()
				{
					Id = 1,
					Title = "First Task Title",
					Description = "First Task Description",
					CreatedOn = DateTime.Now,
					CreatorId = "TestUserId",
					Status = (Status)1
				},
				new Task()
				{
					Id = 2,
					Title = "Second Task Title",
					Description = "Second Task Description",
					CreatedOn = DateTime.Now.AddDays(-7),
					CreatorId = "TestUserId",
					Status = (Status)0
				},
				new Task()
				{
					Id = 3,
					Title = "Third Task Title",
					Description = "Third Task Description",
					CreatedOn = DateTime.Now.AddDays(-5),
					CreatorId = "AdminUserId",
					Status = (Status)2
				}
			};

			_dbContext.Tasks.AddRange(TestTasks);
			_dbContext.SaveChanges();
		}
	}
}