using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data
{
    public class MemoryDataService:IDataService
    {
        private static IEnumerable<TaskItem> Tasks { get; } = [
            new()  {Id = 1, Title = "Задача 1", Description = "Описание задачи 1", CreateDate=DateTime.Now},
            new()  {Id = 2, Title = "Задача 2", Description = "Описание задачи 2", CreateDate=DateTime.Now},
            new()  {Id = 3, Title = "Задача 3", Description = "Описание задачи 3", CreateDate=DateTime.Now},
        ];
        public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
        {
            await Task.Delay(1000);
            return await Task.FromResult(Tasks);
        } 
    }    
}