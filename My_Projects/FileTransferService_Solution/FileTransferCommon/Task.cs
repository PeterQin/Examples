using System;
using System.Collections.Generic;
using System.Text;

namespace Quest.Tuning.FileTransferCommon
{
    public class TaskInfo
    {
        private TaskType FCurrentType = TaskType.None;
        private string FSource = string.Empty;
        private string FDestination = string.Empty;
        private TaskResult FResult = null;

        public TaskType CurrentType
        {
            get { return FCurrentType; }
            set { FCurrentType = value; }
        }

        public string Destination
        {
            get { return FDestination; }
            set { FDestination = value; }
        }

        public string Source
        {
            get { return FSource; }
            set { FSource = value; }
        }

        public TaskResult Result
        {
            get { return FResult; }
            set { FResult = value; }
        }

        public TaskInfo()
        {
        }

        public TaskInfo(TaskType aType)
        {
            CurrentType = aType;
        }
    }

    public enum TaskType
    {
        None,
        Download,
        Upload,
    }

    public enum ResultType
    {
        None,
        Success,
        Fail,
    }

    public class TaskResult
    {
        private ResultType FResultType = ResultType.None;

        public ResultType ResultType
        {
            get { return FResultType; }
            set { FResultType = value; }
        }

        private string FResultMessage;

        public string ResultMessage
        {
            get { return FResultMessage; }
            set { FResultMessage = value; }
        }
    }
}
