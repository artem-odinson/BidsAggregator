using System;
using System.Collections.Generic;
using System.Linq;

namespace BidsAggregator.Core.Entities.Inquiry
{
   
    public class Inquiry : InquiryBase, IAggregateRoot
    {
        public long InquirerId { get; set; }
        public Inquirer Inquirer { get; set; }
       

        private readonly List<InquiryItem> tasks = new List<InquiryItem>();
        public IReadOnlyCollection<InquiryItem> Tasks => tasks.AsReadOnly();

        internal Inquiry() : base() { }

        protected Inquiry(long id, DateTime createdDate, DateTime modifiedDate, InquiryStatus status) 
            : base(id, createdDate, modifiedDate, status)
        { }

        public void CompleteTask(long taskId)
        {
            InquiryItem completingTask = tasks.SingleOrDefault(t => t.Id == taskId);
            if (completingTask == null)
                throw new InvalidOperationException($"Task with Id = {taskId} is not found");

            completingTask.IsComleted = true;            

            bool isAllTaskCompleted = tasks.All(t => t.IsComleted);
            if (!isAllTaskCompleted)
            {
                Status = InquiryStatus.Completed;
            }

            ModifiedDate = DateTime.Now;
        }

        public void EditTask(long taskId, string newTaskBody)
        {
            if (string.IsNullOrWhiteSpace(newTaskBody))
                throw new ArgumentNullException(nameof(newTaskBody));

            InquiryItem editingTask = tasks.SingleOrDefault(t => t.Id == taskId);
            if (editingTask == null)
                throw new InvalidOperationException($"Task with Id = {taskId} is not found");

            editingTask.Body = newTaskBody;
            ModifiedDate = DateTime.Now;
        }

        public void AddTask(string taskBody)
        {
            if (string.IsNullOrWhiteSpace(taskBody))
                throw new ArgumentException(nameof(taskBody));
           
            tasks.Add(new InquiryItem { Body = taskBody });
        }

        public void AddTasks(IEnumerable<string> taskBodies)
        {
            if (taskBodies == null)
                throw new ArgumentNullException(nameof(taskBodies));

            var createdTasks = taskBodies.Select(tb => new InquiryItem { Body = tb });
            tasks.AddRange(createdTasks);
        }
    }
}