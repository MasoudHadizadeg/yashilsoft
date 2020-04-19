using System;
using System.Collections.Generic;
using System.Text;

namespace Yashil.Core.Enums
{
    public enum AccessLevelEnum
    {
        /// <summary>
        /// دسترسی عادی
        /// </summary>
        Normal = 1,

        /// <summary>
        /// محرمانه
        /// </summary>
        Confidential = 2,

        /// <summary>
        /// خیلی محرمانه
        /// </summary>
        VeryConfidential = 3,

        /// <summary>
        /// سری
        /// </summary>
        Secret = 4,

        /// <summary>
        /// بکلی سری
        /// </summary>
        TotallySecret = 5
    }

    public enum NewsTypeEnum
    {
        Simple = 1069,
        Gallery = 1075,
        Movie = 1072,
        Notification = 1074,
        Pictorial = 1071
    }
}