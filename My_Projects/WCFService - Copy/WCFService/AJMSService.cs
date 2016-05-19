using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AJMS
{
    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    //[DeliveryRequirements(TargetContract = typeof(IMyService), RequireOrderedDelivery = true)]
    public class AJMSService : IJobManagementService
    {
        public List<string> GetSchedulesID()
        {
            throw new NotImplementedException();
        }

        public Job GetSchedulesJob(string JobID)
        {
            throw new NotImplementedException();
        }

        public List<ExecServerInfo> GetServers()
        {
            throw new NotImplementedException();
        }

        public List<Job> GetQueue()
        {
            throw new NotImplementedException();
        }

        public List<Job> GetQueuedJobs()
        {
            throw new NotImplementedException();
        }

        public List<string> GetQueueID()
        {
            throw new NotImplementedException();
        }

        public List<string> GetQueuedJobsID()
        {
            throw new NotImplementedException();
        }

        public Job GetJob(string JobID)
        {
            throw new NotImplementedException();
        }

        public List<string> QueueJobs(List<string> JobIDs, string Owner)
        {
            throw new NotImplementedException();
        }

        public void ScheduleJobs(List<Job> Jobs)
        {
            throw new NotImplementedException();
        }

        public List<TaskInfo> GetAvailableTasks()
        {
            throw new NotImplementedException();
        }

        public void CancelJobs(List<string> JobIDs)
        {
            throw new NotImplementedException();
        }

        public void CancelJobsByUser(List<string> JobIDs, string aUserName)
        {
            throw new NotImplementedException();
        }

        public void DeleteJobs(List<string> JobIDs)
        {
            throw new NotImplementedException();
        }

        public void EnableJobs(List<string> JobIDs)
        {
            throw new NotImplementedException();
        }

        public void DisableJobs(List<string> JobIDs)
        {
            throw new NotImplementedException();
        }

        public bool ClaimJob(string ID, string ExecServerName)
        {
            throw new NotImplementedException();
        }

        public bool CanClaimJob(ExecServerInfo aExecServerInfo, Job aQueuedJob, bool abolRunFirstTestCase)
        {
            throw new NotImplementedException();
        }

        public bool? JobComplete(string JobID, JobResult Result)
        {
            throw new NotImplementedException();
        }

        public void RegisterExecServer(ExecServerInfo ServerInfo)
        {
            throw new NotImplementedException();
        }

        public void UnregisterExecServer(string HostName)
        {
            throw new NotImplementedException();
        }

        public void SetExecServerStatus(string HostName, string Status)
        {
            throw new NotImplementedException();
        }

        public List<string> GetResultsList()
        {
            throw new NotImplementedException();
        }

        public void RunReport(List<string> Results)
        {
            throw new NotImplementedException();
        }

        public string Version()
        {
            return "1.0";
        }

        public event OutputHandler OnOutput;

        public DateTime QueueLastModified()
        {
            throw new NotImplementedException();
        }

        public DateTime ScheduleLastModified()
        {
            throw new NotImplementedException();
        }

        public void RegisterConsole(string HostName)
        {
            throw new NotImplementedException();
        }

        public void UnregisterConsole(string HostName)
        {
            throw new NotImplementedException();
        }

        public List<VMExecServer> GetVMExecServers()
        {
            throw new NotImplementedException();
        }

        public void UpdateVMExecServerStatus(VMExecServer aExecServer, VMESStatus aStatus, string aErrrMessage)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRunningESInfo()
        {
            throw new NotImplementedException();
        }

        public void ESAddOrReplace(VMExecServer es)
        {
            throw new NotImplementedException();
        }

        public void ESDelete(VMExecServer es)
        {
            throw new NotImplementedException();
        }

        public List<string> ESGetSnapshotList(string aHostName, string aVMFile)
        {
            throw new NotImplementedException();
        }

        public List<TCInfo> GetTCInfo()
        {
            throw new NotImplementedException();
        }

        public void TCInfoAddOrReplace(TCInfo aTCInfo)
        {
            throw new NotImplementedException();
        }

        public void TCInfoDelete(string ID)
        {
            throw new NotImplementedException();
        }

        public void TestEnAddOrReplace(TestEnvironmentInfo aTestEn)
        {
            throw new NotImplementedException();
        }

        public void TestEnDelete(TestEnvironmentInfo aTestEn)
        {
            throw new NotImplementedException();
        }

        public List<TestEnvironmentInfo> GetTestEn()
        {
            throw new NotImplementedException();
        }

        public void ApplyAllJobStarTeamInfo(List<string> aStarTeamInfo)
        {
            throw new NotImplementedException();
        }

        public void LoadESXINI()
        {
            throw new NotImplementedException();
        }

        public string ReconnectAllESXSvr()
        {
            throw new NotImplementedException();
        }

        public string ReconnectESXSvr(string aSvrName)
        {
            throw new NotImplementedException();
        }

        public void AllESStatusToStopped()
        {
            throw new NotImplementedException();
        }

        public string GetPreTask(string aEn)
        {
            throw new NotImplementedException();
        }

        public long FileSpicalSize(string aFileName)
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream DownloadFileWithCustomStream(string aFilePath, long aOffset, long aCount)
        {
            throw new NotImplementedException();
        }

        public string[] GetFiles(string aPath, string aSearchPattern, System.IO.SearchOption aSearchOption)
        {
            throw new NotImplementedException();
        }

        public ProductInfo[] GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
