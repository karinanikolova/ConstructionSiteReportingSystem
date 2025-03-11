using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using NUnit.Framework;
using System;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class TaskServiceTests : UnitTestsBase
	{
		private ITaskService _taskService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_taskService = new TaskService(_testRepository);
		}

		[Test, Order(1)]
		public async Task GetAllUserTasksAsync_ShouldReturnUserTasks_WithValidMethodArguments()
		{
			var userId = TestUsers.Select(u => u.Id).First();
			var allTasks = TestTasks.Where(t => t.CreatorId == userId).ToArray();
			var tasksCount = allTasks.Length;

			var taskQueryServiceResult = await _taskService.GetAllUserTasksAsync(userId, false, null, null, DateSorting.Newest, 1, tasksCount);

			Assert.That(taskQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(taskQueryServiceResult.TotalTasksCount, Is.EqualTo(tasksCount), "The evaluated tasks count are not equal.");

			int i = default;

			foreach (var taskResult in taskQueryServiceResult.Tasks)
			{
				Assert.Multiple(() =>
				{
					Assert.That(taskResult.Id, Is.EqualTo(allTasks[i].Id), "The evaluated task ids are not equal.");
					Assert.That(taskResult.Title, Is.EqualTo(allTasks[i].Title), "The evaluated task titles are not the same.");
					Assert.That(taskResult.Description, Is.EqualTo(allTasks[i].Description), "The evaluated task descriptions are not the same.");
					Assert.That(taskResult.CreatedOn, Is.EqualTo(allTasks[i].CreatedOn), "The evaluated task creation dates are not equal.");
					Assert.That(taskResult.Status, Is.EqualTo(allTasks[i].Status), "The evaluated task statuses are not the same.");
					Assert.That(taskResult.CreatorId, Is.EqualTo(allTasks[i].CreatorId), "The evaluated task creator ids are not equal.");
					Assert.That(taskResult.CreatorName, Is.EqualTo(allTasks[i].Creator.FirstName + " " + allTasks[i++].Creator.LastName), "The evaluated task creator names are not the same.");
				});
			}
		}

		[Test, Order(2)]
		public async Task GetAllUserTasksAsync_ShouldReturnUserTasks_WithValidSearchStatusAndOtherMethodArguments()
		{
			var userId = TestUsers.Select(u => u.Id).First();
			var allTasks = TestTasks.Where(t => t.CreatorId == userId && t.Status == Status.InProgress).ToArray();
			var tasksCount = allTasks.Length;

			var taskQueryServiceResult = await _taskService.GetAllUserTasksAsync(TestUsers.First().Id, false, "InProgress", null, DateSorting.Oldest, 1, tasksCount);

			Assert.That(taskQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(taskQueryServiceResult.TotalTasksCount, Is.EqualTo(tasksCount), "The evaluated tasks count are not equal.");

			int i = default;

			foreach (var taskResult in taskQueryServiceResult.Tasks.OrderBy(t => t.CreatedOn))
			{
				Assert.Multiple(() =>
				{
					Assert.That(taskResult.Id, Is.EqualTo(allTasks[i].Id), "The evaluated task ids are not equal.");
					Assert.That(taskResult.Title, Is.EqualTo(allTasks[i].Title), "The evaluated task titles are not the same.");
					Assert.That(taskResult.Description, Is.EqualTo(allTasks[i].Description), "The evaluated task descriptions are not the same.");
					Assert.That(taskResult.CreatedOn, Is.EqualTo(allTasks[i].CreatedOn), "The evaluated task creation dates are not equal.");
					Assert.That(taskResult.Status, Is.EqualTo(allTasks[i].Status), "The evaluated task statuses are not the same.");
					Assert.That(taskResult.CreatorId, Is.EqualTo(allTasks[i].CreatorId), "The evaluated task creator ids are not equal.");
					Assert.That(taskResult.CreatorName, Is.EqualTo(allTasks[i].Creator.FirstName + " " + allTasks[i++].Creator.LastName), "The evaluated task creator names are not the same.");
				});
			}
		}

		[Test, Order(3)]
		public async Task GetAllUserTasksAsync_ShouldReturnAllUsersTasks_WithValidMethodArguments()
		{
			var allTasks = TestTasks.OrderBy(t => t.CreatedOn).ToArray();
			var tasksCount = allTasks.Length;

			var taskQueryServiceResult = await _taskService.GetAllUserTasksAsync(TestUsers.First().Id, true, null, null, DateSorting.Oldest, 1, tasksCount);

			Assert.That(taskQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(taskQueryServiceResult.TotalTasksCount, Is.EqualTo(tasksCount), "The evaluated tasks count are not equal.");

			int i = default;

			foreach (var taskResult in taskQueryServiceResult.Tasks.OrderBy(t => t.CreatedOn))
			{
				Assert.Multiple(() =>
				{
					Assert.That(taskResult.Id, Is.EqualTo(allTasks[i].Id), "The evaluated task ids are not equal.");
					Assert.That(taskResult.Title, Is.EqualTo(allTasks[i].Title), "The evaluated task titles are not the same.");
					Assert.That(taskResult.Description, Is.EqualTo(allTasks[i].Description), "The evaluated task descriptions are not the same.");
					Assert.That(taskResult.CreatedOn, Is.EqualTo(allTasks[i].CreatedOn), "The evaluated task creation dates are not equal.");
					Assert.That(taskResult.Status, Is.EqualTo(allTasks[i].Status), "The evaluated task statuses are not the same.");
					Assert.That(taskResult.CreatorId, Is.EqualTo(allTasks[i].CreatorId), "The evaluated task creator ids are not equal.");
					Assert.That(taskResult.CreatorName, Is.EqualTo(allTasks[i].Creator.FirstName + " " + allTasks[i++].Creator.LastName), "The evaluated task creator names are not the same.");
				});
			}
		}

		[Test, Order(4)]
		public async Task GetAllUserTasksAsync_ShouldReturnAllUsersTasks_WithValidSearchTermAndOtherMethodArguments()
		{
			var allTasks = TestTasks.OrderBy(t => t.CreatedOn).ToArray();
			var tasksCount = allTasks.Length;

			var taskQueryServiceResult = await _taskService.GetAllUserTasksAsync(TestUsers.First().Id, true, null, "Title", DateSorting.Oldest, 1, tasksCount);

			Assert.That(taskQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(taskQueryServiceResult.TotalTasksCount, Is.EqualTo(tasksCount), "The evaluated tasks count are not equal.");

			int i = default;

			foreach (var taskResult in taskQueryServiceResult.Tasks.OrderBy(t => t.CreatedOn))
			{
				Assert.Multiple(() =>
				{
					Assert.That(taskResult.Id, Is.EqualTo(allTasks[i].Id), "The evaluated task ids are not equal.");
					Assert.That(taskResult.Title, Is.EqualTo(allTasks[i].Title), "The evaluated task titles are not the same.");
					Assert.That(taskResult.Description, Is.EqualTo(allTasks[i].Description), "The evaluated task descriptions are not the same.");
					Assert.That(taskResult.CreatedOn, Is.EqualTo(allTasks[i].CreatedOn), "The evaluated task creation dates are not equal.");
					Assert.That(taskResult.Status, Is.EqualTo(allTasks[i].Status), "The evaluated task statuses are not the same.");
					Assert.That(taskResult.CreatorId, Is.EqualTo(allTasks[i].CreatorId), "The evaluated task creator ids are not equal.");
					Assert.That(taskResult.CreatorName, Is.EqualTo(allTasks[i].Creator.FirstName + " " + allTasks[i++].Creator.LastName), "The evaluated task creator names are not the same.");
				});
			}
		}

		[Test]
		public void GetAllStatusesAsString_ShouldReturnAllStatuses()
		{
			var statuses = _taskService.GetAllStatusesAsString();

			Assert.That(statuses, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(statuses, Does.Contain(Status.NotStarted.ToString()), "There is no 'NotStarted' status found in the returned collection.");
			Assert.That(statuses, Does.Contain(Status.InProgress.ToString()), "There is no 'InProgress' status found in the returned collection.");
			Assert.That(statuses, Does.Contain(Status.Finished.ToString()), "There is no 'Finished' status found in the returned collection.");
		}

		[Test]
		public void GetAllStatusesAsInt_ShouldReturnAllStatuses()
		{
			var statuses = _taskService.GetAllStatusesAsInt();

			Assert.That(statuses, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(statuses, Does.Contain(0), "There is no underlying integral numeric value of 0 for status found in the returned collection.");
			Assert.That(statuses, Does.Contain(1), "There is no 1 underlying integral numeric value of 1 for status found in the returned collection.");
			Assert.That(statuses, Does.Contain(2), "There is no 2 underlying integral numeric value of 2 for status found in the returned collection.");
		}

		[Test]
		public void DoesStatusExist_ShouldReturnTrue_WithValidIntValue()
		{
			var doesStatusExist = _taskService.DoesStatusExist(1);

			Assert.That(doesStatusExist, Is.True);
		}

		[Test]
		public async Task CreateTaskAsync_ShouldCreateSuccessfully_WithValidMethodArguments()
		{
			var allUserTasksInDbBeforeCreating = TestTasks.Count();
			var userId = TestUsers.First().Id;
			var userName = TestUsers.First().FirstName + " " + TestUsers.First().LastName;
			var newTask = new TaskAddFormModel()
			{
				Title = "Newly Created Task Title",
				Description = "New Task Description",
				StatusId = 0
			};

			await _taskService.CreateTaskAsync(newTask, userId);

			var taskQueryServiceResult = await _taskService.GetAllUserTasksAsync(userId, true, null, null, DateSorting.Newest, 1, allUserTasksInDbBeforeCreating + 1);
			var allUserTasksInDbAfterCreating = taskQueryServiceResult.Tasks.Count();

			Assert.That(allUserTasksInDbAfterCreating, Is.EqualTo(allUserTasksInDbBeforeCreating + 1), "No new task has been added to the database.");

			var newlyCreatedTask = taskQueryServiceResult.Tasks.FirstOrDefault(s => s.Title == newTask.Title);
			Assert.Multiple(() =>
			{
				Assert.That(newlyCreatedTask, Is.Not.Null, "The creating of a new task was not successful and the returned value is null.");
				Assert.That(newlyCreatedTask.Description, Is.EqualTo(newTask.Description), "The evaluated task descriptions are not the same.");
				Assert.That((int)newlyCreatedTask.Status, Is.EqualTo(newTask.StatusId), "The evaluated task status ids are not equal.");
				Assert.That(newlyCreatedTask.CreatorId, Is.EqualTo(userId), "The evaluated task creator ids are not the same.");
				Assert.That(newlyCreatedTask.CreatorName, Is.EqualTo(userName), "The evaluated task creator names are not the same.");
			});
			Assert.That(newlyCreatedTask.Id, Is.Not.Zero, "The evaluated task id is equal to zero.");
			Assert.That(newlyCreatedTask.CreatedOn, Is.TypeOf(typeof(DateTime)), "The evaluated task creation date is not of type DateTime.");
		}

		[Test]
		public async Task DoesTaskExistAsync_ShouldReturnTrue_WithValidTaskId()
		{
			var taskId = TestTasks.First().Id;
			var result = await _taskService.DoesTaskExistAsync(taskId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task GetTaskEditFormModelByIdAsync_ShouldReturnCorrectFormModel_WithValidTaskId()
		{
			var task = TestTasks.First();

			var taskResult = await _taskService.GetTaskEditFormModelByIdAsync(task.Id);

			Assert.That(taskResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.Multiple(() =>
			{
				Assert.That(taskResult.Title, Is.EqualTo(task.Title), "The evaluated task titles are not the same.");
				Assert.That(taskResult.Description, Is.EqualTo(task.Description), "The evaluated task descriptions are not the same.");
				Assert.That(taskResult.StatusId, Is.EqualTo((int)task.Status), "The evaluated task status ids are not equal.");
				Assert.That(taskResult.CreatorId, Is.EqualTo(task.CreatorId), "The evaluated task creator ids are not the same.");
			});
		}

		[Test]
		public async Task GetTaskViewModelByIdAsync_ShouldReturnCorrectViewModel_WithValidTaskId()
		{
			var task = TestTasks.First(s => s.Id == 2);
			var creatorName = TestUsers.First(u => u.Id == task.CreatorId).FirstName + " " + TestUsers.First(u => u.Id == task.CreatorId).LastName;

			var taskResult = await _taskService.GetTaskViewModelByIdAsync(task.Id);

			Assert.That(taskResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.Multiple(() =>
			{
				Assert.That(taskResult.Id, Is.EqualTo(task.Id), "The evaluated task ids are not equal.");
				Assert.That(taskResult.Title, Is.EqualTo(task.Title), "The evaluated task titles are not the same.");
				Assert.That(taskResult.Description, Is.EqualTo(task.Description), "The evaluated task descriptions are not the same.");
				Assert.That(taskResult.CreatedOn, Is.EqualTo(task.CreatedOn), "The evaluated task creation dates are not the same.");
				Assert.That(taskResult.Status, Is.EqualTo(task.Status), "The evaluated task statuses are not the same.");
				Assert.That(taskResult.CreatorId, Is.EqualTo(task.CreatorId), "The evaluated task creator ids are not the same.");
				Assert.That(taskResult.CreatorName, Is.EqualTo(creatorName), "The evaluated task creator names are not the same.");
			});
		}

		[Test]
		public async Task EditTaskAsync_ShoulEditSuccessfully_WithValidMethodArguments()
		{
			var taskId = TestTasks.First().Id;
			var taskEditFormModel = new TaskEditFormModel()
			{
				Title = "Edited Task Name",
				Description = "Edited Task Description",
				StatusId = 0
			};

			await _taskService.EditTaskAsync(taskId, taskEditFormModel);
			var taskAfterEdit = await _taskService.GetTaskEditFormModelByIdAsync(taskId);

			Assert.Multiple(() =>
			{
				Assert.That(taskAfterEdit!.Title, Is.EqualTo(taskEditFormModel.Title), "The evaluated task titles are not the same.");
				Assert.That(taskAfterEdit!.Description, Is.EqualTo(taskEditFormModel.Description), "The evaluated task descriptions are not the same.");
				Assert.That(taskAfterEdit!.StatusId, Is.EqualTo(taskEditFormModel.StatusId), "The evaluated task status ids are not equal.");
			});
		}

		[Test]
		public async Task DeleteTaskAsync_ShoulDeleteSuccessfully_WithValidTaskId()
		{
			var taskToDelete = TestTasks.Last();
			var allTasksInDbBeforeDeleting = TestTasks.Count();

			await _taskService.DeleteTaskAsync(taskToDelete.Id);

			var tasksAfter = await _taskService.GetAllUserTasksAsync(TestUsers.Last().Id, true, null, null, DateSorting.Newest, 1, allTasksInDbBeforeDeleting - 1);
			var allTasksInDbAfterDeleting = tasksAfter.Tasks.Count();

			Assert.Multiple(() =>
			{
				Assert.That(allTasksInDbAfterDeleting, Is.EqualTo(allTasksInDbBeforeDeleting - 1), "The task has not been removed from the database.");
				Assert.That(tasksAfter.Tasks.FirstOrDefault(s => s.Id == taskToDelete.Id), Is.Null,
					"Task with a supposedly deleted id has been found.");
			});
		}
	}
}