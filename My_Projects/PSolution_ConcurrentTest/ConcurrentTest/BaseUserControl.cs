using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ConcurrentTest
{
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public enum ConcurrentResult
        {
            AllConcurrentNoHit,
        }

        public enum ConcurrentAction
        {
            AddUpdateObjIfRuleNotHitNoDuplicate,
            Remove,
        }
        private List<TConcurrentRule> FConcurrentRule = new List<TConcurrentRule>(0);
        public BaseUserControl()
        {
            InitializeComponent();
        }

        private void AddConcurrentRule()
        {
            ConcurrentTest.AddRule(AddConcurrentRule);
        }

        public void AddConcurrentRule(object aActionToCheck,List<object> aActionAtConcurrentTable)
        {
            lock (FConcurrentRule)
            {
                FConcurrentRule.Add(new TConcurrentRule(aActionToCheck, aActionAtConcurrentTable));
            }
        }

        protected bool ConcurrentAdd(string aSetID, object aProcess)
        {
           
            return Concurrent(aSetID, aProcess, ConcurrentAction.AddUpdateObjIfRuleNotHitNoDuplicate) == ConcurrentResult.AllConcurrentNoHit;

        }

 
    }

    public class TConcurrentRule
	{
		private object pActionToCheck = null;
		private List<object> pActionAtConcurrentTable = null;

		public object ActionToCheck { get { return pActionToCheck; } }
		public List<object> ActionAtConcurrentTable { get { return pActionAtConcurrentTable; } }

        public TConcurrentRule(object aActionToCheck, List<object> aActionAtConcurrentTable)
		{
			pActionAtConcurrentTable = aActionAtConcurrentTable;
			pActionToCheck = aActionToCheck;
		}
    }

    public class TConcurrentObj
    {
        private List<object> pAction = new List<object>(0);
        private List<string> pKeys = null;

        public List<string> Keys { get { return pKeys; } }
        public List<object> Action { get { return pAction; } set { pAction = value; } }

        public TConcurrentObj(List<string> aKeys, object aAction)
        {
            pKeys = aKeys;
            pAction.Add(aAction);
        }


        public bool IsKeyMatchAnyLevel(List<string> aNewKeys)
        {
            int _Length;
            if (aNewKeys.Count > Keys.Count)
                _Length = Keys.Count;
            else
                _Length = aNewKeys.Count;
            for (int _Level = 0; _Level <= _Length - 1; _Level++)
            {
                if ((aNewKeys[_Level] != null) && (aNewKeys[_Level] != Keys[_Level]))
                    return false;
            }
            return true;
        }

        public bool IsWholeKeysMatched(List<string> aNewKeys)
        {
            if (Keys.Count != aNewKeys.Count)
                return false;
            else
            {
                for (int _Level = 0; _Level <= aNewKeys.Count - 1; _Level++)
                {
                    if ((aNewKeys[_Level] != null) && (aNewKeys[_Level] != Keys[_Level]))
                        return false;
                }
                return true;
            }
        }

        public bool IsKeyMatchOneLowerLeve(List<string> aNewKeys)
        {

            if ((aNewKeys.Count == 1) && (aNewKeys[0] == null))
            {
                if (Keys.Count == 1)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Keys.Count != aNewKeys.Count + 1)
                {
                    return false;
                }
                else
                {
                    for (int _Level = 0; _Level <= aNewKeys.Count - 1; _Level++)
                    {
                        if ((aNewKeys[_Level] != null) && (aNewKeys[_Level] != Keys[_Level]))
                            return false;
                    }
                }
                return true;
            }
        }


  

    }

}
