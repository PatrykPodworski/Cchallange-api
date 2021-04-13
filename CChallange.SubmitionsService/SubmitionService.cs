using CChallange.Data;
using CChallange.JdoodleService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CChallange.SubmitionsService
{
    public class SubmitionService : ISubmitionService
    {
        private readonly CChallangeDbContext dbContext;
        private readonly IJdoodleService jdoodleService;

        public SubmitionService(CChallangeDbContext dbContext, IJdoodleService jdoodleService)
        {
            this.dbContext = dbContext;
            this.jdoodleService = jdoodleService;
        }

        public async Task<bool> SubmitAsync(string taskId, string submitionerName, string code)
        {
            var task = await GetTaskAsync(taskId).ConfigureAwait(false);

            if (task == null)
            {
                throw new ArgumentException($"There is no task with id {taskId}");
            }

            var output = await jdoodleService.CompileCodeAsync(code, task.Input);

            var IsOutputCorrect = output == task.Output;

            if (!IsOutputCorrect)
            {
                return false;
            }

            var userId = await GetUserIdAsync(submitionerName).ConfigureAwait(false);

            await SubmitSolutionAsync(taskId, userId, code).ConfigureAwait(false);

            return true;
        }

        private async Task SubmitSolutionAsync(string taskId, string userId, string code)
        {
            dbContext.Add(
                new Submition
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = code,
                    TaskId = taskId,
                    UserId = userId
                });

            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task<string> GetUserIdAsync(string submitionerName)
        {
            var existingUserId = await dbContext.Users
                .Where(x => x.Name == submitionerName)
                .Select(x => x.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (existingUserId != null)
            {
                return existingUserId;
            }

            var userId = Guid.NewGuid().ToString();
            dbContext.Add(
            new User
            {
                Id = userId,
                Name = submitionerName
            });
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return userId;
        }

        private async Task<Data.Task> GetTaskAsync(string taskId)
        {
            return await dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == taskId)
                .ConfigureAwait(false);
        }
    }
}
