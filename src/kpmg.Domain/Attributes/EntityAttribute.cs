﻿#region

using System;

#endregion

namespace kpmg.Domain.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        public EntityAttribute(string include)
        {
            Include = include;
        }

        public string Include { get; set; }
    }
}