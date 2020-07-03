using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using FocusMark.Tasks.Application.Services;
using FocusMark.Tasks.Domain;
using FocusMark.Tasks.RestApi.Services.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FocusMark.Tasks.RestApi.Services
{
    public class TaskListSnsService : ITaskListService
    {
        public TaskListSnsService(IAmazonSimpleNotificationService snsService, ICurrentUserService currentUserService, ILogger<TaskListSnsService> logger/*, IOptions<SnsConfiguration> snsOptions*/)
        {
            SnsService = snsService ?? throw new ArgumentNullException(nameof(snsService));
            CurrentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //this.SnsConfiguration = snsOptions.Value ?? throw new ArgumentNullException(nameof(snsOptions));
            this.SnsConfiguration = new SnsConfiguration { TopicArn = "arn:aws:sns:us-east-1:223237870883:test-sns" };
        }

        public IAmazonSimpleNotificationService SnsService { get; }
        public ICurrentUserService CurrentUserService { get; }
        public ILogger<TaskListSnsService> Logger { get; }
        public SnsConfiguration SnsConfiguration { get; }

        public async Task CreateTaskList(Guid taskListId, string title, string color, string path, Methodology kind, DateTime? startDate = null, DateTime? targetDate = null)
        {
            var createEvent = new CreateTaskListEvent
            {
                taskListId = taskListId,
                Title = title,
                Color = color,
                Path = path,
                Kind = kind.ToString(),
                StartDate = startDate,
                TargetDate = targetDate,
            };
            string userId = this.CurrentUserService.UserId;
            var rootObject = new { @default = createEvent };
            string jsonPayload = JsonConvert.SerializeObject(rootObject);
            var publishRequest = new PublishRequest(this.SnsConfiguration.TopicArn, jsonPayload);
            publishRequest.MessageAttributes.Add("user", new MessageAttributeValue { StringValue = userId, DataType = "String" });
            //publishRequest.MessageStructure = "json";
            PublishResponse response = await this.SnsService.PublishAsync(publishRequest);
            
            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new EventPublicationFailed(this.SnsConfiguration.TopicArn, userId);
            }
        }
    }
}
