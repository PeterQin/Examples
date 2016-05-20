using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;

namespace WpfApplication25
{
    public class RecommendSQLDataModel : DataModel
    {
        private const string C_Prop_SQLName = "SQLName";
        private string FSQLName;

        public string SQLName
        {
            get { return FSQLName; }
            set
            {
                if (FSQLName != value)
                {
                    FSQLName = value;
                    RaisePropertyChanged(C_Prop_SQLName);
                }
            }
        }

        private const string C_Prop_TopN = "TopN";
        private int FTopN;

        public int TopN
        {
            get { return FTopN; }
            set
            {
                if (FTopN != value)
                {
                    FTopN = value;
                    RaisePropertyChanged(C_Prop_TopN);
                }
            }
        }

        //Batches or Batch or SQL
        private const string C_Prop_TopNBaseSQLType = "TopNBaseSQLType";
        private string FTopNBaseSQLType;

        public string TopNBaseSQLType
        {
            get { return FTopNBaseSQLType; }
            set
            {
                if (FTopNBaseSQLType != value)
                {
                    FTopNBaseSQLType = value;
                    RaisePropertyChanged(C_Prop_TopNBaseSQLType);
                }
            }
        }

        private const string C_Prop_TopNConsumedPercent = "TopNConsumedPercent";
        private string FTopNConsumedPercent;

        public string TopNConsumedPercent
        {
            get { return FTopNConsumedPercent; }
            set
            {
                if (FTopNConsumedPercent != value)
                {
                    FTopNConsumedPercent = value;
                    RaisePropertyChanged(C_Prop_TopNConsumedPercent);
                }
            }
        }

        private const string C_Prop_CurrentStat = "CurrentStat";
        private string FCurrentStat;

        public string CurrentStat
        {
            get { return FCurrentStat; }
            set
            {
                if (FCurrentStat != value)
                {
                    FCurrentStat = value;
                    RaisePropertyChanged(C_Prop_CurrentStat);
                }
            }
        }

        private string FBaseSQLType;
        private string C_Prop_BaseSQLType = "BaseSQLType";
        public string BaseSQLType
        {
            get { return FBaseSQLType; }
            set
            {
                if (FBaseSQLType != value)
                {
                    FBaseSQLType = value;
                    RaisePropertyChanged(C_Prop_BaseSQLType);
                }

            }
        }  

        private const string C_Prop_SQLStatList = "SQLStatList";
        private List<StatInfo> FSQLStatList;

        public List<StatInfo> SQLStatList
        {
            get { return FSQLStatList; }
            set
            {
                if (FSQLStatList != value)
                {
                    FSQLStatList = value;
                    RaisePropertyChanged(C_Prop_SQLStatList);
                }
            }
        }

        private const string C_Prop_TopSQLStatList = "TopSQLStatList";
        private List<StatInfo> FTopSQLStatList;

        public List<StatInfo> TopSQLStatList
        {
            get { return FTopSQLStatList; }
            set
            {
                if (FTopSQLStatList != value)
                {
                    FTopSQLStatList = value;
                    RaisePropertyChanged(C_Prop_TopSQLStatList);
                }
            }
        }

    }

    public class StatInfo
    {
        public string StatName { get; set; }

        public string DisplayName { get; set; }

        public double Value { get; set; }

        public double Percentage { get; set; }

        private bool FVisible;

        public bool Visible
        {
            get { return FVisible; }
            set { FVisible = value; }
        }

    }
}
