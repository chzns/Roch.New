using System;
using System.Collections.Generic;
using System.Text;

namespace Roch.Framework
{
    public class DataAccessReturnValue
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int SUCCESS = 1;
        /// <summary>
        /// 名称已存在
        /// </summary>
        public const int NAME_EXISTS = 7;
        /// <summary>
        /// 其它项存在
        /// </summary>
        public const int OTHER_EXISTS = 8;
        /// <summary>
        /// 对象被修改或删除
        /// </summary>
        public const int INVALID_EFFECT_ROWS = 10;
        /// <summary>
        /// 执行子信息的数据操作时，影响的行数不是预料的
        /// </summary>
        public const int CHILD_INVALID_EFFECT_ROWS = 11;
        /// <summary>
        /// 父对象被删除
        /// </summary>
        public const int FATHER_DELETE = 12;
        /// <summary>
        /// 对象版本改变
        /// </summary>
        public const int OBJECT_REVERSION_CHANGED = 13;
        /// <summary>
        /// 其它错误
        /// </summary>
        public const int OTHER_ERROR = 100;
        /// <summary>
        /// 发生未知错误
        /// </summary>
        public const int ERROR = 110;
        /// <summary>
        /// 外键冲突1
        /// </summary>
        public const int FK_ERROR = 120;
        /// <summary>
        /// 被其它其项使用
        /// </summary>
        public const int OTHER_USE = 130;
        /// <summary>
        /// 文件操作失败
        /// </summary>
        public const int FILE_OPERATION_FAILD = 140;
    }
}
