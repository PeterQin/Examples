using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.IO;

namespace AJMS
{
   

   
   

   
    /// <summary>
    /// Types of schedules a job can have.
    /// </summary>
    public enum JobScheduleType
    {
        Now,
        Weekly,
        OnDrop,
        StartAfterJob
    }

    /// <summary>
    /// States that a job can be in.
    /// </summary>
    public enum JobStateType
    {
        None,
        ScheduleQueued,
        UserQueued,
        GroupQueued,
        Running,
        GroupRunning,
        Finished,
        TimedOut,
        Terminated,
        Disabled,
        FailedToRun,
        Aborted,
        Canceled,
        WaitingForCheckOut,
    }


    /// <summary>
    /// Types of job Task. 
    /// </summary>
    public enum TaskType
    {
        PreTask,
        MainTask,
        PostTask
    }


    /// <summary>
    /// Types of events the Console can raise to inform plugins of occurrences.
    /// </summary>
    public enum PluginHostEventType
    {
        ConnectedToServer,
        DisconnectedFromServer,
        ResetSettings
    }

    public enum JobParaType
    {
        None,
        CasePassedChecked,
        CasePassedRate,
        FailTestCaseRecipient,
        SendFailTestCase,
        LogLocation,
        LogLocationChecked,
        DBVersion,
        ATCMServer,
        ATCMProject,
        ATCMPassword,
        ATCMLogin,
        ATCMDB,
        TCPIP,
        ServerAddress,
        ScriptLocation,
        DrivenUnit,
        TestProject,
        Password,
        UserName,
        TestEn,
        InteractiveInstall,
        IsSendMail,
        ReportTitle,
        EmailSender,
        ReportRecips,
        CC,
        AdhocBuild,
        Platform,
        DefinedCondition,
        ReleaseType,
        InstallType,
        DisplayName,
        ScriptLocationChecked,
        SharedFolder,
        BuildEXEPath,
    }


    [DataContract]
    public class TaskList
    {
        /// <summary>
        /// Any arbitrary parameters associated with the Task.
        /// </summary>
        [DataMember]
        public List<string> Parameters;
        /// <summary>
        /// Any environment variables to be set before running the Task.
        /// </summary>
        [DataMember]
        public List<string> EnvironmentVariables;
        /// <summary>
        /// The task to run before running the main task.
        /// </summary>
        [DataMember]
        public string PreTask;
        /// <summary>
        /// The main task that the ES will execute.
        /// </summary>
        [DataMember]
        public List<string> MainTasks;
        /// <summary>
        /// The task to run after the main task.
        /// </summary>
        [DataMember]
        public string PostTask;
        [DataMember]
        public List<string> WorkflowName;
        [DataMember]
        public List<string> Environment;
        [DataMember]
        public List<string> Restart;
        [DataMember]
        public List<string> PowerOff;
        [DataMember]
        public List<string> Objective;
        [DataMember]
        public List<string> StopTime;
        [DataMember]
        public List<string> Category;

       
    }


    public enum JobType
    {
        Normal,
        GroupMaster,
        GroupChild,
        Temporary
    }

    /// <summary>
    /// Represents an AJMS job; a single unit of work to be performed by an Exec Server.
    /// </summary>
    [DataContract]
    public class Job
    {
        /// <summary>
        /// The name of the job for display purposes.
        /// </summary>
        [DataMember]
        public string Name;
        /// <summary>
        /// The unique ID of the job.
        /// </summary>
        [DataMember]
        public string ID;
        /// <summary>
        /// The "type" of job; a way to categorize jobs. May be blank.
        /// </summary>
        [DataMember]
        public string Type;
        /// <summary>
        /// A list of requirements that the Execution Server must meet in order 
        /// to run this job.
        /// </summary>
        [DataMember]
        public List<string> Requirements;
        /// <summary>
        /// The job Schedule.
        /// </summary>
        [DataMember]
        public JobSchedule Schedule;
        /// <summary>
        /// The Task to be executed.
        /// </summary>
        [DataMember]
        public TaskList Tasks;
        /// <summary>
        ///  The job Status.
        /// </summary>
        [DataMember]
        public JobStatus Status;
        /// <summary>
        /// Whether the job is enabled or not. Schedules jobs which are not enabled
        /// will not be executed.
        /// </summary>
        [DataMember]
        public bool Enabled;
        /// <summary>
        /// The date and time the job was last executed.
        /// </summary>
        [DataMember]
        public DateTime LastRun;
        /// <summary>
        /// The username of the person who last ran the job (if the job was run
        /// be a schedule, it will be the owner of the job)
        /// </summary>
        [DataMember]
        public string LastRunBy;
        /// <summary>
        /// The result information of the last time the job was executed.
        /// </summary>
        [DataMember]
        public JobResult LastResult;
        /// <summary>
        /// The time the job took to run.
        /// </summary>
        [DataMember]
        public TimeSpan LastElapsedTime;
        /// <summary>
        /// The Windows login name of the person who created the job.
        /// </summary>
        [DataMember]
        public string Owner;
        /// <summary>
        /// Group ID is only assigned when the job is part of a JobGroup.
        /// This is only used server-side.
        /// </summary>
        [DataMember]
        public string GroupID = "";
        public Job ShallowCopy()
        {
            return (Job)MemberwiseClone();
        }
        /// <summary>
        /// When a job is part of a group, GroupIndex specifies
        /// which task in the list of Main Tasks this job should execute.
        /// </summary>
        [DataMember]
        public int GroupIndex = 0;
        [DataMember]
        public JobType JobType = JobType.Normal;

        [DataMember]
        public List<XMLReport> XMLReports;
        [DataMember]
        public List<Attributes> Attributes;
        [DataMember]
        public string HTML;
        [DataMember]
        public List<string> JobsAfterCompleted = new List<string>();

