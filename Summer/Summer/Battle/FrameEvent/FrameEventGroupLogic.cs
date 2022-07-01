using System;
using System.Collections.Generic;
using System.Text;

namespace Summer.Battle.FrameEvent
{
    /// <summary>
    /// 需求: 
    ///     帧事件之间的排序问题 - 所见即所得的方式是否更好
    ///     加速问题、循环问题
    /// </summary>
    public class FrameEventGroupLogic
    {
        public string GroupName { get; private set; }                       
        public bool IsLoop { get; private set; }                                            // 循环
        public bool Active { get; private set; }                                            // 创建
        public bool Enabled { get; private set; }                                           // 帧事件激活    
        public int CurrKeyFrame { get; private set; }                                       // 当前下标
        public int TotalFrame { get; private set; }

        protected List<FrameEventLogic> m_FrameEventLst = new List<FrameEventLogic>();
        
        public FrameEventGroupLogic()
        {
            IsLoop = false;
        }

        public void Initialize()
        {

        }

        public void Update()
        {
            if (!Enabled||!Active)
                return;

            if(CurrKeyFrame==0)
                OnEnter();
            
            OnUpdate();

            if (CurrKeyFrame == TotalFrame)
                OnExit();
        }

        public void Dispose()
        {

        }

        #region private

        private void OnEnter()
        {
            int length = m_FrameEventLst.Count;
            for (int i = 0; i < length; i++)
            {
                m_FrameEventLst[i].GroupEnter();
            }
        }
        
        private void OnUpdate()
        {
            while (CurrKeyFrame < TotalFrame)
            {
                CurrKeyFrame++;

                int length = m_FrameEventLst.Count;
                for (int i = 0; i < length; i++)
                {
                    m_FrameEventLst[i].Update(CurrKeyFrame);
                }
            }
        }
        
        private void OnExit()
        {
            int length = m_FrameEventLst.Count;
            for (int i = 0; i < length; i++)
            {
                m_FrameEventLst[i].GroupExit();
            }
        }


        #endregion
    }

}
