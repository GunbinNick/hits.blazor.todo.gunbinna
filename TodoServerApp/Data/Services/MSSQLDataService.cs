using Microsoft.EntityFrameworkCore;
using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services
{
	public class MSSQLDataService(ApplicationDbContext context) : IDataService
	{
		public TaskItem taskItem { get; private set; }

		public async Task<IEnumerable<TaskItem>> GetAllAsync()
		{
			return await context.TaskItems.ToArrayAsync();
		}

		public async Task SaveAsync(TaskItem taskitem)
		{
			if (taskitem.Id == 0)
			{
				taskitem.CreateDate = DateTime.Now;
				await context.TaskItems.AddAsync(taskitem);
			}
			else
			{
				context.TaskItems.Update(taskItem);
			}
			await context.SaveChangesAsync();
			
		}

		public async Task<TaskItem> GetTaskAsync(int id)
		{
			return await context.TaskItems.FirstAsync(x => x.Id == id);
		}

		public async Task DeleteAsync(int id)
		{
			var taskItem = await context.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
			context.TaskItems.Remove(taskItem);
			await context.SaveChangesAsync();
		}

		public Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
		{
			throw new NotImplementedException();
		}
	}
}