        public string JobName
        {
            get
            {
                return Name;
            }
        }

        public string DisplayOwner
        {
            get
            {
                return Owner;
            }
        }

        public string DisplaySchedule
        {
            get
            {
                return Schedule.ToString();
            }
        }

        [DataMember]
        public string ParentJobID = string.Empty;

        [DataMember]
        public string ParentJobName = string.Empty;

        public string DiplayParentJobName
        {
            get
            {
                return ParentJobName;
            }
            set
            {
                ParentJobName = value;
            }
        }

        public string DisplayStatus
        {
            get
            {
                if (Status != null)
                {
                    if (Status.State == JobStateType.Running)
                    {
                        return "Running since " + Status.StartTime.ToShortTimeString();
                    }
                    else
                    {
                        return Status.State.ToString();
                    }
                }
                else
                {
                    return string.Empty;
                }

            }
        }

        public string DisplayTask
        {
            get
            {
                StringBuilder Result = new StringBuilder();
                if (Tasks != null && Tasks.MainTasks != null && Tasks.MainTasks.Count == 1)    //only display child task or normal task
                {

                    for (int i = 0; i < Tasks.MainTasks.Count; i++)
                    {
                        Result.Append(Tasks.MainTasks[i]);
                        if (i != Tasks.MainTasks.Count - 1)
                        {
                            Result.Append("; ");
                        }
                    }
                }
                return Result.ToString();
            }
        }

        public Job()
        {
            Tasks = new TaskList();
            Tasks.MainTasks = new List<string>();
            Tasks.WorkflowName = new List<string>();
            Tasks.Category = new List<string>();
            Tasks.Environment = new List<string>();
            Tasks.Restart = new List<string>();
            Tasks.PowerOff = new List<string>();
            Tasks.Objective = new List<string>();
            Tasks.StopTime = new List<string>();
            Tasks.Parameters = new List<string>();
            Tasks.EnvironmentVariables = new List<string>();
            Status = new JobStatus();
            Schedule = new JobSchedule();
            Schedule.DaysOfWeek = new List<DayOfWeek>();
            LastResult = new JobResult();
            LastResult.Results = new List<string>();
            Requirements = new List<string>();

            XMLReports = new List<XMLReport>();
            Attributes = new List<Attributes>();
        }
    }

    /// <summary>
    /// Xml product history file
    /// </summary>
    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public string Name;
        [DataMember]
        public bool ShowHistoryFileOnReport;

