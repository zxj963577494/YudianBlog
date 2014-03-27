using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T>
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public T Tid { get; set; }

        /// <summary>
        /// 验证实体
        /// </summary>
        protected abstract void Validate();

        /// <summary>
        /// 获取有效实体
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="businessRule"></param>
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="businessRule"></param>
        protected void RemoveBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Remove(businessRule);
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is EntityBase<T> && this == (EntityBase<T>) obj;
        }

        public override int GetHashCode()
        {
            return this.Tid.GetHashCode();
        }

        /// <summary>
        /// 重写 “==”
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase<T> entity1,
           EntityBase<T> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Tid.ToString() == entity2.Tid.ToString())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 重写 “!=”
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase<T> entity1,
            EntityBase<T> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
