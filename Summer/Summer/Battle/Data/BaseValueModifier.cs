using System;
using System.Collections.Generic;
using System.Text;

namespace Summer.Battle.Data
{
    public class BaseIntModifier
    {
        public int Value { get; private set; }
        private List<I_IntModifier> m_ModifierLst = new List<I_IntModifier>();

        public int Add(I_IntModifier modifier)
        {
            if (m_ModifierLst.Contains(modifier))
                return Value;

            m_ModifierLst.Add(modifier);
            Update();
            return Value;
        }

        public int Remove(I_IntModifier modifier)
        {
            if (!m_ModifierLst.Contains(modifier))
                return Value;

            m_ModifierLst.Remove(modifier);
            Update();
            return Value;
        }

        private void Update()
        {
            Value = 0;
            int length = m_ModifierLst.Count;
            for (int i = 0; i < length; i++)
            {
                if (!m_ModifierLst[i].Enable)
                    continue;

                Value += m_ModifierLst[i].Value;
            }
        }
    }

    /// <summary>
    /// 数值修饰器 
    /// 例子:
    ///     A+B+C的Buff修改了某一个数值，新增D Buff其效果是让某一个中类型的Buff的数值变动功能失效
    ///     其核心就是数值的变动是有源头的，可以知道哪些是属于Buff的，哪些是属于装备的
    /// 这块需要让策划做好规划
    /// </summary>
    public interface I_IntModifier
    {
        bool Enable { get; protected set; }

        int Value { get; protected set; }
    }

    /// <summary>
    /// 最终数值 = 基础数值+Add数值+(基础数值*Add百分比)
    /// 可以在这个基础之上再进行扩展
    /// 
    /// 1. 简化消耗 不是所有的数据都需要这么强大
    /// 2. 缓存池方式减少数值修饰器的开销
    /// </summary>
    public class TValueInt
    {
        public int Value { get; private set; }
        public int BaseValue { get; private set; }
        private BaseIntModifier AddValue;
        private BaseIntModifier PctAddValue;
       
        public void Initialize()
        {
            /*BaseValue = AddValue = PctAddValue  = 0;*/
        }
        public int SetBase(int value)
        {
            BaseValue = value;
            Update();
            return BaseValue;
        }
        public int Add(int value)
        {
            /* AddValue += value;
             Update();
             return Value;*/
            return Value;
        }
        public int PctAdd(int value)
        {
            /*PctAddValue += value;
            Update();
            return Value;*/
            return Value;
        }

        public void Update()
        {
            /*var value1 = BaseValue;
            var value2 = value1 + AddValue + value1 * (100 + PctAddValue) / 100f;

            Value = (int)value2;*/
        }
    }

    public enum E_ValueType
    {
        /// <summary>
        /// 数值
        /// </summary>
        Value = 0,
        /// <summary>
        /// 百分比
        /// </summary>
        Percent = 1,
        /// <summary>
        /// 固定值 (待)
        /// </summary>
        Assignment = 2,
    }
}
