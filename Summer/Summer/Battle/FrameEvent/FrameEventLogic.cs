using System;
using System.Collections.Generic;
using System.Text;
using TrueSync;

namespace Summer.Battle.FrameEvent
{

    /// <summary>
    /// 需求类：
    ///     1. 控制其他片段的执行与否（Action） 有点类似激活/Layer等
    ///     2. 补帧问题，加速的情况下，如何更好的处理位移和动作之间的问题
    /// </summary>

    /// <summary>
    /// 基础类的几个生命周期
    /// 1. 创建的生命周期
    ///     Initialize
    ///     Dispose
    /// 2. 轨道的进入 没有轨道退出
    ///     TrackEnter
    /// 3. 事件的进入和退出
    ///     OnFrameEnter
    ///     OnFrameExit,如果没有进入，就没有退出这一说法。同时OnFrameExit是在ClipExit中调用
    /// </summary>
    public class FrameEventLogic
    {
        private static int GlobalFrameEventID;
        public int FrameEventInstanceID { get; private set; }                   
        public bool Active { get; private set; }                                            // 创建
        public bool Enabled { get; private set; }                                           // 帧事件激活    
        public int StartKeyFrame { get; private set; }                                      // 轨道中开始的帧下标（轨道是指动作或者时间轴）
        public int EndKeyFrame { get; private set; }                                        // 轨道中结束的帧下标（轨道是指动作或者时间轴）


        //protected FrameEventInfo m_FrameInfo;
        protected string m_Param;
        protected int m_CurrKeyFrame;                                                       // 当前轨道运行到第几帧
        protected EventLayer m_EventLayer=EventLayer.Default;                               // 层级
        protected int KeyFrameCount { get { return EndKeyFrame - StartKeyFrame + 1; } }     // 总的帧长【包含首尾帧】
        


        #region public 

        public void Update(int frame)
        {
            if (Active/* || CheckLayer()*/)
                return;

            m_CurrKeyFrame = frame;
        }

        #endregion

        #region public virtual 

        #region 生命周期
        public virtual void Initialize(FrameEventData frameEventData)
        {
            Active = true;
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void Dispose()
        {
            Active = false;
        }
        #endregion

        public virtual void GroupEnter() { }
        public virtual void GroupExit() { }

        #endregion

        #region protected virtual

        protected virtual void OnFrameEnter() { }
        protected virtual void OnFrameUpdate() { }
        protected virtual void OnFrameExit() { }
        protected virtual bool DoCheckLayer() { return true; }
        #endregion


        #region private 

        private bool CheckLayer()
        {
            return this.m_EventLayer == EventLayer.Default || DoCheckLayer();
        }

        private void DoUpdateFrameWithPercent(int frame, FP percent)
        {
            if (!CheckValidUpdateFrame(frame))
                return;

            m_CurrKeyFrame = frame;
            if (m_CurrKeyFrame == StartKeyFrame)
            {
                OnFrameEnter();
            }
            OnFrameUpdate();
            if (m_CurrKeyFrame==EndKeyFrame)
            {
                OnFrameExit();
            }
        }

        // 被动激活，只要条件符合(时间+轨道)就被动激活
        private void DoPassiveActive()
        {
            if (Enabled)
                return;



        }

        private bool CheckValidUpdateFrame(int frame)
        {
            return true;
        }

        #endregion
    }

    public class FrameEventInfo
    {
        public FrameEventData m_Data;

        public bool CheckValidUpdateFrame(int frame)
        {
            return false;
        }
    }

    public class FrameEventData
    {

    }


    [Flags]
    public enum EventLayer : long
    {
        Default = 1 << 0,
        Layer1 = 1 << 1,
        Max = 1 << 31,
    }
}