        public string HistoryDirectory;
        public string ScriptFolder;
    }

    /// <summary>
    /// Xml history file
    /// </summary>
    public class ModifyHistoryFile
    {
        public string HistoryFileLocation;
        public string HistoryFileName;
        public string HistoryStatus;
        public List<ModifyHistory> Historys;
        public ModifyHistoryFile()
        {
            Historys = new List<ModifyHistory>();
        }
    }

    /// <summary>
    /// Xml history file
    /// </summary>
    public class ModifyHistory
    {
        public string FileLocation;
        public string HistoryRevision;
        public string HistoryAuthor;
        public string HistoryDate;
        public string HistoryComment;
        public string FileName;
        public string FileStatus;
    }

    [DataContract]
    public class TestEnvironmentInfo
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string ID;
        [DataMember]
        public string OSPlatform;
        [DataMember]
        public string OSLanguage;
        [DataMember]
        public string DatabaseVersion;
        //Yourself set run vm max value.
        [DataMember]
        public string ExecServer;
        [DataMember]
        public string UnlimitedExecServer;
        [DataMember]
        public List<Attributes> Attributes;
        //You can run max vm.
        [DataMember]
        public string MaxES;

        private bool FSelected = false;
        public bool DisplaySelected
        {
            get
            {
                return FSelected;
            }
            set
            {
                FSelected = value;
            }
        }
        public string DisplayName
        {
            get
            {
                return Name;
            }
        }

        public string DisplayOSPlatform
        {
            get
            {
                return OSPlatform;
            }
        }

        public string DisplayOSLanguage
        {
            get
            {
                return OSLanguage;
            }
        }

        public string DisplayExecServer
        {
            get
            {
                return ExecServer;
            }
        }

        public string DisplayMaxES
        {
            get
            {
                if (UnlimitedExecServer.ToLower() == "true")
                {
                    return "Unlimited";
                }
                else
                {
                    return MaxES;
                }
            }
        }

        public string DisplayAttributes
        {
            get
            {
                string strAttributes = string.Empty;

                for (int i = 0; i < Attributes.Count; i++)
                {
                    strAttributes = Attributes[i].Key + "->" + Attributes[i].Value;
                    if (i != Attributes.Count - 1)
                    {
                        strAttributes += " | ";
                    }
                }
                return strAttributes;
            }
        }


        public TestEnvironmentInfo()
        {
            Attributes = new List<Attributes>();
        }
    }

    /// <summary>
    /// Represents schedule information of a Job.
    /// </summary>
    [DataContract]
    public class JobSchedule
    {
        [DataMember]
        public JobScheduleType SchedType;
        [DataMember]
        public List<DayOfWeek> DaysOfWeek;
        [DataMember]
        public DateTime StartTime;
        [DataMember]
        public DateTime StopTime;
        [DataMember]
        public string DropSpec;
        [DataMember]
        public DateTime LastDropTime;
        [DataMember]
        public bool CanRun = false;
        [DataMember]
        public string AfterJobsID;

        public bool Equals(JobSchedule obj)
        {
            return (SchedType == obj.SchedType) && (StartTime == obj.StartTime) && (LastDropTime == obj.LastDropTime);
        }
    }


    /// <summary>
    /// Represents the status of a job currently in the Queue.
    /// </summary>
    [DataContract]
    public class JobStatus
    {
        // JobID is only used serverside
        public string JobID;
        [DataMember]
        public DateTime StartTime;
        [DataMember]
        public string Machine;
        [DataMember]
        public JobStateType State;
    }

    /// <summary>
    /// Implements a List<> of TaskInfo.
    /// </summary>
    public class TaskInfoList : List<TaskInfo>
    {
        /// <summary>
        /// Returns true if list contains any TaskInfo's with matching Name.
        /// </summary>
        /// <param name="TaskName"></param>
        /// <returns></returns>
        public new bool Contains(TaskInfo Task)
        {
            foreach (TaskInfo ti in this)
            {
                if (string.Compare(ti.Name, Task.Name, true) == 0)
                    return true;
            }
            return false;
        }
        public bool Contains(string TaskName)
        {
            foreach (TaskInfo ti in this)
            {
                if (string.Compare(ti.Name, TaskName, true) == 0)
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Represents information about an Execution Server.
    /// </summary>
    [DataContract]
    public class ExecServerInfo
    {
        /// <summary>
        /// The machine name of the ES.
        /// </summary>
        [DataMember]
        public string HostName;
        /// <summary>
        /// Any arbitrary name given to the ES (stored in its config file).
        /// </summary>
        [DataMember]
        public string Alias;
        /// <summary>
        /// The current status of the ES, such as "Idle" or "Running job: ..."
        /// </summary>
        [DataMember]
        public string Status;
        /// <summary>
        /// List of arbitrary information about the ES which may be useful to the console.
        /// </summary>
        [DataMember]
        public List<string> Attributes;
        /// <summary>
        /// The "class" of this Execution Server. If this has a value,
        /// the MS will obtain the list of this server's tasks from a 
        /// local file. The ES will query the MS for its tasks and apps,
        /// instead of having its own local files.
        /// </summary>
        //[DataMember]
        //public string Class;
        /// <summary>
        /// List of tasks the ES is set up to run. If Class has a value, 
        /// this list is ignored.
        /// </summary>
        [DataMember]
        public TaskInfoList Tasks;
        /// <summary>
        /// List of arbitrary information about the ES which may be useful to the console.
        /// </summary>
        [DataMember]
        public List<string> ApplicationName;
    }

    /// <summary>
    /// TestCase
    /// </summary>
    [DataContract]
    public class TestCase : ICloneable
    {
        [DataMember]
        public string ProductName;
        [DataMember]
        public string ProductVersion;
        [DataMember]
        public string Name;
        [DataMember]
        public string Objective;
        [DataMember]
        public string Category;
        [DataMember]
        public string Workflow;
        [DataMember]
        public string Status;
        [DataMember]
        public string Result;
        [DataMember]
        public string StartTime;
        [DataMember]
        public string EndTime;
        [DataMember]
        public string Duration;
        [DataMember]
        public string Message;

        public string RestartVM;
        public string PowerOff;
        public string Environment;
        public string StopTime;

        #region ICloneable Members

        public object Clone()
        {
            TestCase temp = new TestCase();
            temp.ProductName = ProductName;
            temp.ProductVersion = ProductVersion;
            temp.Name = Name;
            temp.Workflow = Workflow;
            temp.Category = Category;
            temp.Status = Status;
            temp.Result = Result;
            temp.StartTime = StartTime;
            temp.EndTime = EndTime;
            temp.Duration = Duration;
            temp.Message = Message;
            return temp;
        }

        #endregion

    }

    /// <summary>
    /// Xml report
    /// </summary>
    [DataContract]
    public class XMLReport : ICloneable
    {
        [DataMember]
        public string ServerName;
        [DataMember]
        public string ServerOS;
        [DataMember]
        public string ServerNU;
        [DataMember]
        public string ServerSF;
        [DataMember]
        public string ServerIP;
        [DataMember]
        public List<TestCase> TestCases;

        public XMLReport()
        {
            TestCases = new List<TestCase>();
        }

        #region ICloneable Members

        public object Clone()
        {
            XMLReport temp = new XMLReport();
            temp.ServerName = ServerName;
            temp.ServerOS = ServerOS;
            temp.ServerNU = ServerNU;
            temp.ServerSF = ServerSF;
            temp.ServerIP = ServerIP;

            foreach (TestCase varTestCase in TestCases)
            {
                TestCase newTestCase = (TestCase)varTestCase.Clone();
                temp.TestCases.Add(newTestCase);
            }
            return temp;
        }

        #endregion
    }


    /// <summary>
    /// Represents information about a Job that has been run by an ES. The ES
    /// must populate an instance of this class and return it on completion of a job.
    /// </summary>
    [DataContract]
    public class JobResult
    {

        /// <summary>
        /// The Execution Server on which the job ran.
        /// </summary>
        [DataMember]
        public string Server;
        /// <summary>
        /// The JobStateType assigned to the Job by the ES after it ran.
        /// </summary>
        [DataMember]
        public JobStateType ResultState;
        /// <summary>
        /// Any arbitrary information returned by the task itself, such as
        /// test results.
        /// </summary>
        [DataMember]
        public List<string> Results;
        /// <summary>
        /// Any message associated with an error in running the main task of the job.
        /// </summary>
        [DataMember]
        public string Message;
        /// <summary>
        /// The exit code returned by the actual task.
        /// </summary>
        [DataMember]
        public int ExitCode;
        /// <summary>
        /// The XML report path
        /// </summary>
        [DataMember]
        public List<string> XMLReportPath = new List<string>();

    }


    [DataContract]
    public class TaskInfo
    {
        [DataMember]
        public string Name;
        [DataMember]
        public TaskType Type;
        [DataMember]
        public List<string> Attributes;
        [DataMember]
        public string Description;
        public TaskInfo()
        {
            Attributes = new List<string>();
        }
    }

    /// <summary>
    /// Represents the snapshot info of a VM execution server
    /// </summary>
    [DataContract]
    public class SnapshotInfo : ICloneable
    {
        [DataMember]
        public string SnapshotName;
        [DataMember]
        public string Description;
        [DataMember]
        public List<Attributes> Attributes = new List<Attributes>();

        public string DisplaySnapshotName
        {
            get
            {
                return SnapshotName;
            }
        }

        public string DisplayDescription
        {
            get
            {
                return Description;
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            SnapshotInfo temp = new SnapshotInfo();
            temp.SnapshotName = SnapshotName;
            temp.Description = Description;

            foreach (Attributes varAttributes in Attributes)
            {
                Attributes newAttributes = (Attributes)varAttributes.Clone();
                temp.Attributes.Add(newAttributes);
            }
            return temp;
        }

        #endregion
    }

    [DataContract]
    public class Attributes : ICloneable
    {
        [DataMember]
        public string Key;
        [DataMember]
        public string Value;

        public string DisplayKey
        {
            get
            {
                return Key;
            }
        }

        public string DisplayValue
        {
            get
            {
                return Value;
            }
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj != null && obj is Attributes)
            {
                Attributes tempobj = obj as Attributes;
                if (tempobj.Key == this.Key && tempobj.Value == this.Value)
                {
                    result = true;
                }
            }

            return result;
        }

        #region ICloneable Members

        public object Clone()
        {
            Attributes temp = new Attributes();
            temp.Key = Key;
            temp.Value = Value;

            return temp;
        }

        #endregion
    }

    /// <summary>
    /// Represents the status of a VM execution server
    /// </summary>
    public enum VMESStatus
    {
        Running,
        Stopped,
        StartRequest,
        StartSuccess,
        StartInProgress,
        StopInProgress,
        StopRequest,
        StopSuccess,
        Error
    }

    /// <summary>
    /// Represents inforamtion of a VM exection server for turning VM on or off
    /// </summary>
    [DataContract]
    public class VMExecServer : ICloneable
    {
        #region private setcion
        private string FID;
        private string FVMComputerName;
        private string FHost;
        private VMESStatus FStatus;
        private string FVMFileName;
        private string FOSPlatform;
        private string FOSLanguage;
        private string FRemarks;
        private List<SnapshotInfo> FSnapshotInfo;
        private string FRunningJobID;
        private string FActiveSnapshot;
        private string FMessage = string.Empty;

        #endregion

        /// <summary>
        /// Computer name of VMWare Workstation host
        /// </summary>
        [DataMember]
        public string ID
        {
            get { return FID; }
            set { FID = value; }
        }

        /// <summary>
        /// Computer name of VMWare Workstation host
        /// </summary>
        [DataMember]
        public string Host
        {
            get { return FHost; }
            set { FHost = value; }
        }

        /// <summary>
        /// Computer name of VM
        /// </summary>
        [DataMember]
        public string VMComputerName
        {
            get { return FVMComputerName; }
            set { FVMComputerName = value; }
        }

        /// <summary>
        /// file name of VM
        /// </summary>
        [DataMember]
        public string VMFileName
        {
            get { return FVMFileName; }
            set { FVMFileName = value; }
        }

        [DataMember]
        public VMESStatus Status
        {
            get { return FStatus; }
            set
            {
                lock (this)
                {
                    FStatus = value;
                }
            }
        }

        public string DisplayStatus
        {
            get
            {
                return Status.ToString();
            }
        }

        [DataMember]
        public string OSPlatform
        {
            get { return FOSPlatform; }
            set { FOSPlatform = value; }
        }

        [DataMember]
        public string OSLanguage
        {
            get { return FOSLanguage; }
            set { FOSLanguage = value; }
        }

        [DataMember]
        public string Remarks
        {
            get { return FRemarks; }
            set { FRemarks = value; }
        }

        [DataMember]
        public string Message
        {
            get
            {
                if (Status != VMESStatus.Stopped)
                {
                    return FMessage;
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                FMessage = value;
            }
        }

        [DataMember]
        public List<SnapshotInfo> SnapshotInfo
        {
            get { return FSnapshotInfo; }
            set { FSnapshotInfo = value; }
        }

        /// <summary>
        /// it is assigned to GroupID when the job is a grouping job
        /// it should be JobID if the job is not a grouping job
        /// </summary>
        [DataMember]
        public string RunningJobID
        {
            get { return FRunningJobID; }
            set { FRunningJobID = value; }
        }

        /// <summary>
        /// it is assigned to GroupID when the job is a grouping job
        /// it should be JobID if the job is not a grouping job
        /// </summary>
        [DataMember]
        public string ActiveSnapshot
        {
            get { return FActiveSnapshot; }
            set { FActiveSnapshot = value; }
        }

        [DataMember]
        public string TestEn;

        [DataMember]
        public string StartTime;

        [DataMember]
        public string EndTime;

        public VMExecServer(string aID, string aVMComputerName, string aHost, VMESStatus aStatus, string aVMFileName, string aOSPlatform, string aOSLanguage, string aRemarks, List<SnapshotInfo> aSnapshotInfo)
        {
            FID = aID;
            FVMComputerName = aVMComputerName;
            FHost = aHost;
            FStatus = aStatus;
            FVMFileName = aVMFileName;
            FOSPlatform = aOSPlatform;
            FOSLanguage = aOSLanguage;
            FRemarks = aRemarks;
            FSnapshotInfo = new List<SnapshotInfo>();
            FActiveSnapshot = "";
            if (aSnapshotInfo != null)
            {
                foreach (SnapshotInfo lsSnapshotInfo in aSnapshotInfo)
                {
                    FSnapshotInfo.Add(lsSnapshotInfo);
                }
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            List<SnapshotInfo> listSnapshotInfo = new List<SnapshotInfo>();

            VMExecServer temp = new VMExecServer("", "", "", VMESStatus.Stopped, "", "", "", "", listSnapshotInfo);
            temp.ID = ID;
            temp.Host = Host;
            temp.VMComputerName = VMComputerName;
            temp.VMFileName = VMFileName;
            temp.Status = Status;
            temp.OSPlatform = OSPlatform;
            temp.OSLanguage = OSLanguage;
            temp.Remarks = Remarks;
            temp.Message = Message;
            temp.RunningJobID = RunningJobID;
            temp.ActiveSnapshot = ActiveSnapshot;
            temp.TestEn = TestEn;
            temp.StartTime = StartTime;
            temp.EndTime = EndTime;

            foreach (SnapshotInfo varSnapshotInfo in SnapshotInfo)
            {
                SnapshotInfo newSnapshotInfo = (SnapshotInfo)varSnapshotInfo.Clone();
                temp.SnapshotInfo.Add(newSnapshotInfo);
            }
            return temp;
        }

        #endregion
    }

    public enum AJMSTaskType
    {
        RunProgram,
        TransferFiles,
        CopyBuild
    }

    public class AJMSTask
    {
        private bool FWaitProcess = true;
        private bool FVisiableInUI = false;
        private AJMSTaskType FCurrentType = AJMSTaskType.RunProgram;
        private string FProgramFullName = string.Empty;
        private string FArguments = string.Empty;
        private string FSource = string.Empty;
        private string FDestination = string.Empty;
        private string FBuildDestination = string.Empty;
        private string FBuildSource = string.Empty;
        private bool FCopyBuildChecked = false;
        private string FCasePassedRate = string.Empty;

        public bool WaitProcess
        {
            get { return FWaitProcess; }
            set { FWaitProcess = value; }
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

        public string Arguments
        {
            get { return FArguments; }
            set { FArguments = value; }
        }

        public string ProgramFullName
        {
            get { return FProgramFullName; }
            set { FProgramFullName = value; }
        }

        public AJMSTaskType CurrentType
        {
            get { return FCurrentType; }
            set { FCurrentType = value; }
        }

        public bool VisiableInUI
        {
            get { return FVisiableInUI; }
            set { FVisiableInUI = value; }
        }

        public string BuildDestination
        {
            get { return FBuildDestination; }
            set { FBuildDestination = value; }
        }

        public string BuildSource
        {
            get { return FBuildSource; }
            set { FBuildSource = value; }
        }

        public bool CopyBuildChecked
        {
            get { return FCopyBuildChecked; }
            set { FCopyBuildChecked = value; }
        }

        public string CasePassedRate
        {
            get { return FCasePassedRate; }
            set { FCasePassedRate = value; }
        }

        public int IntCasePassedRate
        {
            get
            {
                int rate = 0;
                if (string.IsNullOrEmpty(CasePassedRate) == false)
                {
                    //CasePassedRate may be 0
                    string strRate = CasePassedRate.Substring(0, CasePassedRate.Length - 1);
                    if (Int32.TryParse(strRate, out rate))
                    {
                        rate = 0;
                    }
                }

                return rate;
            }
        }

        public AJMSTask()
        {
        }

        public AJMSTask(AJMSTaskType aType)
        {
            CurrentType = aType;
        }

        public static AJMSTaskType StringToEnum(string aEnumStr)
        {
            AJMSTaskType Result = (AJMSTaskType)Enum.Parse(typeof(AJMSTaskType), aEnumStr);
            return Result;
        }
    }

    public static class TXMLOperator
    {
        public static XmlWriterSettings InterWriteSettings
        {
            get
            {
                XmlWriterSettings _Settings = new XmlWriterSettings();
                _Settings.Encoding = Encoding.Unicode;
                _Settings.OmitXmlDeclaration = true;
                return _Settings;
            }
        }
    }

    public class AJMSTaskXMLOperator
    {
        private const string C_XML_Tasks = "Tasks";
        private const string C_XML_Task = "Task";
        private const string C_XML_VisiableInUI = "VisiableInUI";
        private const string C_XML_WaitProcess = "WaitProcess";
        private const string C_XML_Type = "Type";
        private const string C_XML_ProgramFullName = "ProgramFullName";
        private const string C_XML_Arg = "Arguments";
        private const string C_XML_Source = "Source";
        private const string C_XML_Destination = "Destination";
        private const string C_XML_BuildSource = "BuildSource";
        private const string C_XML_BuildDestination = "BuildDestination";
        private const string C_XML_CopyBuildChecked = "CopyBuildChecked";
        private const string C_XML_CasePassedRate = "CasePassedRate";

        public static List<AJMSTask> TasksFromXML(string aTaskXML)
        {
            List<AJMSTask> Result = new List<AJMSTask>();
            if (string.IsNullOrEmpty(aTaskXML) == false)
            {
                using (StringReader sr = new StringReader(aTaskXML))
                {
                    using (XmlReader Reader = XmlReader.Create(sr))
                    {
                        TaskReader(Reader, ref Result);
                    }
                }
            }
            return Result;
        }

        public static void TaskReader(XmlReader aReader, ref List<AJMSTask> aTaskList)
        {
            aReader.Read();
            aReader.MoveToContent();
            while (aReader.Read())
            {
                aReader.MoveToContent();
                if (aReader.Name.Equals(C_XML_Tasks) && aReader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }

                if (aReader.IsStartElement(C_XML_Task))
                {
                    AJMSTask task = new AJMSTask();
                    if (aReader.MoveToAttribute(C_XML_VisiableInUI))
                    {
                        bool visible;
                        if (Boolean.TryParse(aReader.Value, out visible))
                        {
                            task.VisiableInUI = visible;
                        }
                    }

                    if (aReader.MoveToAttribute(C_XML_Type))
                    {
                        AJMSTaskType type = AJMSTask.StringToEnum(aReader.Value);
                        task.CurrentType = type;
                    }

                    if (aReader.MoveToAttribute(C_XML_WaitProcess))
                    {
                        bool wait;
                        if (Boolean.TryParse(aReader.Value, out wait))
                        {
                            task.WaitProcess = wait;
                        }
                    }

                    ReadTaskInfo(aReader, ref task);
                    aTaskList.Add(task);
                }

            }
        }

        private static void ReadTaskInfo(XmlReader aReader, ref AJMSTask aTask)
        {
            string VMFile = string.Empty;
            aReader.MoveToContent();
            while (aReader.Read())
            {
                aReader.MoveToContent();
                if (aReader.NodeType == XmlNodeType.EndElement && aReader.Name.Equals(C_XML_Task))
                {
                    break;
                }
                if (aReader.IsStartElement(C_XML_ProgramFullName))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.ProgramFullName = aReader.Value;
                    }

                }
                else if (aReader.IsStartElement(C_XML_Arg))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Arguments = aReader.Value;
                    }

                }
                else if (aReader.IsStartElement(C_XML_Source))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Source = aReader.Value;
                    }

                }
                else if (aReader.IsStartElement(C_XML_Destination))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Destination = aReader.Value;
                    }

                }
                else if (aReader.IsStartElement(C_XML_BuildSource))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.BuildSource = aReader.Value;
                    }
                }
                else if (aReader.IsStartElement(C_XML_BuildDestination))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.BuildDestination = aReader.Value;
                    }
                }

                else if (aReader.IsStartElement(C_XML_CopyBuildChecked))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.CopyBuildChecked = Convert.ToBoolean(aReader.Value);
                    }
                }
                else if (aReader.IsStartElement(C_XML_CasePassedRate))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.CasePassedRate = aReader.Value;
                    }
                }
            }
        }

        public static string AJMSTaskToXML(BindingList<AJMSTask> aListTask)
        {
            List<AJMSTask> TaskList = new List<AJMSTask>();
            TaskList.AddRange(aListTask);
            return AJMSTaskToXML(TaskList);
        }

        public static string AJMSTaskToXML(List<AJMSTask> aListTask)
        {
            StringBuilder sbResult = new StringBuilder();
            if (aListTask.Count > 0)
            {
                using (XmlWriter _Writer = XmlWriter.Create(sbResult, TXMLOperator.InterWriteSettings))
                {
                    _Writer.WriteStartDocument();
                    _Writer.WriteStartElement(C_XML_Tasks);
                    foreach (AJMSTask task in aListTask)
                    {
                        _Writer.WriteRaw(TaskToXML(task));
                    }

                    _Writer.WriteEndElement();  //end of C_XML_Tasks
                    _Writer.WriteEndDocument();
                    _Writer.Close();
                }
            }
            return sbResult.ToString();
        }

        private static string TaskToXML(AJMSTask aTask)
        {
            StringBuilder sbResult = new StringBuilder();
            using (XmlWriter _Writer = XmlWriter.Create(sbResult, TXMLOperator.InterWriteSettings))
            {
                _Writer.WriteStartDocument();
                _Writer.WriteStartElement(C_XML_Task);
                _Writer.WriteAttributeString(C_XML_Type, aTask.CurrentType.ToString());
                _Writer.WriteAttributeString(C_XML_VisiableInUI, aTask.VisiableInUI.ToString());
                _Writer.WriteAttributeString(C_XML_WaitProcess, aTask.WaitProcess.ToString());
                if (aTask.CurrentType == AJMSTaskType.RunProgram)
                {
                    _Writer.WriteStartElement(C_XML_ProgramFullName);
                    _Writer.WriteCData(aTask.ProgramFullName);
                    _Writer.WriteEndElement();//end of C_XML_ProgramFullName

                    _Writer.WriteStartElement(C_XML_Arg);
                    _Writer.WriteCData(aTask.Arguments);
                    _Writer.WriteEndElement();//end of C_XML_Arg
                }
                else if (aTask.CurrentType == AJMSTaskType.TransferFiles)
                {
                    _Writer.WriteStartElement(C_XML_Source);
                    _Writer.WriteCData(aTask.Source);
                    _Writer.WriteEndElement();//end of C_XML_Source

                    _Writer.WriteStartElement(C_XML_Destination);
                    _Writer.WriteCData(aTask.Destination);
                    _Writer.WriteEndElement();//end of C_XML_Destination
                }
                else if (aTask.CurrentType == AJMSTaskType.CopyBuild)
                {
                    _Writer.WriteStartElement(C_XML_CopyBuildChecked);
                    _Writer.WriteCData(aTask.CopyBuildChecked.ToString());
                    _Writer.WriteEndElement();//end of C_XML_CopyBuildChecked

                    _Writer.WriteStartElement(C_XML_CasePassedRate);
                    _Writer.WriteCData(aTask.CasePassedRate.ToString());
                    _Writer.WriteEndElement();//end of C_XML_CasePassedRate

                    _Writer.WriteStartElement(C_XML_BuildSource);
                    _Writer.WriteCData(aTask.BuildSource);
                    _Writer.WriteEndElement();//end of C_XML_BuildSource

                    _Writer.WriteStartElement(C_XML_BuildDestination);
                    _Writer.WriteCData(aTask.BuildDestination);
                    _Writer.WriteEndElement();//end of C_XML_BuildDestination
                }

                _Writer.WriteEndElement();//end of C_XML_Task
                _Writer.WriteEndDocument();
                _Writer.Close();
            }
            return sbResult.ToString();
        }

    }


    [DataContract]
    public class TCInfo
    {
        #region private setcion
        private string FID;
        private string FProject;
        private string FScriptLocation;
        private string FDrivenUnit;
        private string FApp;
        private string FDefaultPreTask;
        private string FPreTask;
        private string FATCMServer;
        private string FATCMDB;
        private string FATCMLogin;
        private string FATCMPassword;
        private string FATCMProject;
        private string FLogLocation;
        private List<string> FBuildFolder;
        #endregion

        [DataMember]
        public string ID
        {
            get { return FID; }
            set { FID = value; }
        }

        [DataMember]
        public string Project
        {
            get { return FProject; }
            set { FProject = value; }
        }

        [DataMember]
        public string ScriptLocation
        {
            get { return FScriptLocation; }
            set { FScriptLocation = value; }
        }

        [DataMember]
        public string DrivenUnit
        {
            get { return FDrivenUnit; }
            set { FDrivenUnit = value; }
        }

        [DataMember]
        public string App
        {
            get { return FApp; }
            set { FApp = value; }
        }

        [DataMember]
        public string DefaultPreTask
        {
            get { return FDefaultPreTask; }
            set { FDefaultPreTask = value; }
        }

        [DataMember]
        public string PreTask
        {
            get { return FPreTask; }
            set { FPreTask = value; }
        }

        [DataMember]
        public string ATCMLogin
        {
            get { return FATCMLogin; }
            set { FATCMLogin = value; }
        }

        [DataMember]
        public string ATCMPassword
        {
            get { return FATCMPassword; }
            set { FATCMPassword = value; }
        }

        [DataMember]
        public string ATCMProject
        {
            get { return FATCMProject; }
            set { FATCMProject = value; }
        }

        [DataMember]
        public string ATCMServer
        {
            get { return FATCMServer; }
            set { FATCMServer = value; }
        }

        [DataMember]
        public string ATCMDB
        {
            get { return FATCMDB; }
            set { FATCMDB = value; }
        }

        [DataMember]
        public string LogLocation
        {
            get { return FLogLocation; }
            set { FLogLocation = value; }
        }

        [DataMember]
        public List<string> BuildFolder
        {
            get { return FBuildFolder; }
            set { FBuildFolder = value; }
        }

        private bool FVisible = true;
        public bool Visible
        {
            get
            {
                return FVisible;
            }
            set
            {
                FVisible = value;
            }
        }

        [DataMember]
        public string EXE;

        [DataMember]
        public string Belong;

        public TCInfo(string aID)
        {
            FID = aID;
        }

        public TCInfo(string aID, string aProject, string aScriptLocation, string aDrivenUnit, string aApp, string aDefaultPreTask, string aPreTask, string aATCMDB, string aLogLocation, List<string> aBuildFolder)
        {
            FID = aID;
            FProject = aProject;
            FScriptLocation = aScriptLocation;
            FDrivenUnit = aDrivenUnit;
            FApp = aApp;
            FDefaultPreTask = aDefaultPreTask;
            FPreTask = aPreTask;
            FATCMDB = aATCMDB;
            FLogLocation = aLogLocation;
            FBuildFolder = new List<string>();
            if (aBuildFolder != null)
            {
                foreach (string var in aBuildFolder)
                {
                    FBuildFolder.Add(var);
                }
            }
        }
    }


    /// <summary>
    /// This interface defines an AJMS Job Management Service client/server communication
    /// contract. Clients include the AJMS Console and the AJMS Execution Server.
    /// </summary>
    [ServiceContract]
    public interface IJobManagementService
    {
        // Console stuff

        [OperationContract]
        List<string> GetSchedulesID();
        [OperationContract]
        Job GetSchedulesJob(string JobID);
        /// <summary>
        ///  Returns the list of registered execution servers.
        /// </summary>
        [OperationContract]
        List<ExecServerInfo> GetServers();
        /// <summary>
        ///  Returns the whole Job Queue.
        /// </summary>
        [OperationContract]
        List<Job> GetQueue();
        /// <summary>
        ///  Returns only the jobs in the queue which still have a Queued status.
        /// </summary>
        [OperationContract]
        List<Job> GetQueuedJobs();
        [OperationContract]
        List<string> GetQueueID();
        [OperationContract]
        List<string> GetQueuedJobsID();
        [OperationContract]
        Job GetJob(string JobID);
        /// <summary>
        /// Tells the service to add one or more jobs to the queue (by Job ID).
        /// Jobs must already exist in Schedules.
        /// </summary>
        [OperationContract]
        List<string> QueueJobs(List<string> JobIDs, string Owner);
        /// <summary>
        /// Adds one or more jobs to the Schedule (the list of available jobs kept by the service).
        /// </summary>
        [OperationContract]
        void ScheduleJobs(List<Job> Jobs);
        /// <summary>
        /// Returns a list of tasks available to be run by the group of registered Execution Servers.
        /// </summary>
        [OperationContract]
        List<TaskInfo> GetAvailableTasks();
        /// <summary>
        ///  Cancels one or more jobs in the job queue.
        /// </summary>
        [OperationContract]
        void CancelJobs(List<string> JobIDs);
        /// <summary>
        ///  Cancels one or more jobs in the job queue.
        /// </summary>
        [OperationContract]
        void CancelJobsByUser(List<string> JobIDs, string aUserName);
        /// <summary>
        /// Deletes one or more jobs from the Schedule.
        /// If job is queued, cancel it too?
        /// </summary>
        [OperationContract]
        void DeleteJobs(List<string> JobIDs);
        /// <summary>
        ///  Enables one or more disabled jobs in the Schedule.
        /// </summary>
        [OperationContract]
        void EnableJobs(List<string> JobIDs);
        /// <summary>
        ///  Disables one or more jobs in the Schedule.
        /// </summary>
        [OperationContract]
        void DisableJobs(List<string> JobIDs);
        /// <summary>
        /// Allows an ES to inform the MS that it intends to run a job.
        /// If the job has already been claimed, the MS will return false, and the 
        /// ES won't run it. Otherwise the MS will set the job status to Running and 
        /// return true. 
        /// 
        /// This protocol prevents multiple ExecServers from starting the same job.
        /// </summary>
        [OperationContract]
        bool ClaimJob(string ID, string ExecServerName);

        /// <summary>
        /// To ask service if the exection server aServerInfo can clamin the job. 
        /// </summary>
        /// <param name="aServerInfo">execution server information</param>
        /// <param name="aJob">queued job</param>
        /// <returns>if the ES can claim the job then return true, else false</returns>
        [OperationContract]
        bool CanClaimJob(ExecServerInfo aExecServerInfo, Job aQueuedJob, bool abolRunFirstTestCase);

        /// <summary>
        /// Notifies the MS that an ES has finished running a job.
        /// </summary>
        [OperationContract]
        bool? JobComplete(string JobID, JobResult Result);
        /// <summary>
        ///  Registers an Execution Server with the MS.
        /// </summary>
        [OperationContract]
        void RegisterExecServer(ExecServerInfo ServerInfo);
        /// <summary>
        /// Allows an ES to inform the MS that it is no longer available.
        /// ESes should always call this before shutting down.
        /// </summary>
        [OperationContract]
        void UnregisterExecServer(string HostName);
        /// <summary>
        /// Allows an ES to notify the MS of its status.
        /// </summary>
        [OperationContract]
        void SetExecServerStatus(string HostName, string Status);
        /// <summary>
        ///  Returns the list of job results currentely known by the MS.
        /// (Not yet implemented)
        /// </summary>
        [OperationContract]
        List<string> GetResultsList();
        /// <summary>
        ///  Allows a client to requests a report to be compiled from the 
        /// given list of results files.
        /// (Not yet implemented)
        /// </summary>
        [OperationContract]
        void RunReport(List<string> Results);
        /// <summary>
        /// Returns the version of the Job Management Server.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string Version();
        /// <summary>
        /// Outputs a message at the MS console.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        event OutputHandler OnOutput;
        /// <summary>
        /// Returns the DateTime of the last modification of the Queue.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DateTime QueueLastModified();
        /// <summary>
        /// Returns the DateTime of the last modification of the Schedule.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DateTime ScheduleLastModified();
        /// <summary>
        /// Notifies the Management Server that a Console has connected.
        /// </summary>
        /// <param name="HostName"></param>
        [OperationContract]
        void RegisterConsole(string HostName);
        /// <summary>
        /// Notifies the Management Server that a Console is disconnecting.
        /// </summary>
        /// <param name="HostName"></param>
        [OperationContract]
        void UnregisterConsole(string HostName);
        /// <summary>
        /// Returns the list of available VM execution servers.
        /// </summary>        
        [OperationContract]
        List<VMExecServer> GetVMExecServers();
        /// <summary>
        /// Set the status of VM execution server
        /// </summary>
        /// <param name="aExecServer"></param>
        [OperationContract]
        void UpdateVMExecServerStatus(VMExecServer aExecServer, VMESStatus aStatus, string aErrrMessage);

        [OperationContract]
        Dictionary<string, string> GetRunningESInfo();
        /// <summary>
        /// Returns the list of available VM execution servers.
        /// </summary>        
        [OperationContract]
        void ESAddOrReplace(VMExecServer es);
        /// <summary>
        /// Returns the list of available VM execution servers.
        /// </summary>        
        [OperationContract]
        void ESDelete(VMExecServer es);
        [OperationContract]
        List<string> ESGetSnapshotList(string aHostName, string aVMFile);
        [OperationContract]
        List<TCInfo> GetTCInfo();
        [OperationContract]
        void TCInfoAddOrReplace(TCInfo aTCInfo);
        [OperationContract]
        void TCInfoDelete(string ID);
        /// <summary>
        /// Returns TestEnvironment class function
        /// </summary>     
        [OperationContract]
        void TestEnAddOrReplace(TestEnvironmentInfo aTestEn);
        [OperationContract]
        void TestEnDelete(TestEnvironmentInfo aTestEn);
        [OperationContract]
        List<TestEnvironmentInfo> GetTestEn();
        [OperationContract]
        void ApplyAllJobStarTeamInfo(List<string> aStarTeamInfo);
        [OperationContract]
        void LoadESXINI();
        [OperationContract]
        string ReconnectAllESXSvr();
        [OperationContract]
        string ReconnectESXSvr(string aSvrName);
        [OperationContract]
        void AllESStatusToStopped();

        [OperationContract]
        string GetPreTask(string aEn);

        /// <summary>
        /// FileTransfer with stream
        /// </summary>
        /// <param name="aFileName"></param>
        /// <returns></returns>
        [OperationContract]
        long FileSpicalSize(string aFileName);

        [OperationContract]
        Stream DownloadFileWithCustomStream(string aFilePath, long aOffset, long aCount);

        [OperationContract]
        string[] GetFiles(string aPath, string aSearchPattern, SearchOption aSearchOption);

        /// <summary>
        /// Show product on console from xml
        /// </summary>
        [OperationContract]
        ProductInfo[] GetProducts();
    }

    /// <summary>
    /// Used by the AJMS Console to handle output from plugins.
    /// </summary>
    /// <param name="Message"></param>
    public delegate void OutputHandler(string Message);
    

   
}
